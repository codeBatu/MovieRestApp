using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieRestApp.Entity
{
    public class MovieToDirector
    {
        public int Id { get; set; }
        public int DirectorId { get; set; }
        public int MovieId { get; set; }
    }
}
