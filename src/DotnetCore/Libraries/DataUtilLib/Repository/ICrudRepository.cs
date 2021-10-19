using System.Collections.Generic;
using System.Threading.Tasks;

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
        Task<long> CountAsync();
        Task DeleteAsync(T entity);
        Task DeleteAllAsync();
        Task DeleteAllAsync(IEnumerable<T> entities);
        Task DeleteAllByIdAsync(IEnumerable<ID> ids);
        Task DeleteByIdAsync(ID id);
        Task<bool> ExistsByIdAsync(ID id);
        Task<IEnumerable<T>> FindAllAsync();
        Task<T> FindByIdAsync(ID id);
        Task<T> SaveAsync(T entity);
        Task<IEnumerable<T>> SaveAllAsync(IEnumerable<T> entities);
    }
}
