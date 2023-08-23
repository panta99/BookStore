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
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x=> x.Name).Must(y=> !context.Genres.Any(x=> x.Name==y))
                               .WithMessage("Genre with this name already exists");

        }
    }
}
