using BookStore.Application;
using BookStore.Application.UseCaseHandling;
using BookStore.Application.UseCases.Commands.PublisherC;
using BookStore.Application.UseCases.DTO.PublisherDTOs;
using BookStore.Application.UseCases.Queries.PublisherQ;
using BookStore.Application.UseCases.Queries.Searches;
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
    public class PublisherController : ControllerBase
    {
        private ICommandHandler _commandHandler;
        private readonly IApplicationActor _actor;
        public PublisherController(ICommandHandler commandHandler, IApplicationActor actor)
        {
            _actor = actor;
            _commandHandler = commandHandler;
        }

        // GET api/<PublisherController>/5
        [HttpGet]
        public IActionResult GetPublishers([FromQuery] PublisherSearch search,
                                           [FromServices] IGetPublishersQuery query,
                                           [FromServices] IQueryHandler handler)
        {
            return Ok(handler.HandleQuery(query, search));
        }

        // POST api/<PublisherController>
        [HttpPost]
        public IActionResult AddPublisher([FromBody] AddPublisherDto dto,
                                          [FromServices] IAddPublisherCommand command)
        {
            _commandHandler.HandleCommand(command, dto);
            return StatusCode(201);
        }

        // PUT api/<PublisherController>/5
        [HttpPut("{id}")]
        public IActionResult UpdatePublisher(int id, [FromBody] UpdatePublisherDto dto,
                                                     [FromServices] IUpdatePublisherCommand command)
        {
            dto.Id = id;
            _commandHandler.HandleCommand(command, dto);
            return Ok();
        }

        // DELETE api/<PublisherController>/5
        [HttpDelete("{id}")]
        public IActionResult DeletePublisher(int id,
                                             [FromServices] IDeletePublisherCommand command)
        {
            _commandHandler.HandleCommand(command, id);
            return NoContent();
        }
    }
}
