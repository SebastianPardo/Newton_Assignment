using Microsoft.EntityFrameworkCore;
using NewtonServices.Models.EntityModels;

namespace NewtonServices.Data
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options)
            : base(options)
        {
        }

        public DbSet<VideoGame> VideoGame { get; set; }
        public DbSet<Genre> Genre { get; set; }
        public DbSet<Platform> Platform { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Platform>().Property(e => e.Id).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<Platform>().Property(e => e.DateAdded).HasDefaultValueSql("SYSDATETIME()");

            modelBuilder.Entity<Genre>().Property(e => e.Id).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<Genre>().Property(e => e.DateAdded).HasDefaultValueSql("SYSDATETIME()");

            modelBuilder.Entity<VideoGame>().Property(e => e.Id).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<VideoGame>().Property(e => e.DateAdded).HasDefaultValueSql("SYSDATETIME()");
            modelBuilder.Entity<VideoGame>().Property(e => e.IsAvailable).HasDefaultValue(true);

            modelBuilder.Entity<Genre>()
                .HasMany(e => e.VideoGames)
                .WithOne(e => e.Genre)
                .HasForeignKey(e => e.GenreId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Platform>()
                .HasMany(e => e.VideoGames)
                .WithOne(e => e.Platform)
                .HasForeignKey(e => e.PlatformId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
