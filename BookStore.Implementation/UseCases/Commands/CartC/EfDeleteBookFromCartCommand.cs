using BookStore.Application.Exceptions;
using BookStore.Application.UseCases.Commands.CartC;
using BookStore.Application.UseCases.DTO.CartDTOs;
using BookStore.DataAccess;
using BookStore.Implementation.Validators.CartValidators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Implementation.UseCases.Commands.CartC
{
    public class EfDeleteBookFromCartCommand : EfUseCase, IDeleteBookFromCartCommand
    {
        private readonly DeleteBookValidator _validator;
        public EfDeleteBookFromCartCommand(BookStoreContext context, DeleteBookValidator validator) 
            : base(context)
        {
            _validator = validator;
        }

        public int Id => 36;

        public string Name => "Delete book from cart";

        public string Description => "Delete one book from cart or delete all";

        public void Execute(DeleteBookFromCartDto dto)
        {
            _validator.ValidateAndThrow(dto);
            var hasActiveCart = Context.Cart
                                       .Where(x => x.UserId == dto.UserId && !x.DeletedAt.HasValue)
                                       .Any();
            if (hasActiveCart)
            {
                var cartId = Context.Cart
                    .Where(x => x.UserId == dto.UserId && !x.DeletedAt.HasValue)
                    .Select(x => x.Id)
                    .FirstOrDefault();
                if (dto.DeleteAll)
                {
                    var booksForeRemoval = Context.CartBooks.Where(x => x.CartId == cartId);
                    Context.CartBooks.RemoveRange(booksForeRemoval);
                    Context.SaveChanges();
                    return;
                }
                var isItemInCart = Context.CartBooks.Any(x => x.CartId == cartId && x.BookId == dto.BookId);
                if (isItemInCart)
                {
                    var forRemove = Context.CartBooks.Where(x=> x.BookId == dto.BookId && x.CartId == cartId).FirstOrDefault();
                    Context.CartBooks.Remove(forRemove);
                    Context.SaveChanges();
                    return;
                }
                else
                {
                    throw new HttpStatusCodeException(404, "Your cart is empty");
                }
                throw new HttpStatusCodeException(404, "You don't have any items in cart");
            }

        }
    }
}
