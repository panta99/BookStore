using BookStore.Application.Exceptions;
using BookStore.Application.UseCases.Commands.CoverC;
using BookStore.Application.UseCases.Exceptions;
using BookStore.DataAccess;
using BookStore.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Implementation.UseCases.Commands.CoverC
{
    public class EfDeleteCoverCommand : EfUseCase, IDeleteCoverCommand
    {
        public EfDeleteCoverCommand(BookStoreContext context) : base(context)
        {
        }

        public int Id => 18;

        public string Name => "Delete cover";

        public string Description => "Delete cover by id";

        public void Execute(int request)
        {
            var query = Context.Covers
                               .Include(x=> x.Books)
                               .FirstOrDefault(x=> x.Id == request);
            if(query == null)
            {
                throw new EntityNotFoundException(request, nameof(Cover));
            }
            var check = query.Books.Any();
            if (check)
            {
                var reason = $"Can't delete cover with id={query.Id} due to dependencies or associations";
                throw new ConflictException(Name, reason);
            }
            var isDeleted = query.DeletedAt.HasValue;
            if (isDeleted)
            {
                throw new EntityNotFoundException(request, nameof(Cover));
            }
            query.DeletedAt = DateTime.UtcNow;
            Context.SaveChanges();
        }
    }
}
