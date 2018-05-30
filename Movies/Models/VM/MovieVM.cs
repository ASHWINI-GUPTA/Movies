using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Models.VM
{
    public class MovieVM
    {
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

        public int ProducerId { get; set; }
    }
}
