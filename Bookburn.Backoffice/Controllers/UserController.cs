using System.Threading.Tasks;
using Bookburn.Backoffice.Features.User;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Bookburn.Backoffice.Controllers
{
    [Route("/api/user")]
    public class UserController : BackofficeBaseController
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserCommand command)
        {
            var result = await _mediator.Send(command, HttpContext.RequestAborted);
            return string.IsNullOrEmpty(result) ? (IActionResult) Ok() : BadRequest(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUser([FromBody] DeleteUserCommand command)
        {
            await _mediator.Send(command, HttpContext.RequestAborted);
            return Ok();
        }
    }
}