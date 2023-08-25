using BookStore.Application.Searches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.UseCases.Queries.Searches
{
    public class BookSearch : PagedSearch
    {
        public string BookName { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public bool Available { get; set; }
        public int? PublisherId { get; set; }
        public int? CoverId { get; set; }
        public IEnumerable<int> GenresIds { get; set; }
        public IEnumerable<int> AuthorsIds { get; set; }
    }
}
