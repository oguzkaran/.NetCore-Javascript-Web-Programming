using CSD.MovieRestServiceApplication.Data.Entities;
using CSD.MovieRestServiceApplication.Data.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using static CSD.Data.DatabaseUtil;

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

        #region Movie        
        public Task<IEnumerable<Movie>> FindMoviesByYearAsync(int year)
        {
            return SubscribeRepositoryAsync(() => m_movieRepository.FindByYearAsync(year), "MoviesDataHelper.FindMoviesByYearAsync");
        }

        public Task<IEnumerable<Movie>> FindMoviesByYearAndMonthAsync(int year, int month)
        {
            return SubscribeRepositoryAsync(() => m_movieRepository.FindByYearAndMonthAsync(year, month), "MoviesDataHelper.FindMoviesByYearAndMonthAsync");
        }

        public Task<IEnumerable<Movie>> FindMoviesByDirectorIdAsync(int id)
        {
            return SubscribeRepositoryAsync(() => m_movieRepository.FindByDirectorIdAsync(id), "MoviesDataHelper.FindMoviesByDirectorIdAsync");
        }

        public Task<Movie> SaveMovieAsync(Movie movie)
        {
            return SubscribeRepositoryAsync(() => m_movieRepository.SaveAsync(movie), "MoviesDataHelper.SaveMovieAsync");
        }
        //...
        #endregion

        #region Director
        public Task<IEnumerable<Director>> FindAllDirectors()
        {
            return SubscribeRepositoryAsync(m_directorRepository.FindAllAsync, "MoviesDataHelper.FindAllDirectors");
        }

        public Task<IEnumerable<Director>> FindDirectorByAgeGreaterAsync(double threshold)
        {
            return SubscribeRepositoryAsync(() => m_directorRepository.FindByAgeGreaterAsync(threshold), "MoviesDataHelper.FindDirectorByAgeGreaterAsync");
        }

        public Task<IEnumerable<Director>> FindDirectorByAgeLessAsync(double threshold)
        {
            return SubscribeRepositoryAsync(() => m_directorRepository.FindByAgeLessAsync(threshold), "MoviesDataHelper.FindDirectorByAgeLessAsync");
        }

        public Task<Director> SaveDirectorAsync(Director director)
        {
            return SubscribeRepositoryAsync(() => m_directorRepository.SaveAsync(director), "MoviesDataHelper.SaveDirectorAsync");
        }

        //...
        #endregion
    }
}
