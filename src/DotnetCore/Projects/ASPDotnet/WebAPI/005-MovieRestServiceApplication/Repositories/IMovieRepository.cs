using CSD.MovieRestServiceApplication.Entities;
using CSD.Util.Data.Repository;
using System.Collections.Generic;

namespace CSD.MovieRestServiceApplication.Repositories
{
    public interface IMovieRepository : ICrudRepository<Movie, long>
    {
        IEnumerable<Movie> FindByYear(int year);
        IEnumerable<Movie> FindByYearAndMonth(int year, int month);
        Movie FindByDirectorId(int id);
    }
}
