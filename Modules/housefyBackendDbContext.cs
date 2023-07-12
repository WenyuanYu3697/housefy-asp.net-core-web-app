using housefyBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace housefyBackend.Data
{
    public class housefyBackendDbContext : DbContext
    {
        public housefyBackendDbContext(DbContextOptions<housefyBackendDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("user_info");
            modelBuilder.Entity<Feedback>().ToTable("user_feedback");
        }
    }
}
