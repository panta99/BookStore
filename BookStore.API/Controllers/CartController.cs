using BookStore.Application.UseCaseHandling;
using BookStore.Application.UseCases.Commands.CartC;
using BookStore.Application.UseCases.DTO.CartDTOs;
using BookStore.Application.UseCases.Queries.CartQ;
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
    public class CartController : ControllerBase
    {
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
            command.Execute(dto);
            return StatusCode(201);
        }

        // PUT api/<CartController>/5
        [HttpPatch]
        public IActionResult UpdateQuantity([FromQuery] UpdateCartDto dto,
                                            [FromServices] IUpdateCartQuantityCommand command)
        {
            command.Execute(dto);
            return Ok();
        }

        // DELETE api/<CartController>/5
        [HttpDelete]
        public IActionResult Delete([FromBody] DeleteBookFromCartDto dto,
                                    [FromServices] IDeleteBookFromCartCommand command)
        {
            command.Execute(dto);
            return NoContent();
        }
    }
}
