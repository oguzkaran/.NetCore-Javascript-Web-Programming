
using CSD.Application.Entitites;
using System;
using System.Collections.Generic;
using System.IO;

namespace CSD.Application.Factories
{
    public class MovieFactory
    {
        private static Movie createMovie(string[] movieInfo)
        {
            return new Movie
            {
                Id = long.Parse(movieInfo[0]),
                Name = movieInfo[1],
                Genre = movieInfo[2],
                VisionDate = DateTime.Parse(movieInfo[3]),
                Rating = long.Parse(movieInfo[4]),
                Cost = long.Parse(movieInfo[5])                
            };
        }

        private void loadMovies(string path)
        {
            using var sr = new StreamReader(path);

            string line;

            sr.ReadLine();

            while ((line = sr.ReadLine()) != null)
                Movies.Add(createMovie(line.Split(new char[] { '@' }, StringSplitOptions.RemoveEmptyEntries)));            
        }

        public List<Movie> Movies { get; private set; } = new List<Movie>();

        public MovieFactory(string path)
        {
            loadMovies(path);
        }
    }
}
