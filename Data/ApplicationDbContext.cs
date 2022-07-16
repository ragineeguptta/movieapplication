using Microsoft.EntityFrameworkCore;
using movieapplication.Model;

namespace movieapplication.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Actor> Actors { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieActorId> MoviesActorIds { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MovieActorId>()
                .HasKey(bc => new { bc.ActorId, bc.MovieId });
            modelBuilder.Entity<MovieActorId>()
                .HasOne(bc => bc.Actor)
                .WithMany(b => b.MoviesActorIds)
                .HasForeignKey(bc => bc.ActorId);
            modelBuilder.Entity<MovieActorId>()
                .HasOne(bc => bc.Movie)
                .WithMany(c => c.MoviesActorIds)
                .HasForeignKey(bc => bc.MovieId);
        }
    }
}
