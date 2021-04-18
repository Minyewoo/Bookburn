using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Bookburn.Core.Models;
using Bookburn.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Bookburn.Infrastructure.Repositories
{
    public class DatabaseRoleRepository : IRoleRepository
    {
        private readonly BookburnDbContext _context;

        public DatabaseRoleRepository(BookburnDbContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyCollection<Role>> Get(int? skip, int? count, CancellationToken cancellationToken)
        {
            return await _context.Roles.Skip(skip ?? 0).Take(count ?? 10).ToListAsync(cancellationToken);
        }

        public async Task<Role> Find(long id, CancellationToken cancellationToken)
        {
            return await _context.Roles.SingleOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public async Task Add(Role role, CancellationToken cancellationToken)
        {
            await _context.Roles.AddAsync(role, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task Update(Role role, CancellationToken cancellationToken)
        {
            _context.Roles.Update(role);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task Delete(Role role, CancellationToken cancellationToken)
        {
            _context.Roles.Remove(role);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}