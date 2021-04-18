using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Bookburn.Core.Models;

namespace Bookburn.Core.Repositories
{
    public interface IBookRepository
    {
        Task<IReadOnlyCollection<Book>> Get(int? skip, int? count, CancellationToken cancellationToken);
        Task<Book> Find(long id, CancellationToken cancellationToken);
        Task Add(Book book, CancellationToken cancellationToken);
        Task Update(Book book, CancellationToken cancellationToken);
        Task Delete(Book book, CancellationToken cancellationToken);
    }
}