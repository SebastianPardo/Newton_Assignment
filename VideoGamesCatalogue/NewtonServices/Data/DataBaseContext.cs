using Microsoft.EntityFrameworkCore;
using NewtonServices.Models.Entities;
using NewtonServices.Models.Views;

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

        //Views
        public DbSet<VwAllVideoGames> VwAllVideoGames { get; set; }
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

            modelBuilder.Entity<VwAllVideoGames>(vw =>
            {
                vw.ToView("VwAllVideoGames");
            });

#if DEBUG
            modelBuilder.Entity<Genre>().HasData(
                new Genre { Id = Guid.Parse("690ddf28-b89d-4d73-845a-61a3fe97d231"), Code = "SPO", Name = "Sport" },
                new Genre { Id = Guid.Parse("38c82dc7-0baa-4981-b620-841fc7d4076a"), Code = "ACT", Name = "Action" },
                new Genre { Id = Guid.Parse("ac0a73cb-b745-4889-86db-8bd5a0712cd3"), Code = "SHT", Name = "Shooter" },
                new Genre { Id = Guid.Parse("b7fd6b7d-b307-404a-94ac-c908359adbe0"), Code = "ADV", Name = "Adventure" }
            );

            // Plataformas
            modelBuilder.Entity<Platform>().HasData(
                new Platform {Id = Guid.Parse("0c85b57f-643c-4176-9e1b-48a17d03ea7e"),Code="PS", Name = "PlayStation" },
                new Platform {Id = Guid.Parse("55bd7dd8-c9f1-4745-a7a6-c4509a82be67"),Code="XBX", Name = "Xbox" },
                new Platform {Id = Guid.Parse("3c8ccba5-b0d7-45cd-8072-c5876f0593dc"),Code="PC", Name = "PC" }
            );

            // Video Games
            modelBuilder.Entity<VideoGame>().HasData(
                new VideoGame
                {
                    Title = "Game 1",
                    Price = 59.99m,
                    GenreId = Guid.Parse("690ddf28-b89d-4d73-845a-61a3fe97d231"),
                    PlatformId = Guid.Parse("0c85b57f-643c-4176-9e1b-48a17d03ea7e"),
                    Quantity = 10,
                },
                new VideoGame
                {
                    Title = "Game 2",
                    Price = 49.99m,
                    GenreId = Guid.Parse("38c82dc7-0baa-4981-b620-841fc7d4076a"),
                    PlatformId = Guid.Parse("55bd7dd8-c9f1-4745-a7a6-c4509a82be67"),
                    Quantity = 10,
                },
                new VideoGame
                {
                    Title = "Game 3",
                    Price = 69.99m,
                    GenreId = Guid.Parse("b7fd6b7d-b307-404a-94ac-c908359adbe0"),
                    PlatformId = Guid.Parse("3c8ccba5-b0d7-45cd-8072-c5876f0593dc"),
                    Quantity = 10,
                },
                new VideoGame
                {
                    Title = "Game 4",
                    Price = 69.99m,
                    GenreId = Guid.Parse("690ddf28-b89d-4d73-845a-61a3fe97d231"),
                    PlatformId = Guid.Parse("0c85b57f-643c-4176-9e1b-48a17d03ea7e"),
                    Quantity = 10,
                },
                new VideoGame
                {
                    Title = "Game 5",
                    Price = 69.99m,
                    GenreId = Guid.Parse("b7fd6b7d-b307-404a-94ac-c908359adbe0"),
                    PlatformId = Guid.Parse("3c8ccba5-b0d7-45cd-8072-c5876f0593dc"),
                    Quantity = 10,
                }
            );
#endif
        }
    }
}
