using System.Threading;
using System.Threading.Tasks;
using Bookburn.Core.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Bookburn.Backoffice.Features.Role
{
    public class DeleteRoleCommand : IRequest
    {
        public Core.Models.Role Role { get; set; }
    }

    public class DeleteRoleCommandHandler : AsyncRequestHandler<DeleteRoleCommand>
    {
        private readonly IRoleRepository _roleRepository;

        public DeleteRoleCommandHandler(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        protected override async Task Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
        {
            await _roleRepository.Delete(request.Role, cancellationToken);
        }
    }
}