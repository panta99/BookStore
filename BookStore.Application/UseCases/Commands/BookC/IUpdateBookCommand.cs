using BookStore.Application.UseCases.DTO.BookDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.UseCases.Commands.BookC
{
    public interface IUpdateBookCommand : ICommand<UpdateBookDto>
    {
    }
}
