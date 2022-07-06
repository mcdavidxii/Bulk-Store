using Bulk_Book.Models;
using Microsoft.EntityFrameworkCore;

namespace Bulk_Book.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {
            
        }

        public DbSet<Category> categories { get; set; }

    }
}
