using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.UseCases.DTO.CartDTOs
{
    public class DeleteBookFromCartDto
    {
        public int UserId { get; set; }
        public int BookId { get; set; }
        public bool DeleteAll { get; set; }
    }
}
