using Microsoft.EntityFrameworkCore;
using provimAPI.Models;

namespace provimAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Afati> Afatet { get; set; }
    }
}
