using BookStore.Application.Exceptions;
using BookStore.Application.UseCases.Commands.GenreC;
using BookStore.Application.UseCases.Exceptions;
using BookStore.DataAccess;
using BookStore.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Implementation.UseCases.Commands.GenreC
{
    public class EfDeleteGenreCommand : EfUseCase, IDeleteGenreCommand
    {
        public EfDeleteGenreCommand(BookStoreContext context) 
            : base(context)
        {
        }

        public int Id => 8;

        public string Name => "Delete genre";

        public string Description => "Delete genre by id";

        public void Execute(int id)
        {
            var query = Context.Genres.Find(id);
            if(query == null)
            {
                throw new EntityNotFoundException(id, nameof(Genre));
            }
            var check = query.BookGenres.Any();
            if (check)
            {
                var reason = $"Can't delete genre with id={query.Id} due to dependencies or associations";
                throw new ConflictException(Name,reason);
            }
            var isDeleted = query.DeletedAt.HasValue;
            if (isDeleted)
            {
                throw new EntityNotFoundException(id, nameof(Genre));
            }
            query.DeletedAt = DateTime.UtcNow;
            Context.SaveChanges();
        }
    }
}
