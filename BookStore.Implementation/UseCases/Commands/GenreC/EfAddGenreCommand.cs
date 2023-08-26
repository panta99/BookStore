using BookStore.Application.UseCases.Commands.GenreC;
using BookStore.Application.UseCases.DTO.GenreDTOs;
using BookStore.DataAccess;
using BookStore.Domain.Entites;
using BookStore.Implementation.Validators.GenreValidators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Implementation.UseCases.Commands.GenreC
{
    public class EfAddGenreCommand : EfUseCase, IAddGenreCommand
    {
        private AddGenreValidator _validator;
        public EfAddGenreCommand(BookStoreContext context, AddGenreValidator validator) 
            : base(context)
        {
            _validator = validator;
        }

        public int Id => 6;

        public string Name => "Add genre";

        public string Description => "Adding genre";

        public void Execute(AddGenreDto request)
        {
            _validator.ValidateAndThrow(request);
            var genre = new Genre
            {
                Name = request.Name,
                CreatedAt = DateTime.UtcNow
            };
            Context.Genres.Add(genre);
            Context.SaveChanges();
        }
    }
}
