using System;
using System.Threading;
using System.Threading.Tasks;
using Bookburn.Core.Repositories;
using MediatR;

namespace Bookburn.Backoffice.Features.UserBookAction
{
    public class CreateUserBookActionCommand : IRequest
    {
        public long UserId { get; set; }
        public long BookId { get; set; }
        public Core.Models.UserBookAction.ActionType Type { get; set; }
    }

    public class CreateUserBookActionCommandHandler : AsyncRequestHandler<CreateUserBookActionCommand>
    {
        private readonly IUserBookActionRepository _userBookActionRepository;
        private readonly IUserRepository _userRepository;
        private readonly IBookRepository _bookRepository;

        public CreateUserBookActionCommandHandler(IUserBookActionRepository userBookActionRepository,
            IUserRepository userRepository, IBookRepository bookRepository)
        {
            _userBookActionRepository = userBookActionRepository;
            _userRepository = userRepository;
            _bookRepository = bookRepository;
        }

        protected override async Task Handle(CreateUserBookActionCommand request, CancellationToken cancellationToken)
        {
            var action = new Core.Models.UserBookAction
            {
                Type = request.Type,
                Time = DateTime.Now,
                Book = await _bookRepository.Find(request.BookId, cancellationToken),
                User = await _userRepository.Find(request.UserId, cancellationToken),
            };

            await _userBookActionRepository.Add(action, cancellationToken);
        }
    }
}