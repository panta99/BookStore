using BookStore.Application.UseCases.DTO.UserDTOs;
using BookStore.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Implementation.Validators.UserValidators
{
    public class RegisterUserValidator : AbstractValidator<RegisterUserDto>
    {
        public RegisterUserValidator(BookStoreContext context)
        {
            RuleFor(x => x.FirstName)
                                    .NotEmpty()
                                    .WithMessage("First name is required");
            RuleFor(x => x.LastName)
                                   .NotEmpty()
                                   .WithMessage("Last name is required");
            RuleFor(x => x.UserName)
                                  .NotEmpty()
                                  .WithMessage("Username is required")
                                  .Must(x => !context.Users.Any(u => u.Username == x))
                                  .WithMessage("This username is already in use");
            RuleFor(x => x.Email)
                               .NotEmpty()
                               .WithMessage("Email is required")
                               .Must(x => !context.Users.Any(u => u.Email == x && !u.DeletedAt.HasValue))
                               .WithMessage("This email is already in use");
            RuleFor(x => x.Password)
                                  .NotEmpty()
                                  .WithMessage("Password is required");
        }
    }
}
