using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.UseCases.DTO.OrderDTOs
{
    public class UpdateOrderDto
    {
        public int UserId { get; set; }
        public int OrderId { get; set; }
        public int OrderStatus { get; set; }
    }
}
