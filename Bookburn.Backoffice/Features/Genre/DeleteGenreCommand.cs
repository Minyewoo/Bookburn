using System.Threading;
using System.Threading.Tasks;
using Bookburn.Core.Repositories;
using MediatR;

namespace Bookburn.Backoffice.Features.Genre
{
    public class DeleteGenreCommand : IRequest
    {
        public Core.Models.Genre Genre { get; set; }
    }

    public class DeleteGenreCommandHandler : AsyncRequestHandler<DeleteGenreCommand>
    {
        private readonly IGenreRepository _genreRepository;

        public DeleteGenreCommandHandler(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        protected override async Task Handle(DeleteGenreCommand request, CancellationToken cancellationToken)
        {
            await _genreRepository.Delete(request.Genre, cancellationToken);
        }
    }
}