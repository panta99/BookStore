using BookStore.Application.Exceptions;
using BookStore.Application.UseCases.Commands.CartC;
using BookStore.Application.UseCases.DTO.CartDTOs;
using BookStore.DataAccess;
using BookStore.Domain.Entites;
using BookStore.Implementation.Validators.CartValidators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Implementation.UseCases.Commands.CartC
{
    public class EfAddBookToCartCommand : EfUseCase, IAddBookToCartCommand
    {
        private readonly AddBookToCartValidator _validator;
        public EfAddBookToCartCommand(BookStoreContext context, AddBookToCartValidator validator) 
            : base(context)
        {
            _validator = validator;
        }

        public int Id => 34;

        public string Name => "Add book to cart";

        public string Description => "Add book to cart";

        public void Execute(AddBookToCartDto dto)
        {
            var hasActiveCart = Context.Cart
                                       .Where(x => x.UserId == dto.UserId && !x.DeletedAt.HasValue)
                                       .Where(x => !dto.CartId.HasValue || x.Id == dto.CartId)
                                       .Any();
            if (hasActiveCart)
            {
                _validator.ValidateAndThrow(dto);
                var cartId = Context.Cart
                                    .Where(x => x.UserId == dto.UserId && !x.DeletedAt.HasValue)
                                    .Where(x => !dto.CartId.HasValue || x.Id == dto.CartId)
                                    .Select(x => x.Id)
                                    .FirstOrDefault();
                var bookPrice = Context.Books.Where(x => x.Id == dto.BookId)
                                             .Select(x => x.Price).FirstOrDefault();
                var doesThisCombinationAlreadyExist = Context.CartBooks.
                                                        Any(x => x.CartId == cartId && x.BookId == dto.BookId);
                if (doesThisCombinationAlreadyExist)
                {
                    var forChange = Context.CartBooks.FirstOrDefault(x => x.BookId == dto.BookId && x.CartId == cartId);
                    forChange.Quantity += dto.Quantity;
                    Context.SaveChanges();
                    throw new HttpStatusCodeException(200,"Successful update");
                }
                Context.CartBooks.Add(new CartBook
                {
                    CartId = cartId,
                    BookId = dto.BookId,
                    Quantity = dto.Quantity,
                    Price = bookPrice
                });
                var cart = Context.Cart.Where(x => x.Id == cartId).FirstOrDefault() ;
                cart.ModifiedAt = DateTime.UtcNow;
                Context.SaveChanges();
            }
            else
            {
                _validator.ValidateAndThrow(dto);
                var cart = new Cart
                {
                    UserId = dto.UserId,
                    CreatedAt = DateTime.UtcNow
                };
                Context.Add(cart);
                Context.SaveChanges();
                var bookPrice = Context.Books.Where(x => x.Id == dto.BookId)
                                             .Select(x => x.Price).FirstOrDefault();
                Context.CartBooks.Add(new CartBook
                {
                    CartId = cart.Id,
                    BookId = dto.BookId,
                    Quantity = dto.Quantity,
                    Price = bookPrice
                });
                Context.SaveChanges();
            }
        }
    }
}
