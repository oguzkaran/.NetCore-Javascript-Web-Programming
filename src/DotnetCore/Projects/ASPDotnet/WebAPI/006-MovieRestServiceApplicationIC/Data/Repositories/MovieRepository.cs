using CSD.MovieRestServiceApplication.Data.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSD.MovieRestServiceApplication.Data.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        public long Count()
        {
            throw new NotImplementedException();
        }

        public Task<long> CountAsync()
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

        public Task<IEnumerable<Movie>> FindAllAsync()
        {
            throw new NotImplementedException();
        }

        public Movie FindByDirectorId(int id)
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

        public IEnumerable<Movie> FindByYear(int year)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Movie> FindByYearAndMonth(int year, int month)
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

        public Task<Movie> SaveAsync(Movie entity)
        {
            throw new NotImplementedException();
        }
    }
}
