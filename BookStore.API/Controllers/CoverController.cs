using BookStore.Application.UseCaseHandling;
using BookStore.Application.UseCases.Commands.CoverC;
using BookStore.Application.UseCases.DTO.CoverDTOs;
using BookStore.Application.UseCases.Queries.CoverQ;
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
    public class CoverController : ControllerBase
    {
        private BookStoreContext _context;
        public CoverController(BookStoreContext context)
        {
            _context = context;
        }

        // GET api/<CoverController>/5
        [HttpGet]
        public IActionResult GetCovers([FromQuery] CoverSearch search,
                                       [FromServices] IGetCoverQuery query,
                                       [FromServices] IQueryHandler handler)
        {
            return Ok(handler.HandleQuery(query, search));
        }

        // POST api/<CoverController>
        [HttpPost]
        public IActionResult Post([FromBody] AddCoverDto dto,
                         [FromServices] IAddCoverCommand command)
        {
            command.Execute(dto);
            return StatusCode(201);
        }

        // PUT api/<CoverController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CoverController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
