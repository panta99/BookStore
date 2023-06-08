using BookStore.Application.UseCases.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.UseCases.Commands
{
    public interface IAddAuthorCommand : ICommand<AddAuthorDto>
    {
    }
}
