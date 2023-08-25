using BookStore.Application.UseCases.DTO.CoverDTOs;
using BookStore.Application.UseCases.DTO.PublisherDTOs;
using BookStore.Application.UseCases.DTO.YearPublishedDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.UseCases.DTO.BookDTOs
{
    public class GetBookDto
    {
        public string BookName { get; set; }
        public decimal Price { get; set; }
        public ImageDto Image { get; set; }
        public IEnumerable<GetAuthorDto> Authors { get; set; }
    }
    public class ImageDto
    {
        public int Id { get; set; }
        public string Path { get; set; }
    }
    public class GetAllBookInfoDto : GetBookDto
    {
        public int NumberOfPages { get; set; }
        public string Description { get; set; }
        public string Publisher { get; set; }
        public int YearPublished{ get; set; }
        public string Cover{ get; set; }
    }
}
