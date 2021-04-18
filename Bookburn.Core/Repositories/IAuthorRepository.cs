using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Bookburn.Core.Models;

namespace Bookburn.Core.Repositories
{
    public interface IAuthorRepository
    {
        Task<IReadOnlyCollection<Author>> Get(int? skip, int? count, CancellationToken cancellationToken);
        Task<Author> Find(long id, CancellationToken cancellationToken);
        Task Add(Author author, CancellationToken cancellationToken);
        Task Update(Author author, CancellationToken cancellationToken);
        Task Delete(Author author, CancellationToken cancellationToken);
    }
}