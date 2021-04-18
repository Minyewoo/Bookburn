using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Bookburn.Core.Models;

namespace Bookburn.Core.Repositories
{
    public interface IRoleRepository
    {
        Task<IReadOnlyCollection<Role>> Get(int? skip, int? count, CancellationToken cancellationToken);
        Task<Role> Find(long id, CancellationToken cancellationToken);
        Task Add(Role role, CancellationToken cancellationToken);
        Task Update(Role role, CancellationToken cancellationToken);
        Task Delete(Role role, CancellationToken cancellationToken);
    }
}