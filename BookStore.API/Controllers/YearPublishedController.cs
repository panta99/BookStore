using BookStore.Application.UseCaseHandling;
using BookStore.Application.UseCases.Commands.YearPublishedC;
using BookStore.Application.UseCases.Queries.YearPublishedQ;
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
    public class YearPublishedController : ControllerBase
    {
        // GET api/<YearController>/5
        [HttpGet]
        public IActionResult GetYears(int? id,
                                      [FromServices] IGetYearPublishedQuery query,
                                      [FromServices] IQueryHandler handler)
        {
            return Ok(handler.HandleQuery(query, id));
        }

        // POST api/<YearController>
        [HttpPost]
        public IActionResult AddYear([FromQuery] int year,
                                     [FromServices] IAddYearPublishedCommand command)
        {
            command.Execute(year);
            return StatusCode(201);
        }
    }
}
