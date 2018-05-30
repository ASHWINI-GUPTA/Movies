using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Movies.Models
{
    public class Movie
    {
        public Movie()
        {
            ActorMovies = new Collection<ActorMovie>();
            //Actors = new List<Actor>();
        }

        public int MovieId { get; set; }

        [Required]
        [Display(Name = "Movie")]
        public string MovieName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Released { get; set; }

        [MaxLength(1000)]
        public string Plot { get; set; }

        [Display(Name = "Poster Image")]
        public string Poster { get; set; }

        public Producer Producer { get; set; }

        [Display(Name = "Producer")]
        public int ProducerId { get; set; }

        public ICollection<ActorMovie> ActorMovies { get; set; }

        //public List<Actor> Actors { get; set; }
    }
}