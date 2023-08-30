using BookStore.Application;
using BookStore.Application.UseCaseHandling;
using BookStore.Application.UseCases.Commands.OrderC;
using BookStore.Application.UseCases.DTO.OrderDTOs;
using BookStore.Application.UseCases.Queries.OrderQ;
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
    public class OrderController : ControllerBase
    {
        private ICommandHandler _commandHandler;
        private readonly IApplicationActor _actor;
        public OrderController(ICommandHandler commandHandler, IApplicationActor actor)
        {
            _actor = actor;
            _commandHandler = commandHandler;
        }

        // GET api/<OrderController>/5
        [HttpGet]
        public IActionResult Get([FromQuery] GetOrderQuery dto,
                                 [FromServices] IGetOrderQuery query,
                                 [FromServices] IQueryHandler handler)
        {

            return Ok(handler.HandleQuery(query, dto));
        }

        // POST api/<OrderController>
        [HttpPost]
        public IActionResult CreateOrder([FromBody] CreateOrderDto dto,
                                         [FromServices] ICreateOrderCommand command)
        {
            _commandHandler.HandleCommand(command, dto);
            return StatusCode(201);
        }

        // PUT api/<OrderController>/5
        [HttpPut]
        public IActionResult UpdateOrderStatus([FromQuery] UpdateOrderDto dto,
                                               [FromServices] IUpdateOrderCommand command)
        {
            _commandHandler.HandleCommand(command, dto);
            return Ok();
        }

        // DELETE api/<OrderController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteOrderCommand command)
        {
            _commandHandler.HandleCommand(command, id);
            return NoContent();
        }
    }
}
