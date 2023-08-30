using BookStore.Application;
using BookStore.Application.UseCaseHandling;
using BookStore.Application.UseCases.Commands.GenreC;
using BookStore.Application.UseCases.DTO.GenreDTOs;
using BookStore.Application.UseCases.Queries.GenreQ;
using BookStore.Application.UseCases.Queries.Searches;
using BookStore.DataAccess;
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
    public class GenreController : ControllerBase
    {
        private BookStoreContext _context;
        private ICommandHandler _commandHandler;
        private readonly IApplicationActor _actor;
        public GenreController(BookStoreContext context, ICommandHandler commandHandler, IApplicationActor actor)
        {
            _actor = actor;
            _commandHandler = commandHandler;
            _context = context;
        }
        [HttpGet]
        public IActionResult GetGenres([FromQuery] GenreSearch search,
                                 [FromServices] IGetGenresQuery query,
                                 [FromServices] IQueryHandler handler)
        {
            return Ok(handler.HandleQuery(query, search));
        }

        // POST api/<GenreController>
        [HttpPost]
        public IActionResult AddGenre([FromBody] AddGenreDto dto,
                                  [FromServices] IAddGenreCommand command)
        {
            _commandHandler.HandleCommand(command, dto);
            return StatusCode(201);
        }

        // PUT api/<GenreController>/5
        [HttpPut("{id}")]
        public IActionResult UpdateGenre(int id, 
                                    [FromBody] UpdateGenreDto dto,
                                    [FromServices] IUpdateGenreCommand command)
        {
            dto.Id = id;
            _commandHandler.HandleCommand(command, dto);
            return Ok();
        }

        // DELETE api/<GenreController>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteGenre(int id,
                               [FromServices] IDeleteGenreCommand command)
        {
            _commandHandler.HandleCommand(command, id);
            return NoContent();
        }
    }
}
