using BookStore.Application.UseCases.Commands.UserQ;
using BookStore.Application.UseCases.DTO.UserDTOs;
using BookStore.Application.UseCases.Exceptions;
using BookStore.DataAccess;
using BookStore.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Implementation.UseCases.Commands.UserC
{
    public class EfUpdateUserCommand : EfUseCase, IUpdateUserCommand
    {
        public EfUpdateUserCommand(BookStoreContext context) : base(context)
        {
        }

        public int Id => 27;

        public string Name => "Update user";

        public string Description => "Update user by id";

        public void Execute(UpdateUserDto request)
        {
            var user = Context.Users.FirstOrDefault(x => x.Id == request.Id);
            if(user == null)
            {
                throw new EntityNotFoundException(request.Id, nameof(User));
            }
            if(!(request.FirstName == null))
            {
                user.FirstName = request.FirstName;
            }
            if (!(request.LastName == null))
            {
                user.LastName = request.LastName;
            }
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);
            if (!(request.Password ==null) && !(user.Password == passwordHash))
            {
                user.Password = passwordHash;
            }
            var entry = Context.Entry(user);
            if (entry.State == EntityState.Modified)
            {
                user.ModifiedAt = DateTime.UtcNow;
                Context.SaveChanges();
            }
        }
    }
}
