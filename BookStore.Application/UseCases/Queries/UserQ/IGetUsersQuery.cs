using BookStore.Application.UseCases.DTO;
using BookStore.Application.UseCases.DTO.UserDTOs;
using BookStore.Application.UseCases.Queries.Searches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.UseCases.Queries.UserQ
{
    public interface IGetUsersQuery : IQuery<UserSearch,PagedResponse<GetUserDto>>
    {
    }
}
