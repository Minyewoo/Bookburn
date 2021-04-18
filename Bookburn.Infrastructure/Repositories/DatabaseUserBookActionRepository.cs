using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Bookburn.Core.Models;
using Bookburn.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Bookburn.Infrastructure.Repositories
{
    public class DatabaseUserBookActionRepository : IUserBookActionRepository
    {
        private readonly BookburnDbContext _context;

        public DatabaseUserBookActionRepository(BookburnDbContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyCollection<UserBookAction>> Get(int? skip, int? count, CancellationToken cancellationToken)
        {
            return await _context.UserBookActions.Skip(skip ?? 0).Take(count ?? 10).ToListAsync(cancellationToken);
        }

        public async Task<UserBookAction> Find(string id, CancellationToken cancellationToken)
        {
            return await _context.UserBookActions.SingleOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public async Task Add(UserBookAction userBookAction, CancellationToken cancellationToken)
        {
            userBookAction.Id = Guid.NewGuid().ToString();
            await _context.UserBookActions.AddAsync(userBookAction, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task Update(UserBookAction userBookAction, CancellationToken cancellationToken)
        {
            _context.UserBookActions.Update(userBookAction);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task Delete(UserBookAction userBookAction, CancellationToken cancellationToken)
        {
            _context.UserBookActions.Remove(userBookAction);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}