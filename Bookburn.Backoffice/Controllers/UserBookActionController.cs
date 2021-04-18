using System.Threading.Tasks;
using Bookburn.Backoffice.Features.UserBookAction;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Bookburn.Backoffice.Controllers
{
    [Route("/api/action")]
    public class UserBookActionController : BackofficeBaseController
    {
        private readonly IMediator _mediator;

        public UserBookActionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateAction([FromBody] CreateUserBookActionCommand command)
        {
            await _mediator.Send(command, HttpContext.RequestAborted);
            return Ok();
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteAction([FromBody] DeleteUserBookActionCommand command)
        {
            await _mediator.Send(command, HttpContext.RequestAborted);
            return Ok();
        }
    }
}