using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace movieapplication.Model
{
    public class MovieActorId
    {
        public int MovieId { get; set; }
        public int ActorId { get; set; }

        public Movie Movie { get; set; }
        public Actor Actor { get; set; }
    }
}
