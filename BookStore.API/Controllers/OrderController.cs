using BookStore.Application.UseCaseHandling;
using BookStore.Application.UseCases.Commands.OrderC;
using BookStore.Application.UseCases.DTO.OrderDTOs;
using BookStore.Application.UseCases.Queries.OrderQ;
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
    public class OrderController : ControllerBase
    {
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
            command.Execute(dto);
            return StatusCode(201);
        }

        // PUT api/<OrderController>/5
        [HttpPut]
        public IActionResult UpdateOrderStatus([FromQuery] UpdateOrderDto dto,
                                               [FromServices] IUpdateOrderCommand command)
        {
            command.Execute(dto);
            return Ok();
        }

        // DELETE api/<OrderController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteOrderCommand command)
        {
            command.Execute(id);
            return NoContent();
        }
    }
}
