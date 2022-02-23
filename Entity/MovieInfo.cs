using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieRestApp.Entity
{
    public class MovieInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime SceneDateTime { get; set; }
        public decimal Rating { get; set; }
        public decimal Imdb { get; set; }
        public decimal Cost { get; set; }
    }
}
