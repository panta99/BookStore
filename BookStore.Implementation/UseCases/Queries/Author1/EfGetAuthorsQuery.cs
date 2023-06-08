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
        public EfGetAuthorsQuery(BookStoreContext context, IMapper mapper)
            : base(context)
        {
            _mapper = mapper;
        }
        public int Id => 1;

        public string Name => "Search authors";

        public string Description => "";

        public IEnumerable<GetAuthorDto> Execute(AuthorSearch search)
        {
            var authors = Context.Authors.AsQueryable();
            if (!string.IsNullOrEmpty(search.Keyword))
            {
                authors = authors.Where(x => (x.FirstName.ToLower() + ' ' + x.LastName.ToLower()).Contains(search.Keyword));
                authors.ToList();
            }
            return _mapper.Map<List<GetAuthorDto>>(authors);
        }
    }
}
