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
            modelBuilder.Entity<MovieActorId>().HasKey(pc => new { pc.MovieId, pc.ActorId });
            modelBuilder.Entity<MovieActorId>()
                .HasOne(p => p.Movie)
                .WithMany(pc => pc.MoviesActorIds)
                .HasForeignKey(pc => pc.ActorId);

        }
    }
}
