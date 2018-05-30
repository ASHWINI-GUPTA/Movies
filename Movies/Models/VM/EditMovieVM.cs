using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Models.VM
{
    public class EditMovieVM
    {
        public int ActorId { get; set; }

        public string Name { get; set; }

        public bool InMovie { get; set; }
    }
}
