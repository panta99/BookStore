using BookStore.Application.Searches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.UseCases.Queries.Searches
{
    public class GenreSearch : PagedSearch
    {
        public string Keyword { get; set; }
    }
}
