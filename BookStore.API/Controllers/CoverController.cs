using BookStore.Application;
using BookStore.Application.UseCaseHandling;
using BookStore.Application.UseCases.Commands.CoverC;
using BookStore.Application.UseCases.DTO.CoverDTOs;
using BookStore.Application.UseCases.Queries.CoverQ;
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
    public class CoverController : ControllerBase
    {
        private BookStoreContext _context;
        private ICommandHandler _commandHandler;
        private readonly IApplicationActor _actor;
        public CoverController(BookStoreContext context, ICommandHandler commandHandler, IApplicationActor actor)
        {
            _actor = actor;
            _commandHandler = commandHandler;
            _context = context;
        }

        // GET api/<CoverController>/5
        [HttpGet]
        public IActionResult GetCovers([FromQuery] CoverSearch search,
                                       [FromServices] IGetCoversQuery query,
                                       [FromServices] IQueryHandler handler)
        {
            return Ok(handler.HandleQuery(query, search));
        }

        // POST api/<CoverController>
        [HttpPost]
        public IActionResult AddCover([FromBody] AddCoverDto dto,
                         [FromServices] IAddCoverCommand command)
        {
            _commandHandler.HandleCommand(command, dto);
            return StatusCode(201);
        }

        // PUT api/<CoverController>/5
        [HttpPut("{id}")]
        public IActionResult UpdateCover(int id, 
                                        [FromBody] UpdateCoverDto dto,
                                        [FromServices] IUpdateCoverCommand command)
        {
            dto.Id = id;
            _commandHandler.HandleCommand(command, dto);
            return Ok();
        }

        // DELETE api/<CoverController>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteCover(int id,
                                         [FromServices] IDeleteCoverCommand command)
        {
            _commandHandler.HandleCommand(command, id);
            return NoContent();
        }
    }
}
