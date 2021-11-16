using CSD.MovieRestServiceApplication.Data.Entities;
using CSD.Util.Data.Repository;
using System.Collections.Generic;

namespace CSD.MovieRestServiceApplication.Data.Repositories
{
    public interface IMovieRepository : ICrudRepository<Movie, long>
    {
        IEnumerable<Movie> FindByYear(int year);
        IEnumerable<Movie> FindByYearAndMonth(int year, int month);
        Movie FindByDirectorId(int id);
    }
}
