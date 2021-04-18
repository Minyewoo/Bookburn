using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Bookburn.Core.Repositories;
using Bookburn.Mobile.Api.DTOs;
using MediatR;

namespace Bookburn.Mobile.Features.Book
{
    public class GetBookListQuery : IRequest<BookListDto>
    {
        public int? Count { get; set; }
        public int? Skip { get; set; }
    }

    public class GetBookListQueryHandler : IRequestHandler<GetBookListQuery, BookListDto>
    {
        private readonly IBookRepository _bookRepository;

        public GetBookListQueryHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<BookListDto> Handle(GetBookListQuery request, CancellationToken cancellationToken)
        {
            var books = await _bookRepository.Get(request.Skip, request.Count, cancellationToken);
            var bookListDto = new BookListDto();

            bookListDto.Items = books.Select(x => new BookListDto.BookListItemDto
            {
                Id = x.Id, Name = x.Name, CoverPath = x.CoverPath,
                Authors = x.Authors.Select(y => new AuthorDto {Id = y.Id, Name = y.Name}).ToArray()
            }).ToArray();

            return bookListDto;
        }
    }
}