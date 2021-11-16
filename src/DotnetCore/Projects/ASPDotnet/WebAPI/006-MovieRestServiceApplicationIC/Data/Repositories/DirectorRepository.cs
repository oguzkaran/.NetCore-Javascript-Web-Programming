
using CSD.MovieRestServiceApplication.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSD.MovieRestServiceApplication.Data.Repositories
{
    public class DirectorRepository : IDirectorRepository
    {
        public long Count()
        {
            throw new System.NotImplementedException();
        }

        public Task<long> CountAsync()
        {
            throw new System.NotImplementedException();
        }

        public void Delete(Director entity)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteAll()
        {
            throw new System.NotImplementedException();
        }

        public void DeleteAll(IEnumerable<Director> entities)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteAllAsync(IEnumerable<Director> entities)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteAllById(IEnumerable<int> ids)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteAllByIdAsync(IEnumerable<int> ids)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteAsync(Director entity)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public bool ExistsById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> ExistsByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Director> FindAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Director>> FindAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Director> FindByAgeGreater(double threshold)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Director> FindByAgeLess(double threshold)
        {
            throw new System.NotImplementedException();
        }

        public Director FindById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Director> FindByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Director Save(Director entity)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Director> SaveAll(IEnumerable<Director> entities)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Director>> SaveAllAsync(IEnumerable<Director> entities)
        {
            throw new System.NotImplementedException();
        }

        public Task<Director> SaveAsync(Director entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
