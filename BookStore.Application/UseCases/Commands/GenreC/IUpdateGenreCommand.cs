using BookStore.Application.UseCases.DTO.GenreDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.UseCases.Commands.GenreC
{
    public interface IUpdateGenreCommand : ICommand<UpdateGenreDto>
    {
    }
}
