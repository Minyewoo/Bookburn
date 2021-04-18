using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Bookburn.Core.Models;

namespace Bookburn.Core.Repositories
{
    public interface IUserBookActionRepository
    {
        Task<IReadOnlyCollection<UserBookAction>> Get(int? skip, int? count, CancellationToken cancellationToken);
        Task<UserBookAction> Find(string id, CancellationToken cancellationToken);
        Task Add(UserBookAction action, CancellationToken cancellationToken);
        Task Update(UserBookAction action, CancellationToken cancellationToken);
        Task Delete(UserBookAction action, CancellationToken cancellationToken);
    }
}