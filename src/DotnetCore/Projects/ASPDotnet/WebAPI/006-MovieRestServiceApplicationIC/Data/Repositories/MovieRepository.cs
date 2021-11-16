using CSD.MovieRestServiceApplication.Data.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using static CSD.Util.TPL.TaskUtil;

namespace CSD.MovieRestServiceApplication.Data.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly MovieAppDbContext m_movieAppDbContext;

        #region callbacks
        private IEnumerable<Movie> findAllCallback()
        {
            return m_movieAppDbContext.Movies.ToList();
        }

        private IEnumerable<Movie> findByYearCallback(int year)
        {
            return m_movieAppDbContext.Movies.Where(m => m.SceneDate.Year == year);
        }
        private IEnumerable<Movie> findByYearAndMonthCallback(int year, int month)
        {
            return m_movieAppDbContext.Movies.Where(m => m.SceneDate.Year == year && m.SceneDate.Month == month);
        }

        private IEnumerable<Movie> findByDirectorIdCallback(int id)
        {
            return from mtd in m_movieAppDbContext.MovieToDirectors
                   join m in m_movieAppDbContext.Movies on mtd.MovieId equals m.Id
                   where mtd.DirectorId == id
                   select m;
                   

            //return from mtd in m_movieAppDbContext.MovieToDirectors
            //       from m in m_movieAppDbContext.Movies
            //       where m.Id == mtd.MovieId && mtd.DirectorId == id
            //       select m;
        }

        public Movie saveCallback(Movie movie)
        {
            m_movieAppDbContext.Movies.Add(movie);
            m_movieAppDbContext.SaveChanges();             

            return movie;
        }

        #endregion
        public MovieRepository(MovieAppDbContext movieAppDbContext)
        {
            m_movieAppDbContext = movieAppDbContext;
        }

        #region Task implementions
        public Task<long> CountAsync()
        {
            return Create(() => m_movieAppDbContext.Movies.LongCount());
        }

        public Task<IEnumerable<Movie>> FindAllAsync()
        {
            return Create(findAllCallback);
        }

        public Task<IEnumerable<Movie>> FindByYearAsync(int year)
        {
            return Create(() => findByYearCallback(year));
        }

        public Task<IEnumerable<Movie>> FindByYearAndMonthAsync(int year, int month)
        {
            return Create(() => findByYearAndMonthCallback(year, month));
        }

        public Task<IEnumerable<Movie>> FindByDirectorIdAsync(int id)
        {
            return Create(() => findByDirectorIdCallback(id));
        }
        public Task<Movie> SaveAsync(Movie movie)
        {
            return Create(() => saveCallback(movie));
        }

        #endregion

        ///////////////////////////////////////////////////////////

        public long Count()
        {
            throw new NotImplementedException();
        }

        public void Delete(Movie entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteAll()
        {
            throw new NotImplementedException();
        }

        public void DeleteAll(IEnumerable<Movie> entities)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task DeleteAllAsync(IEnumerable<Movie> entities)
        {
            throw new NotImplementedException();
        }

        public void DeleteAllById(IEnumerable<long> ids)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAllByIdAsync(IEnumerable<long> ids)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Movie entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteById(long id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public bool ExistsById(long id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistsByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Movie> FindAll()
        {
            throw new NotImplementedException();
        }
        
        

        public Movie FindById(long id)
        {
            throw new NotImplementedException();
        }

        public Task<Movie> FindByIdAsync(long id)
        {
            throw new NotImplementedException();
        }      
        public Movie Save(Movie entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Movie> SaveAll(IEnumerable<Movie> entities)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Movie>> SaveAllAsync(IEnumerable<Movie> entities)
        {
            throw new NotImplementedException();
        }       
    }
}
