using BookStore.Application.UseCases.DTO.CoverDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.UseCases.Commands.CoverC
{
    public interface IAddCoverCommand : ICommand<AddCoverDto>
    {
    }
}
