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
    public class EfActivateUserCommand : EfUseCase, IActivateUserCommand
    {
        public EfActivateUserCommand(BookStoreContext context) : base(context)
        {
        }

        public int Id => 29;

        public string Name => "Activate user command";

        public string Description => "Activate user by id";

        public void Execute(int id)
        {
            var user = Context.Users.FirstOrDefault(x=> x.Id == id);
            if(user == null)
            {
                throw new EntityNotFoundException(id, nameof(User));
            }
            user.IsActive = true;
            user.ModifiedAt = DateTime.UtcNow;
            Context.SaveChanges();
        }
    }
}
