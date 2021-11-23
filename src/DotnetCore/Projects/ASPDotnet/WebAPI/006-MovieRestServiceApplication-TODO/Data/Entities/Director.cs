using System;
using System.Collections.Generic;

#nullable disable

namespace CSD.MovieRestServiceApplication.Data.Entities
{
    public partial class Director
    {
        public Director()
        {
            MovieToDirectors = new HashSet<MovieToDirector>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }

        public virtual ICollection<MovieToDirector> MovieToDirectors { get; set; }
    }
}
