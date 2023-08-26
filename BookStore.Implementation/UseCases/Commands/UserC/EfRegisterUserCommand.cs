using BookStore.Application.UseCases.Commands.UserQ;
using BookStore.Application.UseCases.DTO.UserDTOs;
using BookStore.DataAccess;
using BookStore.Domain.Entites;
using BookStore.Implementation.Validators.UserValidators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Implementation.UseCases.Commands.UserC
{
    public class EfRegisterUserCommand : EfUseCase, IRegisterUserCommand
    {
        private readonly RegisterUserValidator _validator;
        public EfRegisterUserCommand(BookStoreContext context, RegisterUserValidator validator) 
            : base(context)
        {
            _validator = validator;
        }

        public int Id => 26;

        public string Name => "Register user";

        public string Description => "Register user";

        public void Execute(RegisterUserDto request)
        {
            _validator.ValidateAndThrow(request);

            Role defaultRole = Context.Roles.FirstOrDefault(x => x.IsDefault);

            string passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);

            var user = new User
            {
                Username = request.UserName,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Password = passwordHash,
                Role = defaultRole,
                CreatedAt = DateTime.UtcNow
            };
            Context.Users.Add(user);
            Context.SaveChanges();
        }
    }
}
