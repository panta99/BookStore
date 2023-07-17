using AutoMapper;
using BookStore.Application.Searches;
using BookStore.Application.UseCases.DTO;
using BookStore.Application.UseCases.Queries;
using BookStore.DataAccess;
using BookStore.Domain.Entites;
using BookStore.Implementation.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Implementation.UseCases.Queries
{
    public class EfGetAuthorsQuery : EfUseCase, IGetAuthorsQuery
    {
        protected readonly IMapper _mapper;
        public EfGetAuthorsQuery(BookStoreContext context/*, IMapper mapper*/)
            : base(context)
        {
            //_mapper = mapper;
        }
        public int Id => 1;

        public string Name => "Search authors";

        public string Description => "Search author by keyword";
        public IEnumerable<GetAuthorDto> Execute(AuthorSearch search)
        {
            var query = Context.Authors.Where(x=> !x.DeletedAt.HasValue).AsQueryable();
            if (!string.IsNullOrEmpty(search.Keyword))
            {
                query = query.Where(x => (x.FirstName.ToLower() + ' ' + x.LastName.ToLower()).Contains(search.Keyword));
            }
            //return _mapper.Map<List<GetAuthorDto>>(authors);
            var result = query.Select(x => new GetAuthorDto
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName
            })
                .OrderBy(x => x.FirstName)
                .ThenBy(x => x.LastName)
                .ToList();
            return result;
        }
    }
}
