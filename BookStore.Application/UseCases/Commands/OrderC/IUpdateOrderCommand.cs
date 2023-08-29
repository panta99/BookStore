using BookStore.Application.UseCases.DTO.OrderDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.UseCases.Commands.OrderC
{
    public interface IUpdateOrderCommand : ICommand<UpdateOrderDto>
    {
    }
}
