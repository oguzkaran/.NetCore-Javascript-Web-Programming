using CSD.MovieRestServiceApplication.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSD.MovieRestServiceApplication.Repositories
{
    public class DirectorRepository : IDirectorRepository
    {
        public long Count()
        {
            throw new NotImplementedException();
        }

        public void Delete(Director entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteAll()
        {
            throw new NotImplementedException();
        }

        public void DeleteAll(IEnumerable<Director> entities)
        {
            throw new NotImplementedException();
        }

        public void DeleteAllById(IEnumerable<int> ids)
        {
            throw new NotImplementedException();
        }

        public void DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public bool ExistsById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Director> FindAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Director> FindByAgeGreater(double threshold)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Director> FindByAgeLess(double threshold)
        {
            throw new NotImplementedException();
        }

        public Director FindById(int id)
        {
            throw new NotImplementedException();
        }

        public Director Save(Director entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Director> SaveAll(IEnumerable<Director> entities)
        {
            throw new NotImplementedException();
        }
    }
}
