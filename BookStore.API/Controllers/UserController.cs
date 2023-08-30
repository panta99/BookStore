using BookStore.Application;
using BookStore.Application.UseCaseHandling;
using BookStore.Application.UseCases.Commands.UserQ;
using BookStore.Application.UseCases.DTO.UserDTOs;
using BookStore.Application.UseCases.Queries.Searches;
using BookStore.Application.UseCases.Queries.UserQ;
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
    public class UserController : ControllerBase
    {
        private ICommandHandler _commandHandler;
        private readonly IApplicationActor _actor;
        public UserController(ICommandHandler commandHandler, IApplicationActor actor)
        {
            _actor = actor;
            _commandHandler = commandHandler;
        }

        // GET: api/<UserController>
        [HttpGet]
        public IActionResult GetUsers([FromQuery] UserSearch search,
                                 [FromServices] IGetUsersQuery query,
                                 [FromServices] IQueryHandler handler)
        {
            return Ok(handler.HandleQuery(query, search));
        }
        [HttpGet("{id}")]
        public IActionResult GetSpecificUser([FromQuery] UserSearch search,
                                 [FromServices] IGetUsersQuery query,
                                 [FromServices] IQueryHandler handler)
        {
            return Ok(handler.HandleQuery(query, search));
        }
        //// GET api/<UserController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<UserController>
        [HttpPost]
        public IActionResult RegisterUser([FromBody] RegisterUserDto dto,
                                          [FromServices] IRegisterUserCommand command)
        {
            _commandHandler.HandleCommand(command, dto);
            return StatusCode(201);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id,
                                 [FromBody] UpdateUserDto dto,
                                 [FromServices] IUpdateUserCommand command)
        {
            dto.Id = id;
            _commandHandler.HandleCommand(command, dto);
            return Ok();
        }

        // DELETE api/<UserController>/5
        [HttpPatch("deactivate/{id}")]
        public IActionResult DeactivateUser(int id,
                                            [FromServices] IDeactivateUserCommand command)
        {
            _commandHandler.HandleCommand(command, id);
            return NoContent();
        }
        [HttpPatch("activate/{id}")]
        public IActionResult ActivateUser(int id,
                                            [FromServices] IActivateUserCommand command)
        {
            _commandHandler.HandleCommand(command, id);
            return NoContent();
        }
        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id,
                                        [FromServices] IDeleteUserCommand command)
        {
            _commandHandler.HandleCommand(command, id);
            return NoContent();
        }
    }
}
