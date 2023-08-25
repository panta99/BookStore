using BookStore.Application.UseCaseHandling;
using BookStore.Application.UseCases.Commands.BookC;
using BookStore.Application.UseCases.DTO.BookDTOs;
using BookStore.Application.UseCases.Queries.BookQ;
using BookStore.Application.UseCases.Queries.Searches;
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
    public class BookController : ControllerBase
    {
        // GET api/<BookController>
        [HttpGet]
        public IActionResult GetBooks([FromQuery] BookSearch search,
                                      [FromServices] IGetBooksQuery query,
                                      [FromServices] IQueryHandler handler)
        {

            return Ok(handler.HandleQuery(query, search));
        }
        // GET api/<BookController>/5
        [HttpGet("{id}")]
        public IActionResult GetBookById(int id,
                                         [FromServices] IGetBookByIdQuery query,
                                         [FromServices] IQueryHandler handler)
        {
            return Ok(handler.HandleQuery(query, id));
        }

        // POST api/<BookController>
        [HttpPost]
        public IActionResult AddBook([FromBody] AddBookDto dto,
                                     [FromServices] IAddBookCommand command)
        {
            command.Execute(dto);
            return StatusCode(201);
        }

        // PUT api/<BookController>/5
        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id,
                               [FromBody] UpdateBookDto dto,
                               [FromServices] IUpdateBookCommand command)
        {
            dto.Id = id;
            command.Execute(dto);
            return Ok();
        }
        [HttpPatch]
        public IActionResult AddQuantity([FromQuery] UpdateBookQuantityDto dto,
                                         [FromServices] IAddQuantityCommand command)
        {
            command.Execute(dto);
            return Ok();
        }
        // DELETE api/<BookController>/5
        [HttpDelete("{id}")]
        public void DeleteBook(int id)
        {
        }
    }
}
