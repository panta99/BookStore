using BookStore.Application.UseCases.DTO;
using BookStore.Application.UseCases.DTO.BookDTOs;
using BookStore.Application.UseCases.Queries.Searches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.UseCases.Queries.BookQ
{
    public interface IGetBooksQuery : IQuery<BookSearch,PagedResponse<GetBookDto>>
    {
    }
}
