using BookStore.Application.UseCases.DTO.GenreDTOs;
using BookStore.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Implementation.Validators.GenreValidators
{
    public class AddGenreValidator : AbstractValidator<AddGenreDto>
    {
        public AddGenreValidator(BookStoreContext context)
        {
            RuleFor(x => x.Name).NotEmpty()
                               .WithMessage("Name is required");
            RuleFor(x => x.Name).Must(y=> !context.Genres.Any(x=> x.Name.ToLower() == y.ToLower()))
                               .WithMessage("Genre with this name already exists");
        }
    }
}
