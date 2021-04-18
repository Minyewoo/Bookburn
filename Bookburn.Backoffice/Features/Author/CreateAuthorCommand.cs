using System.Threading;
using System.Threading.Tasks;
using Bookburn.Core.Repositories;
using MediatR;

namespace Bookburn.Backoffice.Features.Author
{
    public class CreateAuthorCommand : IRequest
    {
        public string Name { get; set; }
    }

    public class CreateAuthorCommandHandler : AsyncRequestHandler<CreateAuthorCommand>
    {
        private readonly IAuthorRepository _authorRepository;

        public CreateAuthorCommandHandler(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        protected override async Task Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
        {
            var author = new Core.Models.Author
            {
                Name = request.Name,
            };

            await _authorRepository.Add(author, cancellationToken);
        }
    }
}