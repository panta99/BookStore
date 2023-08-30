using BookStore.Application;
using BookStore.Application.UseCaseHandling;
using BookStore.Application.UseCases.Commands.RoleUseCaseC;
using BookStore.Application.UseCases.DTO.RoleUseCaseDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RoleUseCaseController : ControllerBase
    {
        private ICommandHandler _commandHandler;
        private readonly IApplicationActor _actor;
        public RoleUseCaseController(ICommandHandler commandHandler, IApplicationActor actor)
        {
            _actor = actor;
            _commandHandler = commandHandler;
        }

        // POST api/<RoleUseCaseController>
        [HttpPost]
        public IActionResult AddRoleUseCases([FromBody] RoleUseCaseCommandsDto dto,
                                             [FromServices] IAddRoleUseCasesCommand command)
        {
            _commandHandler.HandleCommand(command, dto);
            return StatusCode(201);
        }
        // DELETE api/<RoleUseCaseController>/5
        [HttpDelete]
        public IActionResult Delete([FromBody] RoleUseCaseCommandsDto dto,
                                    [FromServices] IDeleteRoleUseCasesCommand command)
        {
            _commandHandler.HandleCommand(command, dto);
            return NoContent();
        }
    }
}
