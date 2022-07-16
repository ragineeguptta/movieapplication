using System.ComponentModel.DataAnnotations;

namespace movieapplication.Model
{
    public class Actor
    {
        [Key]
        public int ActorId { get; set; }
        public string ActorName { get; set; }

        public ICollection<MovieActorId> MoviesActorIds { get; set; }

    }
}
