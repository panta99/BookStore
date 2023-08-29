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
    public class DeleteBookValidator : AbstractValidator<DeleteBookFromCartDto>
    {
        private readonly BookStoreContext _context;
        public DeleteBookValidator(BookStoreContext context)
        {
            _context = context;
            RuleFor(x => x.UserId)
                                .NotEmpty()
                                .WithMessage("UserId is required")
                                .Must(x => context.Users.Any(u => u.Id == x && !u.DeletedAt.HasValue))
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
        }
    }
}
