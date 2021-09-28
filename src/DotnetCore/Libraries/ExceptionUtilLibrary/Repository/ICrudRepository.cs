using System.Collections.Generic;

namespace CSD.Util.Data.Repository
{
    public interface ICrudRepository<T, ID> where T: class
    {
        long Count();
        void Delete(T entity);
        void DeleteAll();
        void DeleteAll(IEnumerable<T> entities);
        void DeleteAllById(IEnumerable<ID> ids);
        void DeleteById(ID id);
        bool ExistsById(ID id);
        IEnumerable<T> FindAll();
        T FindById(ID id);
        T Save(T entity);
        IEnumerable<T> SaveAll(IEnumerable<T> entities);
    }
}
