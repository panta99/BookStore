using BookStore.Application.UseCases.DTO.CartDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.UseCases.Queries.CartQ
{
    public interface IGetCartQuery : IQuery<int, GetCartDto>
    {
    }
}
