using System;

namespace CSD.MovieRestServiceApplication.Entities
{
    public class Movie
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime SceneDate { get; set; }
        public long Rating { get; set; }
        public double Imdb { get; set; }
        public decimal Cost { get; set; }
    }
}
