using BookStore.Application.UseCases.DTO.UserDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.UseCases.Commands.UserQ
{
    public interface IRegisterUserCommand : ICommand<RegisterUserDto>
    {
    }
}
