using BookStore.Application.UseCaseHandling;
using BookStore.Application.UseCases.Commands.GenreC;
using BookStore.Application.UseCases.DTO.GenreDTOs;
using BookStore.Application.UseCases.Queries.GenreQ;
using BookStore.Application.UseCases.Queries.Searches;
using BookStore.DataAccess;
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
    public class GenreController : ControllerBase
    {
        private BookStoreContext _context;
        public GenreController(BookStoreContext context)
        {
            _context = context;
        }
        //// GET: api/<GenreController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/<GenreController>/5
        [HttpGet]
        public IActionResult Get([FromQuery] GenreSearch search,
                                 [FromServices] IGetGenresQuery query,
                                 [FromServices] IQueryHandler handler)
        {
            return Ok(handler.HandleQuery(query, search));
        }

        // POST api/<GenreController>
        [HttpPost]
        public IActionResult Post([FromBody] AddGenreDto dto,
                                  [FromServices] IAddGenreCommand command)
        {
            command.Execute(dto);
            return StatusCode(201);
        }

        // PUT api/<GenreController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, 
                                    [FromBody] UpdateGenreDto dto,
                                    [FromServices] IUpdateGenreCommand command)
        {
            dto.Id = id;
            command.Execute(dto);
            return Ok();
        }

        // DELETE api/<GenreController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id,
                               [FromServices] IDeleteGenreCommand command)
        {
            command.Execute(id);
            return NoContent();
        }
    }
}
