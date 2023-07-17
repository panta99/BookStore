using BookStore.Application.UseCases.DTO;
using BookStore.Application.UseCases.DTO.GenreDTOs;
using BookStore.Application.UseCases.Queries.GenreQ;
using BookStore.Application.UseCases.Queries.Searches;
using BookStore.DataAccess;
using BookStore.Domain.Entites;
using BookStore.Implementation.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Implementation.UseCases.Queries.GenreQ
{
    public class EfGetGenresQuery : EfUseCase, IGetGenresQuery
    {
        public EfGetGenresQuery(BookStoreContext context) : base(context)
        {
        }

        public int Id => 5;

        public string Name => "Search genres";

        public string Description => "Search genres by keyword";

        public IEnumerable<GetGenreDto> Execute(GenreSearch search)
        {
            var query = Context.Genres.AsQueryable();
            if (!string.IsNullOrEmpty(search.Keyword))
            {
                query = query.Where(x => x.Name.ToLower().Contains(search.Keyword.ToLower()));
            }
            var result = query.Select(x => new GetGenreDto
            {
                Id = x.Id,
                Name = x.Name
            })
                .OrderBy(x => x.Name)
                .ToList();
            return result;
        }
    }
}
