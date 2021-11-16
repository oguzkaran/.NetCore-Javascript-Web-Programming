using CSD.MovieRestServiceApplication.Data.Repositories;

namespace CSD.MovieRestServiceApplication.DAL
{
    public class MoviesDataHelper
    {
        private readonly IMovieRepository m_movieRepository;
        private readonly IDirectorRepository m_directorRepository;

        public MoviesDataHelper(IMovieRepository movieRepository, IDirectorRepository directorRepository)
        {
            m_movieRepository = movieRepository;
            m_directorRepository = directorRepository;

        }
    }
}
