using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.UseCases.DTO.CartDTOs
{
    public class AddBookToCartDto
    {
        public int? CartId { get; set; }
        public int BookId { get; set; }
        public int Quantity { get; set; }
        public int UserId { get; set; }
    }
}
