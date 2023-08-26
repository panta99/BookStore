using BookStore.Application.Exceptions;
using BookStore.Application.UseCases.Commands.PublisherC;
using BookStore.Application.UseCases.Exceptions;
using BookStore.DataAccess;
using BookStore.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Implementation.UseCases.Commands.PublisherC
{
    public class EfDeletePublisherCommand : EfUseCase, IDeletePublisherCommand
    {
        public  EfDeletePublisherCommand(BookStoreContext context) 
            : base(context)
        {
        }

        public int Id => 12;

        public string Name => "Delete publisher";

        public string Description => "Delete publisher by id";

        public void Execute(int id)
        {
            var query = Context.Publishers
                               .Include(x=> x.Books)
                               .FirstOrDefault(x=> x.Id == id);
            if(query == null)
            {
                throw new EntityNotFoundException(id, nameof(Publisher));
            }
            var check = query.Books.Any();
            if (check)
            {
                var reason = $"Can't delete publisher with id={query.Id} due to dependencies or associations";
                throw new ConflictException(Name, reason);
            }
            var isDeleted = query.DeletedAt.HasValue;
            if (isDeleted)
            {
                throw new EntityNotFoundException(id, nameof(Publisher));
            }
            query.DeletedAt = DateTime.UtcNow;
            Context.SaveChanges();
        }
    }
}
