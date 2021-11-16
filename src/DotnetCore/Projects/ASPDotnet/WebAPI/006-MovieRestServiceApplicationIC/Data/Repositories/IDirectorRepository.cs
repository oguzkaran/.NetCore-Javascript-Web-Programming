using CSD.MovieRestServiceApplication.Data.Entities;
using CSD.Util.Data.Repository;
using System.Collections.Generic;


namespace CSD.MovieRestServiceApplication.Data.Repositories
{
    public interface IDirectorRepository : ICrudRepository<Director, int>
    {
        IEnumerable<Director> FindByAgeGreater(double threshold);
        IEnumerable<Director> FindByAgeLess(double threshold);
    }
}
