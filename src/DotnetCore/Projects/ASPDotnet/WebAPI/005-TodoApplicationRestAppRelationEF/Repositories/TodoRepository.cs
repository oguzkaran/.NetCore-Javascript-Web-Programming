using CSD.TodoApplicationRestApp.Data;
using CSD.TodoApplicationRestApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static CSD.Util.TPL.TaskUtil;

namespace CSD.TodoApplicationRestApp.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly TodoDbContext m_dbContext;        
        
        #region callbacks
        private long countCallback()
        {
            return m_dbContext.TodoInfos.LongCount();            
        }        

        private IEnumerable<TodoInfo> findAllCallback()
        {
            return m_dbContext.TodoInfos.ToList();
        }

        private TodoInfoItem findByItemIdCallback(int id)
        {
            throw new NotImplementedException("findByItemIdCallback");
        }

        private IEnumerable<TodoInfo> findByMonthCallback(int month)
        {
            return from ti in m_dbContext.TodoInfos
                   where ti.CreateDateTime.Month == month
                   select ti;
        }

        private IEnumerable<TodoInfo> findByYearCallback(int year)
        {
            return m_dbContext.TodoInfos.Where(t => t.CreateDateTime.Year == year);
        }

        private IEnumerable<TodoInfo> findByMonthAndYearCallback(int month, int year)
        {
            return m_dbContext.TodoInfos.Where(t => t.CreateDateTime.Month == month).Where(t => t.CreateDateTime.Year == year);
        }

        private TodoInfo saveCallback(TodoInfo todoInfo)
        {
            m_dbContext.TodoInfos.Add(todoInfo);

            if (m_dbContext.SaveChanges() != 1)
                throw new Exception("Save Problem");

            return todoInfo;
        }
        #endregion

        public TodoRepository(TodoDbContext dbContext)
        {
            m_dbContext = dbContext;
        }

        #region Implementeds
        public Task<long> CountAsync()
        {
            return Create(countCallback);
        }

        public Task<IEnumerable<TodoInfo>> FindAllAsync()
        {
            return Create(findAllCallback);
        }

        public Task<TodoInfoItem> FindByItemIdAsync(int id)
        {
            return Create(() => findByItemIdCallback(id));
        }

        public Task<IEnumerable<TodoInfo>> FindByMonthAsync(int month)
        {
            return Create(() => findByMonthCallback(month));
        }

        public Task<IEnumerable<TodoInfo>> FindByYearAsync(int year)
        {
            return Create(() => findByYearCallback(year));
        }

        public Task<IEnumerable<TodoInfo>> FindByMonthAndYearAsync(int month, int year)
        {
            return Create(() => findByMonthAndYearCallback(month, year));
        }

        public Task<TodoInfo> SaveAsync(TodoInfo todoInfo)
        {
            return Create(() => saveCallback(todoInfo));
        }
        #endregion

        #region Not Implementeds
        public long Count()
        {
            throw new NotImplementedException();
        }

        public void Delete(TodoInfo entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteAll()
        {
            throw new NotImplementedException();
        }

        public void DeleteAll(IEnumerable<TodoInfo> entities)
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

        public IEnumerable<TodoInfo> FindAll()
        {
            throw new NotImplementedException();
        }

        public TodoInfo FindById(int id)
        {
            throw new NotImplementedException();
        }

        public TodoInfo Save(TodoInfo entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TodoInfo> SaveAll(IEnumerable<TodoInfo> entities)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(TodoInfo entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task DeleteAllAsync(IEnumerable<TodoInfo> entities)
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

        public Task<TodoInfo> FindByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TodoInfo>> SaveAllAsync(IEnumerable<TodoInfo> entities)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
