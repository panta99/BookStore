using BookStore.Application.UseCases.Commands.GenreC;
using BookStore.Application.UseCases.DTO.GenreDTOs;
using BookStore.Application.UseCases.Exceptions;
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
    public class EfUpdateGenreCommand : EfUseCase, IUpdateGenreCommand
    {
        private UpdateGenreValidator _validator;
        public EfUpdateGenreCommand(BookStoreContext context, UpdateGenreValidator validator)
            : base(context)
        {
            _validator = validator;
        }
        public int Id => 7;

        public string Name => "Update genre";

        public string Description => "Update genre name by id";

        public void Execute(UpdateGenreDto request)
        {
            var genre = Context.Genres.Find(request.Id);
            if(genre == null)
            {
                throw new EntityNotFoundException(request.Id, nameof(Genre));
            }
            _validator.ValidateAndThrow(request);
            genre.Name = request.Name;
            genre.ModifiedAt = DateTime.UtcNow;
            Context.SaveChanges();
        }
    }
}
