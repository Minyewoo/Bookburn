using System.Threading.Tasks;
using Bookburn.Backoffice.Features.Author;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Bookburn.Backoffice.Controllers
{
    [Route("/api/author")]
    public class AuthorController : BackofficeBaseController
    {
        private readonly IMediator _mediator;

        public AuthorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateAuthor([FromBody] CreateAuthorCommand command)
        {
            await _mediator.Send(command, HttpContext.RequestAborted);
            return Ok();
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteAuthor([FromBody] DeleteAuthorCommand command)
        {
            await _mediator.Send(command, HttpContext.RequestAborted);
            return Ok();
        }
    }
}