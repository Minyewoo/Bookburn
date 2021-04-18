using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Bookburn.Core.Models;
using Bookburn.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Bookburn.Infrastructure.Repositories
{
    public class DatabaseUserRepository : IUserRepository
    {
        private readonly BookburnDbContext _context;

        public DatabaseUserRepository(BookburnDbContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyCollection<User>> Get(int? skip, int? count, CancellationToken cancellationToken)
        {
            return await _context.Users.Skip(skip ?? 0).Take(count ?? 10).ToListAsync(cancellationToken);
        }

        public async Task<User> Find(long id, CancellationToken cancellationToken)
        {
            return await _context.Users.SingleOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public async Task<User> FindByEmail(string email, CancellationToken cancellationToken)
        {
            return await _context.Users.SingleOrDefaultAsync(
                x => x.Email == email, cancellationToken);
        }

        public async Task<User> FindByPhoneNumber(string phoneNumber, CancellationToken cancellationToken)
        {
            return await _context.Users.SingleOrDefaultAsync(
                x => x.PhoneNumber == phoneNumber, cancellationToken);
        }

        public async Task<User> FindByEmailAndPassword(string email, string passwordHash,
            CancellationToken cancellationToken)
        {
            return await _context.Users.SingleOrDefaultAsync(
                x => x.Email == email && x.PasswordHash == passwordHash, cancellationToken);
        }

        public async Task<User> FindByPhoneNumberAndPassword(string phoneNumber, string passwordHash,
            CancellationToken cancellationToken)
        {
            return await _context.Users.SingleOrDefaultAsync(
                x => x.PhoneNumber == phoneNumber && x.PasswordHash == passwordHash, cancellationToken);
        }

        public async Task Add(User user, CancellationToken cancellationToken)
        {
            await _context.Users.AddAsync(user, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task Update(User user, CancellationToken cancellationToken)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task Delete(User user, CancellationToken cancellationToken)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}