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
    public class UpdateCoverValidator : AbstractValidator<UpdateCoverDto>
    {
        public UpdateCoverValidator(BookStoreContext context)
        {
            RuleFor(x => x.Name).NotEmpty()
                                .WithMessage("Name is required for update");
            RuleFor(x => x.Name).Must(y => !context.Covers.Any(x => x.CoverType == y))
                                .WithMessage("Cover with this name already exsits");
        }
    }
}
