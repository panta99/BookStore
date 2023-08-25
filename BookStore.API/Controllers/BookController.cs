using BookStore.Application.UseCaseHandling;
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
            return Ok(handler.HandleQuery(query,id));
        }

        // POST api/<BookController>
        [HttpPost]
        public void AddBook([FromBody] string value)
        {
        }

        // PUT api/<BookController>/5
        [HttpPut("{id}")]
        public void UpdateBook(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BookController>/5
        [HttpDelete("{id}")]
        public void DeleteBook(int id)
        {
        }
    }
}
