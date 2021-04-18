using System.Threading;
using System.Threading.Tasks;
using Bookburn.Core.Repositories;
using MediatR;

namespace Bookburn.Backoffice.Features.Genre
{
    public class CreateGenreCommand : IRequest
    {
        public string Name { get; set; }
    }

    public class CreateGenreCommandHandler : AsyncRequestHandler<CreateGenreCommand>
    {
        private readonly IGenreRepository _genreRepository;

        public CreateGenreCommandHandler(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        protected override async Task Handle(CreateGenreCommand request, CancellationToken cancellationToken)
        {
            var genre = new Core.Models.Genre
            {
                Name = request.Name,
            };

            await _genreRepository.Add(genre, cancellationToken);
        }
    }
}