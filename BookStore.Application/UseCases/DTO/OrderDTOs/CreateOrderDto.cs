using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.UseCases.DTO.OrderDTOs
{
    public class CreateOrderDto
    {
        public int UserId { get; set; }
        public string Address { get; set; }
        public IEnumerable<BooksListForBuyDto> BooksForBuy { get; set; }
    }
    public class BooksListForBuyDto
    {
        public int BookId { get; set; }
        public int Quantity { get; set; }
    }
}
