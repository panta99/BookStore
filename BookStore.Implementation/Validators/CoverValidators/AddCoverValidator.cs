using BookStore.Application.UseCases.DTO.CoverDTOs;
using BookStore.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Implementation.Validators.CoverValidators
{
    public class AddCoverValidator : AbstractValidator<AddCoverDto>
    {
        public AddCoverValidator(BookStoreContext context)
        {
            RuleFor(x => x.Name).NotEmpty()
                                .WithMessage("Name is required");
            RuleFor(x=> x.Name).Must(y=> !context.Covers.Any(x=> x.CoverType==y))
                               .WithMessage("Genre with this name already exists");

        }
    }
}
