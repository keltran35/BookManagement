using BookManagement.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookManagement.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Book> Books { get; set; }
    }
}
