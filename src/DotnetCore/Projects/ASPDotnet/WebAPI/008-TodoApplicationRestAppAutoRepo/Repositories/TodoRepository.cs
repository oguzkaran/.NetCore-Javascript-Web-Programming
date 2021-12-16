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
    public class TodoRepository : CrudRepository<TodoInfo, int, TodoDbContext>, ITodoRepository
    {
        #region callbacks        
        private TodoInfoItem findByItemIdCallback(int id)
        {
            throw new NotImplementedException("findByItemIdCallback");
        }

        private IEnumerable<TodoInfo> findByMonthCallback(int month)
        {
            return from ti in Ctx.TodoInfos
                   where ti.CreateDateTime.Month == month
                   select ti;
        }

        private IEnumerable<TodoInfo> findByYearCallback(int year)
        {
            return Ctx.TodoInfos.Where(t => t.CreateDateTime.Year == year);
        }

        private IEnumerable<TodoInfo> findByMonthAndYearCallback(int month, int year)
        {
            return Ctx.TodoInfos.Where(t => t.CreateDateTime.Month == month).Where(t => t.CreateDateTime.Year == year);
        }
        
        #endregion

        public TodoRepository() : base(new TodoDbContext())
        {            
        }

        #region Implemented Methods
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
        
        #endregion

        
    }
}
