using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace movieapplication.Model
{
    public class MovieActorId
    {
        [Key]
        public int Id { get; set; }

        public int MovieId { get; set; }
        public int ActorId { get; set; }
        public Movie Movies { get; set; }
        public Actor Actors { get; set; }


    }
}
