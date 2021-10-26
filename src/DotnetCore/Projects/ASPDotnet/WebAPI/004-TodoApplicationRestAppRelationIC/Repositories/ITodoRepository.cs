using CSD.TodoApplicationRestApp.Entities;
using CSD.Util.Data.Repository;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSD.TodoApplicationRestApp.Repositories
{
    public interface ITodoRepository : ICrudRepository<TodoInfo, int>
    {
        Task<IEnumerable<TodoInfo>> FindByMonthAsync(int month);        
        Task<IEnumerable<TodoInfo>> FindByMonthAndYearAsync(int month, int year);
        Task<IEnumerable<TodoInfo>> FindByYearAsync(int year);
        Task<TodoInfoItem> FindByItemIdAsync(int id);
    }
}
