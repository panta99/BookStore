using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.UseCases.DTO.OrderDTOs
{
    public class GetOrderQuery
    {
        public int UserId { get; set; }
        public int? OrderId { get; set; }
    }
    public class GetOrderDto
    {
        public int UserId { get; set; }
        public int OrderId { get; set; }
        public string OrderStatus{ get; set; }
        public string Address { get; set; }
        public IEnumerable<OrderedBooksDto> OrderedBooks { get; set; }
        public decimal TotalPrice { get; set; }
    }
    public class OrderedBooksDto
    {
        public string BookName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
