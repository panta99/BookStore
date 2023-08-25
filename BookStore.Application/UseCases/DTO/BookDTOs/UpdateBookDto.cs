using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.UseCases.DTO.BookDTOs
{
    public class UpdateBookDto
    {
        public int Id { get; set; }
        public string BookName { get; set; }
        public int? NumberOfPages { get; set; }
        public string Description { get; set; }
        public decimal? Price { get; set; }
        public int? PublisherId { get; set; }
        public int? PublishYearId { get; set; }
        public int? CoverId { get; set; }
        public string BookImageFile { get; set; }
        public bool? IsActive { get; set; }
        public IEnumerable<int> AuthorIds { get; set; }
        public IEnumerable<int> GenreIds { get; set; }
    }
}
