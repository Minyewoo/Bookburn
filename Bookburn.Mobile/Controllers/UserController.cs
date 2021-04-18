using System;
using System.Threading.Tasks;
using Bookburn.Mobile.Features.User;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Bookburn.Mobile.Controllers
{
    [Route("/api/user")]
    public class UserController : MobileBaseController
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetUser([FromQuery] GetUserQuery query)
        {
            try
            {
                var user = await _mediator.Send(query, this.HttpContext.RequestAborted);
                return Ok(user);
            }
            catch (GetUserQueryException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("token")]
        public async Task<IActionResult> GetToken([FromQuery] GetTokenQuery query)
        {
            try
            {
                var token = await _mediator.Send(query, this.HttpContext.RequestAborted);
                return Ok(token);
            }
            catch (GetTokenQueryException e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}