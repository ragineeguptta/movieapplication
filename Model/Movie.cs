using System.ComponentModel.DataAnnotations;

namespace movieapplication.Model
{
    public class Movie
    {
        [Key]
        public int MovieId { get; set; }
        public string MovieName { get; set; }
        public string ProducerName { get; set; }
        public DateTime DateofRelease { get; set; }

        public ICollection<MovieActorId> MoviesActorIds { get; set; }
    }
}
