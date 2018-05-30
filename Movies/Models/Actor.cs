using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Movies.Models
{
    public class Actor
    {
        public Actor()
        {
            ActorMovies = new Collection<ActorMovie>();
        }

        public int ActorId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Sex { get; set; }

        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }

        [MaxLength(500)]
        public string Bio { get; set; }

        public ICollection<ActorMovie> ActorMovies { get; set; }
    }
}