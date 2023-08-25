using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.UseCases.DTO.BookDTOs
{
    public class UpdateBookQuantityDto
    {
        public int BookId { get; set; }
        public int Quantity { get; set; }
    }
}
