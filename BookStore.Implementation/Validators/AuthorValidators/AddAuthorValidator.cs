using BookStore.Application.UseCases.DTO;
using BookStore.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Implementation.Validators
{
    public class AddAuthorValidator : AbstractValidator<AddAuthorDto>
    {
        public AddAuthorValidator(BookStoreContext context)
        {
            RuleLevelCascadeMode = CascadeMode.Stop;
            RuleFor(x => x.FirstName).NotEmpty()
                                    .WithMessage("First name is required");
            RuleFor(x => x.LastName).NotEmpty()
                                   .WithMessage("Last name is required");
            //RuleFor(x => x.FirstName + ' ' + x.LastName).Must(x => !context.Authors.Any(y => y.FirstName+' '+y.LastName == x))
            //                                            .WithMessage("Author already exsist");
            RuleFor(x => new { x.FirstName, x.LastName })
                .Must(y => !context.Authors.Any(x => x.FirstName.ToLower() == y.FirstName.ToLower() && x.LastName.ToLower() == y.LastName.ToLower()))
                .OverridePropertyName("First name and last name")
                .WithMessage($"Author with this first name and last name already exists");
        }
    }
}
