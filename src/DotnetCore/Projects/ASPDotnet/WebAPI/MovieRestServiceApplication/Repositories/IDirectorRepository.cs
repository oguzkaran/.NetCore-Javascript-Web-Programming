using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSD.MovieRestServiceApplication.Entities;
using CSD.Util.Data.Repository;


namespace CSD.MovieRestServiceApplication.Repositories
{
    public interface IDirectorRepository : ICrudRepository<Director, int>
    {
        IEnumerable<Director> FindByAgeGreater(double threshold);
        IEnumerable<Director> FindByAgeLess(double threshold);
    }
}
