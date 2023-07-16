using BookStore.Application.UseCases.DTO;
using BookStore.Application.UseCases.DTO.GenreDTOs;
using BookStore.Application.UseCases.Queries.Searches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.UseCases.Queries.GenreQ
{
    public interface IGetGenresQuery : IQuery<GenreSearch, PagedResponse<GetGenreDto>>
    {
    }
}
