using CSD.MovieRestServiceApplication.Data.Entities;
using CSD.Util.Data.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSD.MovieRestServiceApplication.Data.Repositories
{
    public interface IDirectorRepository : ICrudRepository<Director, int>
    {
        Task<IEnumerable<Director>> FindByAgeGreaterAsync(double threshold);
        Task<IEnumerable<Director>> FindByAgeLessAsync(double threshold);
    }
}
