using BookStore.Application.UseCases.DTO.YearPublishedDTOs;
using BookStore.Application.UseCases.Queries.YearPublishedQ;
using BookStore.DataAccess;
using BookStore.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Implementation.UseCases.Queries.YearPublishedQ
{
    public class EfGetYearPublishedQuery : EfUseCase, IGetYearPublishedQuery
    {
        public EfGetYearPublishedQuery(BookStoreContext context) 
            : base(context)
        {
        }

        public int Id => 13;

        public string Name => "Search year published";

        public string Description => "Search year by value";

        public IEnumerable<GetYearPublishedDto> Execute(int? search)
        {
            var query = Context.YearPublished.AsQueryable();
            if(!(search == null))
            {
                query = query.Where(x => x.Year == search);
            }
            var result = query.Select(x => new GetYearPublishedDto
            {
                Id = x.Id,
                Year = x.Year
            })
              .OrderByDescending(x => x.Year)
              .ToList();
            return result;
        }
    }
}
