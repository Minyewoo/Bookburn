using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Bookburn.Core.Models;
using Bookburn.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Bookburn.Infrastructure.Repositories
{
    public class DatabaseAuthorRepository : IAuthorRepository
    {
        private readonly BookburnDbContext _context;

        public DatabaseAuthorRepository(BookburnDbContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyCollection<Author>> Get(int? skip, int? count, CancellationToken cancellationToken)
        {
            return await _context.Authors.Skip(skip ?? 0).Take(count ?? 10).ToListAsync(cancellationToken);
        }

        public async Task<Author> Find(long id, CancellationToken cancellationToken)
        {
            return await _context.Authors.SingleOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public async Task Add(Author author, CancellationToken cancellationToken)
        {
            await _context.Authors.AddAsync(author, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task Update(Author author, CancellationToken cancellationToken)
        {
            _context.Authors.Update(author);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task Delete(Author author, CancellationToken cancellationToken)
        {
            _context.Authors.Remove(author);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}