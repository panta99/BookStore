using BookStore.Application.UseCases;
using BookStore.Application.UseCases.DTO.CoverDTOs;
using BookStore.Application.UseCases.DTO.GenreDTOs;
using BookStore.Application.UseCases.Queries.CoverQ;
using BookStore.Application.UseCases.Queries.Searches;
using BookStore.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Implementation.UseCases.Queries.CoverQ
{
    public class EfGetCoversQuery : EfUseCase, IGetCoversQuery
    {
        public EfGetCoversQuery(BookStoreContext context) : base(context)
        {
        }

        public int Id => 15;

        public string Name => "Search cover";

        public string Description => "Search cover by keyword";

        public IEnumerable<GetCoverDto> Execute(CoverSearch search)
        {
            var query = Context.Covers.Where(x => !x.DeletedAt.HasValue).AsQueryable();
            if(!string.IsNullOrEmpty(search.Keyword))
            {
                query.Where(x => x.CoverType.Contains(search.Keyword));
            }
            var result = query.Select(x => new GetCoverDto
            {
                Id = x.Id,
                Name = x.CoverType
            })
            .OrderBy(x => x.Name)
            .ToList();
            return result;
        }
    }
}
