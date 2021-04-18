using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Bookburn.Core.Repositories;
using MediatR;

namespace Bookburn.Backoffice.Features.Book
{
    public class CreateBookCommand : IRequest
    {
        public string Isbn { get; set; }
        public string Name { get; set; }
        public int PageCount { get; set; }
        public string CoverPath { get; set; }
        public DateTime PublicationDate { get; set; }
        public string Description { get; set; }
        public bool HaveHardCover { get; set; }
        public ICollection<string> Authors { get; set; }
        public ICollection<string> Genres { get; set; }
    }

    public class CreateBookCommandHandler : AsyncRequestHandler<CreateBookCommand>
    {
        private readonly IBookRepository _bookRepository;
        public CreateBookCommandHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }


        protected override async Task Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var book = new Core.Models.Book
            {
                Isbn = request.Isbn,
                Name = request.Name,
                PageCount = request.PageCount,
                CoverPath = request.CoverPath,
                PublicationDate = request.PublicationDate,
                Description = request.Description,
                HaveHardCover = request.HaveHardCover,
            };

            await _bookRepository.Add(book, cancellationToken);
        }
    }
}