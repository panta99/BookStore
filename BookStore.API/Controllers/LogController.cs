using BookStore.Application;
using BookStore.Application.UseCaseHandling;
using BookStore.Application.UseCases.DTO;
using BookStore.Application.UseCases.Queries;
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
    public class LogController : ControllerBase
    {
        private ICommandHandler _commandHandler;
        private readonly IApplicationActor _actor;
        public LogController(ICommandHandler commandHandler, IApplicationActor actor)
        {
            _commandHandler = commandHandler;
            _actor = actor;
        }
        [HttpGet]
        public IActionResult SearchLog([FromQuery] SearchLogDto search,
                                       [FromServices] ISearchLogQuery query,
                                       [FromServices] IQueryHandler handler)
        {
            return Ok(handler.HandleQuery(query,search));
        }
    }
}
