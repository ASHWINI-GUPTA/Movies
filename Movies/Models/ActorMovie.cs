using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Movies.Models
{
    public class ActorMovie
    {
        [Column(Order = 1)]
        public int MovieId { get; set; }
        public Movie Movie { get; set; }

        [Column(Order = 2)]
        public int ActorId { get; set; }
        public Actor Actor { get; set; }
    }
}
