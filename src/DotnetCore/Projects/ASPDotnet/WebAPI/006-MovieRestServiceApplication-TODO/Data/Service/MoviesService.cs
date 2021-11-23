using CSD.MovieRestServiceApplication.DAL;
using CSD.MovieRestServiceApplication.Data.DTO;
using CSD.Util.Mappers;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

using static CSD.Data.DatabaseUtil;
using CSD.MovieRestServiceApplication.Data.Entities;

namespace CSD.MovieRestServiceApplication.Data.Service
{
    public class MoviesService
    {
        private readonly MoviesDataHelper m_moviesDataHelper;
        private readonly IMapper m_mapper;

        #region Movie callbacks    

        private async Task<IEnumerable<MovieViewModel>> findMoviesByYearCallbackAsync(int year)
        {
            var movies = await m_moviesDataHelper.FindMoviesByYearAsync(year);

            return movies.Select(m => m_mapper.Map<MovieViewModel, Movie>(m));
        }

        private async Task<IEnumerable<MovieViewModel>> findMoviesByYearAndMonthCallbackAsync(int year, int month)
        {
            var movies = await m_moviesDataHelper.FindMoviesByYearAndMonthAsync(year, month);

            return movies.Select(m => m_mapper.Map<MovieViewModel, Movie>(m));
        }

        private async Task<IEnumerable<MovieViewModel>> findMoviesDirectorIdCallbackAsync(int id)
        {
            var movies = await m_moviesDataHelper.FindMoviesByDirectorIdAsync(id);

            return movies.Select(m => m_mapper.Map<MovieViewModel, Movie>(m));
        }

        private async Task<MovieSaveModel> saveMovieCallbackAsync(MovieSaveModel movieSaveModel)
        {
            var movie = await m_moviesDataHelper.SaveMovieAsync(m_mapper.Map<Movie, MovieSaveModel>(movieSaveModel));

            return m_mapper.Map<MovieSaveModel, Movie>(movie);
        }

        #endregion

        #region Director callbacks    
        private async Task<IEnumerable<DirectorWithIdViewModel>> findAllDirectorsCallbackAsync()
        {
            var directors = await m_moviesDataHelper.FindAllDirectors();

            return directors.Select(d => m_mapper.Map<DirectorWithIdViewModel, Director>(d));
        }

        private async Task<IEnumerable<DirectorViewModel>> findDirectorByAgeGreaterCallbackAsync(double threshold)
        {
            var directors = await m_moviesDataHelper.FindDirectorByAgeGreaterAsync(threshold);

            return directors.Select(d => m_mapper.Map<DirectorViewModel, Director>(d));
        }

        private async Task<IEnumerable<DirectorViewModel>> findDirectorByAgeLessCallbackAsync(double threshold)
        {
            var directors = await m_moviesDataHelper.FindDirectorByAgeLessAsync(threshold);

            return directors.Select(d => m_mapper.Map<DirectorViewModel, Director>(d));
        }

        private async Task<DirectorSaveModel> saveDirectorCallbackAsync(DirectorSaveModel directorSaveModel)
        {
            var director = await m_moviesDataHelper.SaveDirectorAsync(m_mapper.Map<Director, DirectorSaveModel>(directorSaveModel));

            return m_mapper.Map<DirectorSaveModel, Director>(director);
        }

        #endregion

        public MoviesService(MoviesDataHelper moviesDataHelper, IMapper mapper)
        {
            m_moviesDataHelper = moviesDataHelper;
            m_mapper = mapper;
        }

        #region Movie 
        public Task<IEnumerable<MovieViewModel>> FindMoviesByYearAsync(int year)
        {
            return SubscribeServiceAsync(() => findMoviesByYearCallbackAsync(year), "MoviesService.FindMoviesByYearAsync");
        }

        public Task<IEnumerable<MovieViewModel>> FindMoviesByYearAndMonthAsync(int year, int month)
        {
            return SubscribeServiceAsync(() => findMoviesByYearAndMonthCallbackAsync(year, month), "MoviesService.FindMoviesByYearAndMonthAsync");
        }

        public Task<IEnumerable<MovieViewModel>> FindMoviesByDirectorIdAsync(int id)
        {
            return SubscribeServiceAsync(() => findMoviesDirectorIdCallbackAsync(id), "MoviesService.FindMoviesByDirectorIdAsync");
        }

        public Task<MovieSaveModel> SaveMovieAsync(MovieSaveModel movieSaveModel)
        {
            return SubscribeServiceAsync(() => saveMovieCallbackAsync(movieSaveModel), "MoviesService.FindMoviesByDirectorIdAsync");
        }

        #endregion

        #region Director
        public Task<IEnumerable<DirectorWithIdViewModel>> FindAllDirectorsAsync()
        {
            return SubscribeServiceAsync(findAllDirectorsCallbackAsync, "MoviesService.FindAllDirectorsAsync");
        }

        public Task<IEnumerable<DirectorViewModel>> FindDirectorByAgeGreaterAsync(double threshold)
        {
            return SubscribeServiceAsync(() => findDirectorByAgeGreaterCallbackAsync(threshold), "MoviesService.FindDirectorByAgeGreaterAsync");
        }

        public Task<IEnumerable<DirectorViewModel>> FindDirectorByAgeLessAsync(double threshold)
        {
            return SubscribeServiceAsync(() => findDirectorByAgeLessCallbackAsync(threshold), "MoviesService.FindDirectorByAgeLessAsync");
        }

        public Task<DirectorSaveModel> SaveDirectorAsync(DirectorSaveModel directorSaveModel)
        {
            return SubscribeServiceAsync(() => saveDirectorCallbackAsync(directorSaveModel), "MoviesService.SaveDirectorAsync");
        }

        #endregion
    }
}
