using BookStore.Application.UseCases.DTO.OrderDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.UseCases.Queries.OrderQ
{
    public interface IGetOrderQuery : IQuery<GetOrderQuery,IEnumerable<GetOrderDto>>
    {
    }
}
