using BookStore.Application.Exceptions;
using BookStore.Application.UseCases.Commands.AuthorC;
using BookStore.Application.UseCases.Exceptions;
using BookStore.DataAccess;
using BookStore.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Implementation.UseCases.Commands.AuthorC
{
    public class EfDeleteAuthorCommand : EfUseCase, IDeleteAuthorCommand
    {
        public EfDeleteAuthorCommand(BookStoreContext context) : base(context)
        {
        }

        public int Id => 4;

        public string Name => "Delete author";

        public string Description => "Deleting author by id";

        public void Execute(int id)
        {
            var query = Context.Authors.Find(id);
            if(query == null)
            {
                throw new EntityNotFoundException(id, nameof(Author));
            }
            var check = query.BookAuthors.Any();
            if(check)
            {
                var message = $"Can't delete author with id={query.Id} due to dependencies or associations";
                throw new ConflictException(Name, message);
            }
            var isDeleted = query.DeletedAt.HasValue;
            if(isDeleted)
            {
                throw new EntityNotFoundException(query.Id, nameof(Author));
            }
            query.DeletedAt = DateTime.UtcNow;
            Context.SaveChanges();
        }
    }
}
