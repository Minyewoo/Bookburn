using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Bookburn.Core.Repositories;
using Bookburn.Mobile.Api.DTOs;
using MediatR;

namespace Bookburn.Mobile.Features.Book
{
    public class GetBookQuery : IRequest<BookDto>
    {
        public long Id { get; set; }
    }

    public class GetBookQueryHandler : IRequestHandler<GetBookQuery, BookDto>
    {
        private readonly IBookRepository _bookRepository;

        public GetBookQueryHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<BookDto> Handle(GetBookQuery request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.Find(request.Id, cancellationToken);
            return new BookDto
            {
                Id = book.Id,
                Isbn = book.Isbn,
                Name = book.Name,
                PageCount = book.PageCount,
                Description = book.Description,
                HaveHardCover = book.HaveHardCover,
                PublicationDate = book.PublicationDate,
                CoverPath = book.CoverPath,
                Authors = book.Authors.Select(x => new AuthorDto {Id = x.Id, Name = x.Name}).ToArray(),
                Genres = book.Genres.Select(x => new GenreDto {Id = x.Id, Name = x.Name}).ToArray(),
            };
        }
    }
}