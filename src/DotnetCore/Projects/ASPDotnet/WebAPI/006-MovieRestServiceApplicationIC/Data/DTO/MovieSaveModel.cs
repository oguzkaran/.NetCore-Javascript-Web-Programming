using System;

namespace CSD.MovieRestServiceApplication.Data.DTO
{
    public class MovieSaveModel
    {
        public string Name { get; set; }
        public DateTime SceneDate { get; set; }
        public long Rating { get; set; }
        public float Imdb { get; set; }
        public decimal Cost { get; set; }
    }
}
