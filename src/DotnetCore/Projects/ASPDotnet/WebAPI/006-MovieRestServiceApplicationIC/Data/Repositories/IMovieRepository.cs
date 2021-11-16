using CSD.MovieRestServiceApplication.Data.Entities;
using CSD.Util.Data.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSD.MovieRestServiceApplication.Data.Repositories
{
    public interface IMovieRepository : ICrudRepository<Movie, long>
    {
        Task<IEnumerable<Movie>> FindByYearAsync(int year);
        Task<IEnumerable<Movie>> FindByYearAndMonthAsync(int year, int month);
        Task<IEnumerable<Movie>> FindByDirectorIdAsync(int id);
    }
}
