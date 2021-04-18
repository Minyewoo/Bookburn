using System.Threading.Tasks;
using Bookburn.Mobile.Features.Book;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Bookburn.Mobile.Controllers
{
    [Route("/api/book")]
    public class BookController : MobileBaseController
    {
        private readonly IMediator _mediator;

        public BookController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("getList")]
        public async Task<IActionResult> GetBookList([FromQuery] GetBookListQuery query)
        {
            var books = await _mediator.Send(query, this.HttpContext.RequestAborted);
            return Ok(books);
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetBook([FromQuery] GetBookQuery query)
        {
            var book = await _mediator.Send(query, this.HttpContext.RequestAborted);
            return Ok(book);
        }
    }
}