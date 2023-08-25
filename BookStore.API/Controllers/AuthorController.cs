using BookStore.Application.Searches;
using BookStore.Application.UseCaseHandling;
using BookStore.Application.UseCases.Commands;
using BookStore.Application.UseCases.Commands.AuthorC;
using BookStore.Application.UseCases.DTO;
using BookStore.Application.UseCases.DTO.AuthorDTOs;
using BookStore.Application.UseCases.Queries;
using BookStore.DataAccess;
using Microsoft.AspNetCore.Http;
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
    public class AuthorController : ControllerBase
    {
        private BookStoreContext _context;
        public AuthorController(BookStoreContext context)
        {
            _context = context;
        }
        // GET: api/<AuthorController>
        //[HttpGet]
        //public IActionResult Get()
        //{
        //    return Ok();
        //}

        // GET api/<AuthorController>/5
        [HttpGet]
        public IActionResult GetAuthors([FromQuery] AuthorSearch search,
                          [FromServices] IGetAuthorsQuery query,
                          [FromServices] IQueryHandler handler)
        {
            return Ok(handler.HandleQuery(query, search));
        }

        // POST api/<AuthorController>
        [HttpPost]
        public IActionResult AddAuthor([FromBody] AddAuthorDto dto,
                                  [FromServices] IAddAuthorCommand command)
        {
            command.Execute(dto);
            return StatusCode(201);
        }

        // PUT api/<AuthorController>/5
        [HttpPut("{id}")]
        public IActionResult UpdateAuthor(int id, [FromBody] UpdateAuthorDto dto,
                                         [FromServices] IUpdateAuthorCommand command)
        {
            dto.Id = id;
            command.Execute(dto);
            return Ok();
        }

        // DELETE api/<AuthorController>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteAuthor(int id,[FromServices] IDeleteAuthorCommand command)
        {
            command.Execute(id);
            return NoContent();
        }
    }
}
