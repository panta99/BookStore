using BookStore.Application.UseCases.DTO.RoleUseCaseDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.UseCases.Commands.RoleUseCaseC
{
    public interface IAddRoleUseCasesCommand : ICommand<RoleUseCaseCommandsDto>
    {
    }
}
