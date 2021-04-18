using System.Threading;
using System.Threading.Tasks;
using Bookburn.Core.Repositories;
using MediatR;

namespace Bookburn.Backoffice.Features.Book
{
    public class DeleteBookCommand : IRequest
    {
        public Core.Models.Book Book { get; set; }
    }

    public class DeleteBookCommandHandler : AsyncRequestHandler<DeleteBookCommand>
    {
        private readonly IBookRepository _bookRepository;

        public DeleteBookCommandHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }


        protected override async Task Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            await _bookRepository.Delete(request.Book, cancellationToken);
        }
    }
}