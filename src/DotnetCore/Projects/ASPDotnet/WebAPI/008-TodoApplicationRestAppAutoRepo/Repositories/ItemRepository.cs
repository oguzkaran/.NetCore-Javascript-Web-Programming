using CSD.TodoApplicationRestApp.Data;
using CSD.TodoApplicationRestApp.Entities;
using CSD.Util.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using static CSD.Util.TPL.TaskUtil;

namespace CSD.TodoApplicationRestApp.Repositories
{
    public class ItemRepository : IItemRepository
    {        
        private readonly TodoDbContext m_todoDbContext;

        public IEnumerable<ItemInfo> All => throw new NotImplementedException();

        #region callbacks
        private long countCallback()
        {
            return m_todoDbContext.ItemInfos.LongCount();
        }

        public IEnumerable<ItemInfo> findByTodoIdOrderByLastUpdateDesc(int todoId)
        {
            return m_todoDbContext.ItemInfos.Where(i => i.TodoId == todoId).OrderBy(i => i.LastUpdate);               
        }

        #endregion

        public ItemRepository(TodoDbContext todoDbContext)
        {
            m_todoDbContext = todoDbContext;
        }

        public Task<long> CountAsync()
        {
            return Create(countCallback);                          
        }

        public Task<IEnumerable<ItemInfo>> FindByTodoIdOrderByLastUpdateDesc(int todoId)
        {
            return Create(() => findByTodoIdOrderByLastUpdateDesc(todoId));
        }

        /////////////////////////////////////////////////////////////////////////////////////

        public ItemInfo Save(ItemInfo itemInfo)
        {
            throw new NotImplementedException("Save");
        }

        public void Delete(ItemInfo entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteAll()
        {
            throw new NotImplementedException();
        }

        public void DeleteAll(IEnumerable<ItemInfo> entities)
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

        public IEnumerable<ItemInfo> FindAll()
        {
            throw new NotImplementedException();
        }

        public ItemInfo FindById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ItemInfo> SaveAll(IEnumerable<ItemInfo> entities)
        {
            throw new NotImplementedException();
        }

        public long Count()
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(ItemInfo entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task DeleteAllAsync(IEnumerable<ItemInfo> entities)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAllByIdAsync(IEnumerable<int> ids)
        {
            throw new NotImplementedException();
        }

        public Task DeleteByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistsByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ItemInfo>> FindAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ItemInfo> FindByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ItemInfo> SaveAsync(ItemInfo entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ItemInfo>> SaveAllAsync(IEnumerable<ItemInfo> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ItemInfo> FindByFilter(Expression<Func<ItemInfo, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ItemInfo> FindByIds(IEnumerable<int> ids)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ItemInfo> Save(IEnumerable<ItemInfo> entities)
        {
            throw new NotImplementedException();
        }

        void ICrudRepository<ItemInfo, int>.DeleteAsync(ItemInfo t)
        {
            throw new NotImplementedException();
        }

        void ICrudRepository<ItemInfo, int>.DeleteByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ItemInfo>> FindByFilterAsync(Expression<Func<ItemInfo, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ItemInfo>> FindByIdsAsync(IEnumerable<int> ids)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ItemInfo>> SaveAsync(IEnumerable<ItemInfo> entities)
        {
            throw new NotImplementedException();
        }
    }
}
