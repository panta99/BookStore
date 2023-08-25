using BookStore.Application.UseCases.DTO;
using BookStore.Application.UseCases.DTO.BookDTOs;
using BookStore.Application.UseCases.Queries.BookQ;
using BookStore.Application.UseCases.Queries.Searches;
using BookStore.DataAccess;
using BookStore.Domain.Entites;
using BookStore.Implementation.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Implementation.UseCases.Queries.BookQ
{
    public class EfGetBooksQuery : EfUseCase, IGetBooksQuery
    {
        public EfGetBooksQuery(BookStoreContext context)
            : base(context)
        {

        }
        public int Id => 19;

        public string Name => "Get books";

        public string Description => "Get books with search";

        public PagedResponse<GetBookDto> Execute(BookSearch search)
        {
            var query = Context.Books.Where(x=> x.IsActive && !x.DeletedAt.HasValue).AsQueryable();
            if (!string.IsNullOrEmpty(search.BookName))
            {
                query = query.Where(x => x.Name.Contains(search.BookName));
            }
            if (search.MinPrice.HasValue)
            {
                query = query.Where(x => x.Price >= search.MinPrice);
            }
            if (search.MaxPrice.HasValue)
            {
                query = query.Where(x => x.Price <= search.MaxPrice);
            }
            if (search.Available)
            {
                query = query.Where(x => x.QuantityInStock > 0);
            }
            if (search.PublisherId.HasValue)
            {
                query = query.Where(x => x.PublisherId == search.PublisherId);
            }
            if (search.CoverId.HasValue)
            {
                query = query.Where(x => x.CoverId == search.CoverId);
            }
            if (search.GenresIds != null && search.GenresIds.Any())
            {
                query = query.Where(x => x.BookGenres.Any(y => search.GenresIds.Contains(y.GenreId)));
            }
            if (search.AuthorsIds != null && search.AuthorsIds.Any())
            {
                query = query.Where(x => x.BookAuthors.Any(y => search.AuthorsIds.Contains(y.AuthorId)));
            }
            return query.ToPagedResponse<Book, GetBookDto>(search, x => new GetBookDto
            {
                BookName = x.Name,
                Authors = x.BookAuthors.Select(x => new GetAuthorDto
                {
                    Id = x.Author.Id,
                    FirstName = x.Author.FirstName,
                    LastName = x.Author.LastName,
                }).ToList(),
                Price = x.Price,
                Image = new ImageDto
                {
                    Id = x.Image.Id,
                    Path = x.Image.Path
                }
            });
        }
    }
}
