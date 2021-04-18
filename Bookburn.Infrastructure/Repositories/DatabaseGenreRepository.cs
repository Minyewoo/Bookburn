using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Bookburn.Core.Models;
using Bookburn.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Bookburn.Infrastructure.Repositories
{
    public class DatabaseGenreRepository : IGenreRepository
    {
        private readonly BookburnDbContext _context;

        public DatabaseGenreRepository(BookburnDbContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyCollection<Genre>> Get(int? skip, int? count, CancellationToken cancellationToken)
        {
            return await _context.Genres.Skip(skip ?? 0).Take(count ?? 10).ToListAsync(cancellationToken);
        }

        public async Task<Genre> Find(long id, CancellationToken cancellationToken)
        {
            return await _context.Genres.SingleOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public async Task Add(Genre genre, CancellationToken cancellationToken)
        {
            await _context.Genres.AddAsync(genre, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task Update(Genre genre, CancellationToken cancellationToken)
        {
            _context.Genres.Update(genre);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task Delete(Genre genre, CancellationToken cancellationToken)
        {
            _context.Genres.Remove(genre);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}