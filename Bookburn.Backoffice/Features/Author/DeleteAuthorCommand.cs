using System.Threading;
using System.Threading.Tasks;
using Bookburn.Core.Repositories;
using MediatR;

namespace Bookburn.Backoffice.Features.Author
{
    public class DeleteAuthorCommand : IRequest
    {
        public Core.Models.Author Author { get; set; }
    }

    public class DeleteAuthorCommandHandler : AsyncRequestHandler<DeleteAuthorCommand>
    {
        private readonly IAuthorRepository _authorRepository;

        public DeleteAuthorCommandHandler(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        protected override async Task Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
        {
            await _authorRepository.Delete(request.Author, cancellationToken);
        }
    }
}