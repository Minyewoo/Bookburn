using System.Threading;
using System.Threading.Tasks;
using Bookburn.Core.Repositories;
using MediatR;

namespace Bookburn.Backoffice.Features.Role
{
    public class CreateRoleCommand : IRequest
    {
        public string Name { get; set; }
    }

    public class CreateRoleCommandHandler : AsyncRequestHandler<CreateRoleCommand>
    {
        private readonly IRoleRepository _roleRepository;

        public CreateRoleCommandHandler(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        protected override async Task Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            var role = new Core.Models.Role {Name = request.Name};
            await _roleRepository.Add(role, cancellationToken);
        }
    }
}