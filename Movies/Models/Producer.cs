using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Movies.Models
{
    public class Producer
    {
        public Producer()
        {
            Movies = new Collection<Movie>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Sex { get; set; }

        public string Bio { get; set; }

        public ICollection<Movie> Movies { get; set; }
    }
}