using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.UseCases.DTO.CartDTOs
{
    public class GetCartDto
    {
        public int CartId { get; set; }
        public int UserId { get; set; }
        public IEnumerable<CartItemDto> BooksInCart { get; set; }
        public decimal PriceOfWholeCart { get; set; }
    }
    public class CartItemDto
    {
        public int BookId { get; set; }
        public string BookName{ get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
