using BookStore.Application;
using BookStore.Application.UseCaseHandling;
using BookStore.Application.UseCases.Commands.CartC;
using BookStore.Application.UseCases.DTO.CartDTOs;
using BookStore.Application.UseCases.Queries.CartQ;
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
    public class CartController : ControllerBase
    {
        private ICommandHandler _commandHandler;
        private readonly IApplicationActor _actor;
        public CartController(ICommandHandler commandHandler, IApplicationActor actor)
        {
            _actor = actor;
            _commandHandler = commandHandler;
        }

        // GET api/<CartController>/5
        [HttpGet("{id}")]
        public IActionResult GetCart(int id,
                                     [FromServices] IGetCartQuery query,
                                     [FromServices] IQueryHandler handler)
        {
          
            return Ok(handler.HandleQuery(query, id));
        }

        // POST api/<CartController>
        [HttpPost]
        public IActionResult AddBookToCart([FromBody] AddBookToCartDto dto,
                                           [FromServices] IAddBookToCartCommand command)
        {
            _commandHandler.HandleCommand(command, dto);
            return StatusCode(201);
        }

        // PUT api/<CartController>/5
        [HttpPatch]
        public IActionResult UpdateQuantity([FromQuery] UpdateCartDto dto,
                                            [FromServices] IUpdateCartQuantityCommand command)
        {
            _commandHandler.HandleCommand(command, dto);
            return Ok();
        }

        // DELETE api/<CartController>/5
        [HttpDelete]
        public IActionResult Delete([FromBody] DeleteBookFromCartDto dto,
                                    [FromServices] IDeleteBookFromCartCommand command)
        {
            _commandHandler.HandleCommand(command, dto);
            return NoContent();
        }
    }
}
