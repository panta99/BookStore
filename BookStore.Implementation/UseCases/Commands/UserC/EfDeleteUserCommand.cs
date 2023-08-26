using BookStore.Application.UseCases.Commands.UserQ;
using BookStore.Application.UseCases.Exceptions;
using BookStore.DataAccess;
using BookStore.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Implementation.UseCases.Commands.UserC
{
    public class EfDeleteUserCommand : EfUseCase, IDeleteUserCommand
    {
        public EfDeleteUserCommand(BookStoreContext context) : base(context)
        {
        }

        public int Id => 30;

        public string Name => "Delete user";

        public string Description => "Delete user by id";

        public void Execute(int id)
        {
            var user = Context.Users.FirstOrDefault(x => x.Id == id);
            if(user == null || user.DeletedAt.HasValue)
            {
                throw new EntityNotFoundException(id, nameof(User));
            }
            user.DeletedAt = DateTime.Now;
            Context.SaveChanges();
        }
    }
}
