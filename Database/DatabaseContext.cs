using Microsoft.EntityFrameworkCore;
using firebase.Models;

namespace firebase.Database
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Room>? room { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Room>()
            .HasKey(p => new { p.index });
        }
    }
}