using System;
using System.Collections.Generic;

#nullable disable

namespace CSD.MovieRestServiceApplication.Data.Entities
{
    public partial class Movie
    {
        public Movie()
        {
            MovieToDirectors = new HashSet<MovieToDirector>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime SceneDate { get; set; }
        public long? Rating { get; set; }
        public float? Imdb { get; set; }
        public decimal Cost { get; set; }

        public virtual ICollection<MovieToDirector> MovieToDirectors { get; set; }
    }
}
