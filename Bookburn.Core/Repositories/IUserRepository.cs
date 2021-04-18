using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Bookburn.Core.Models;

namespace Bookburn.Core.Repositories
{
    public interface IUserRepository
    {
        Task<IReadOnlyCollection<User>> Get(int? skip, int? count, CancellationToken cancellationToken);
        Task<User> Find(long id, CancellationToken cancellationToken);
        Task<User> FindByEmail(string email, CancellationToken cancellationToken);
        Task<User> FindByPhoneNumber(string phoneNumber, CancellationToken cancellationToken);
        Task<User> FindByEmailAndPassword(string email, string passwordHash, CancellationToken cancellationToken);
        Task<User> FindByPhoneNumberAndPassword(string phoneNumber, string passwordHash, CancellationToken cancellationToken);
        Task Add(User user, CancellationToken cancellationToken);
        Task Update(User user, CancellationToken cancellationToken);
        Task Delete(User user, CancellationToken cancellationToken);
    }
}