using System.Threading;
using System.Threading.Tasks;
using Bookburn.Core.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Bookburn.Backoffice.Features.UserBookAction
{
    public class DeleteUserBookActionCommand : IRequest
    {
        [FromBody] public Core.Models.UserBookAction Action { get; set; }
    }

    public class DeleteUserBookActionCommandHandler : AsyncRequestHandler<DeleteUserBookActionCommand>
    {
        private readonly IUserBookActionRepository _userBookActionRepository;

        public DeleteUserBookActionCommandHandler(IUserBookActionRepository userBookActionRepository)
        {
            _userBookActionRepository = userBookActionRepository;
        }

        protected override async Task Handle(DeleteUserBookActionCommand request, CancellationToken cancellationToken)
        {
            await _userBookActionRepository.Delete(request.Action, cancellationToken);
        }
    }
}