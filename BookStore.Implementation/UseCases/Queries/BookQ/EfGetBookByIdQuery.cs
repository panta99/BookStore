using BookStore.Application.UseCases.DTO;
using BookStore.Application.UseCases.DTO.BookDTOs;
using BookStore.Application.UseCases.Exceptions;
using BookStore.Application.UseCases.Queries.BookQ;
using BookStore.DataAccess;
using BookStore.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Implementation.UseCases.Queries.BookQ
{
    public class EfGetBookByIdQuery : EfUseCase, IGetBookByIdQuery
    {
        public EfGetBookByIdQuery(BookStoreContext context) : base(context)
        {
        }

        public int Id => 20;

        public string Name => "Get book by id";

        public string Description => "Get all the information about the specified book";

        public GetAllBookInfoDto Execute(int search)
        {
            var book = Context.Books
                                    .Include(b=> b.BookAuthors).ThenInclude(b=> b.Author)
                                    .Include(b=> b.BookGenres).ThenInclude(b=> b.Genre)
                                    .Include(b => b.YearPublished)
                                    .Include(b=> b.Publisher)
                                    .Include(b=> b.Cover)
                                    .Include(b=> b.Image)
                                    .FirstOrDefault(x => x.Id == search);
            if(book == null)
            {
                throw new EntityNotFoundException(search,nameof(Book));
            }
            return new GetAllBookInfoDto
            {
                BookName = book.Name,
                Authors = book.BookAuthors.Select(x => new GetAuthorDto
                {
                    Id = x.Author.Id,
                    FirstName = x.Author.FirstName,
                    LastName = x.Author.LastName
                }).ToList(),
                Description = book.Description,
                Price = book.Price,
                NumberOfPages = book.NumberOfPages,
                YearPublished = book.YearPublished.Year,
                Publisher = book.Publisher.Name,
                Cover = book.Cover.CoverType,
                Image = new ImageDto
                {
                    Id = book.Image.Id,
                    Path = book.Image.Path
                }
            };
        }
    }
}
