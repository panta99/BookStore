using BookStore.Application.UseCases.DTO;
using BookStore.Application.UseCases.DTO.AuthorDTOs;
using BookStore.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Implementation.Validators
{
    public class UpdateAuthorValidator : AbstractValidator<UpdateAuthorDto>
    {
        public UpdateAuthorValidator(BookStoreContext context)
        {
            RuleFor(x => x.FirstName).NotEmpty()
                                        .WithMessage("First name is required");
            RuleFor(x => x.LastName).NotEmpty()
                                        .WithMessage("Last Name is required");
            RuleFor(x => new { x.FirstName, x.LastName }).
                Must(y => !context.Authors.Any(x => x.FirstName == y.FirstName && x.LastName == y.LastName))
                .OverridePropertyName("First name and last name")
                .WithMessage("You can't update, author with this first name and last name already exists");
        }
    }
}
