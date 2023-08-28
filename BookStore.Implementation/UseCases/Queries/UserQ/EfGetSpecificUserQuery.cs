using BookStore.Application.UseCases.DTO.UserDTOs;
using BookStore.Application.UseCases.Exceptions;
using BookStore.Application.UseCases.Queries.UserQ;
using BookStore.DataAccess;
using BookStore.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Implementation.UseCases.Queries.UserQ
{
    public class EfGetSpecificUserQuery : EfUseCase, IGetSpecificUserQuery
    {
        public EfGetSpecificUserQuery(BookStoreContext context) : base(context)
        {
        }

        public int Id => 31;

        public string Name => "Get specific user";

        public string Description => "Get specific user data by id";

        public GetUserDto Execute(int id)
        {
            var user = Context.Users
                                    .Include(x=> x.Role)
                                    .Where(x => x.IsActive && !x.DeletedAt.HasValue)
                                    .FirstOrDefault(x => x.Id == id);
            if (user == null)
            {
                throw new EntityNotFoundException(id, nameof(User));
            }
            return new GetUserDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                UserName = user.Username,
                RoleName = user.Role.Name
            };
        }
    }
}
