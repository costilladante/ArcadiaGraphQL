using Arcadia.Repository.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Arcadia.Repository
{
    public class ArcadiaContext : DbContext
    {
        public ArcadiaContext(DbContextOptions options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Hero> Heroes { get; set; }
        public DbSet<Game> Games{ get; set; }
        public DbSet<HeroGame> HeroGames { get; set; }
        public DbSet<Company> Companies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>().HasKey(c => c.Id);
            modelBuilder.Entity<Company>().Property(c => c.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<Game>().HasKey(g => g.Id);
            modelBuilder.Entity<Game>().Property(g => g.Id).ValueGeneratedNever();
            modelBuilder.Entity<Hero>().HasKey(h => h.Id);
            modelBuilder.Entity<Hero>().Property(h => h.Id).ValueGeneratedNever();

            modelBuilder.Entity<HeroGame>().HasKey(hg => new { hg.HeroId, hg.GameId });
            modelBuilder.Entity<HeroGame>()
                .HasOne(hg => hg.Hero)
                .WithMany(h => h.Games)
                .HasForeignKey(hg => hg.HeroId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<HeroGame>()
                .HasOne(hg => hg.Game)
                .WithMany(g => g.Heroes)
                .HasForeignKey(hg => hg.GameId)
                .OnDelete(DeleteBehavior.Restrict);
            base.OnModelCreating(modelBuilder);
        }
    }
}
