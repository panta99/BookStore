using BookStore.Application.Exceptions;
using BookStore.Application.UseCases.Commands.BookC;
using BookStore.Application.UseCases.Exceptions;
using BookStore.DataAccess;
using BookStore.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Implementation.UseCases.Commands.BookC
{
    public class EfDeleteBookCommand : EfUseCase, IDeleteBookCommand
    {
        public EfDeleteBookCommand(BookStoreContext context) : base(context)
        {
        }

        public int Id => 24;

        public string Name => "Delete book";

        public string Description => "Delete book by id";

        public void Execute(int id)
        {
            var query = Context.Books
                                .Include(x=> x.BookAuthors)
                                .Include(x=> x.BookGenres)
                                .Include(x=> x.OrderBooks)
                                .Include(x=> x.CartBooks)
                                .FirstOrDefault(x=> x.Id == id);
            if(query == null)
            {
                throw new EntityNotFoundException(id, nameof(Book));
            }
            var check1 = query.BookAuthors.Any();
            var check2 = query.BookGenres.Any();
            var check3 = query.CartBooks.Any();
            var check4 = query.OrderBooks.Any();
            if (check1 || check2 || check3 || check4)
            {
                var message = $"Can't delete author with id={query.Id} due to dependencies or associations";
                throw new ConflictException(Name, message);
            }
            var isDeleted = query.DeletedAt.HasValue;
            if (isDeleted)
            {
                throw new EntityNotFoundException(query.Id, nameof(Book));
            }
            query.DeletedAt = DateTime.UtcNow;
            Context.SaveChanges();
        }
    }
}
