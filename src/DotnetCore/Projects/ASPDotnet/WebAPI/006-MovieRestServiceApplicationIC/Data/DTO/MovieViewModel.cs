using System;

namespace CSD.MovieRestServiceApplication.Data.DTO
{
    public partial class MovieViewModel
    {
        public string Name { get; set; }
        public DateTime SceneDate { get; set; }        
        public float? Imdb { get; set; }
        public decimal Cost { get; set; }
    }
}
