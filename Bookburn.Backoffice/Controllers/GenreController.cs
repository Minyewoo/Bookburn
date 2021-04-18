using System.Threading.Tasks;
using Bookburn.Backoffice.Features.Genre;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Bookburn.Backoffice.Controllers
{
    [Route("/api/genre")]
    public class GenreController : BackofficeBaseController
    {
        private readonly IMediator _mediator;

        public GenreController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateGenre([FromBody] CreateGenreCommand command)
        {
            await _mediator.Send(command, HttpContext.RequestAborted);
            return Ok();
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteGenre([FromBody] DeleteGenreCommand command)
        {
            await _mediator.Send(command, HttpContext.RequestAborted);
            return Ok();
        }
    }
}