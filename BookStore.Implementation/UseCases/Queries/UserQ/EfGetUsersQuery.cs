using BookStore.Application.UseCases.DTO;
using BookStore.Application.UseCases.DTO.UserDTOs;
using BookStore.Application.UseCases.Queries.Searches;
using BookStore.Application.UseCases.Queries.UserQ;
using BookStore.DataAccess;
using BookStore.Domain.Entites;
using BookStore.Implementation.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Implementation.UseCases.Queries.UserQ
{
    public class EfGetUsersQuery : EfUseCase, IGetUsersQuery
    {
        public EfGetUsersQuery(BookStoreContext context) : base(context)
        {
        }

        public int Id => 25;

        public string Name => "Get users";

        public string Description => "Get users";

        public PagedResponse<GetUserDto> Execute(UserSearch search)
        {
            var query = Context.Users
                               .Include(x=> x.Role)
                               .Where(x => x.IsActive)
                               .Where(x=> !x.DeletedAt.HasValue).AsQueryable();
            if (!string.IsNullOrEmpty(search.FirstName))
            {
                query = query.Where(x => x.FirstName.Contains(search.FirstName));
            }
            if (!string.IsNullOrEmpty(search.LastName))
            {
                query = query.Where(x => x.LastName.Contains(search.LastName));
            }
            return query.ToPagedResponse<User, GetUserDto>(search, x => new GetUserDto
            {
                Id = x.Id,
                UserName = x.Username,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Email = x.Email,
                RoleId = x.RoleId,
                RoleName = x.Role.Name,
                IsActive = x.IsActive
            });
        }
    }
}
