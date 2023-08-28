using BookStore.Application.UseCases.DTO.UserDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.UseCases.Queries.UserQ
{
    public interface IGetSpecificUserQuery : IQuery<int,GetUserDto>
    {
    }
}
