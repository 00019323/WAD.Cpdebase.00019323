using Microsoft.EntityFrameworkCore;
using WAD.Codebase._00019323.Models;

namespace WAD.Codebase._00019323.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Newspaper> Newspapers { get; set; }
        public DbSet<Article> Articles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure relationships, if needed
            modelBuilder.Entity<Newspaper>()
                .HasMany(n => n.Articles)
                .WithOne(a => a.Newspaper)
                .HasForeignKey(a => a.NewspaperId);
        }
    }
}
