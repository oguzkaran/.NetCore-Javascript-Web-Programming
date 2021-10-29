using System;

namespace CSD.Entitites
{
    public class Movie
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public DateTime VisionDate { get; set; }
        public long Rating { get; set; }

        public long Cost { get; set; }
    }
}
