using BookStore.Application.UseCases.DTO.PublisherDTOs;
using BookStore.Application.UseCases.Queries.PublisherQ;
using BookStore.Application.UseCases.Queries.Searches;
using BookStore.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Implementation.UseCases.Queries.PublisherC
{
    public class EfGetPublisherQuery : EfUseCase, IGetPublisherQuery
    {
        public EfGetPublisherQuery(BookStoreContext context) 
            : base(context)
        {
        }

        public int Id => 9;

        public string Name => "Search publishers";

        public string Description => "Search publishers by keyword";

        public IEnumerable<GetPublisherDto> Execute(PublisherSearch search)
        {
            var query = Context.Publishers.Where(x=> !x.DeletedAt.HasValue).AsQueryable();
            if (!string.IsNullOrEmpty(search.Keyword))
            {
                query = query.Where(x => x.Name.ToLower().Contains(search.Keyword.ToLower()));
            }
            var result = query.Select(x => new GetPublisherDto
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
