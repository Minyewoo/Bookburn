using Bookburn.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Bookburn.Infrastructure.Repositories
{
    public class BookburnDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<UserBookAction> UserBookActions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(
                "Host=localhost;Port=5432;Database=bookburn;Username=postgres;Password=password");
        }
    }
}
