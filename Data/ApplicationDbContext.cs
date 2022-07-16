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
    }
}
