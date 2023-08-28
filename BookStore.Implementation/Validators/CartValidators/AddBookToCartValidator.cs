using BookStore.Application.UseCases.DTO.CartDTOs;
using BookStore.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Implementation.Validators.CartValidators
{
    public class AddBookToCartValidator : AbstractValidator<AddBookToCartDto>
    {
        private readonly BookStoreContext _context;
        public AddBookToCartValidator(BookStoreContext context)
        {
            _context = context;
            RuleFor(x => x.UserId)
                                .NotEmpty()
                                .WithMessage("UserId is required")
                                .Must(x => context.Users.Any(u => u.Id == x))
                                .WithMessage("Invalid user");
            RuleFor(x => x.BookId)
                                .NotEmpty()
                                .WithMessage("BookId is required")
                                .Must(x => _context.Books.Any(b => b.Id == x && !b.DeletedAt.HasValue))
                                .WithMessage((x) => 
                                {
                                    return $"Book with id {x.BookId} doesn't exist";
                                }
                                );
            RuleFor(dto => dto)
                              .Must((dto) => checkQuantity(dto))
                              .WithMessage((dto) =>
                              {
                                  if(_context.Books.Any(x=> x.Id == dto.BookId))
                                  {
                                      var maxQuantity = _context.Books.Where(x => x.Id == dto.BookId).Select(y => y.QuantityInStock).FirstOrDefault();
                                      return $"Book of id {dto.BookId} has only {maxQuantity} left books in stock";
                                  }
                                  else
                                  {
                                      return $"Qunantity for this book with id={dto.BookId} isn't valid, because this book doesn't exist";
                                  }
                                  
                              })
                              .OverridePropertyName("BookQuantity");
        }
        private bool checkQuantity(AddBookToCartDto dto)
        {
            return _context.Books.Any(b => b.Id == dto.BookId && b.QuantityInStock >= dto.Quantity);
        }
    }
}
