using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Bookburn.Core.Models;

namespace Bookburn.Core.Repositories
{
    public interface IGenreRepository
    {
        Task<IReadOnlyCollection<Genre>> Get(int? skip, int? count, CancellationToken cancellationToken);
        Task<Genre> Find(long id, CancellationToken cancellationToken);
        Task Add(Genre genre, CancellationToken cancellationToken);
        Task Update(Genre genre, CancellationToken cancellationToken);
        Task Delete(Genre genre, CancellationToken cancellationToken);
    }
}