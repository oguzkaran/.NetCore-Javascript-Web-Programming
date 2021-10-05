using CSD.TodoApplicationRestApp.Entities;
using CSD.Util.Data.Repository;
using System.Collections;
using System.Collections.Generic;

namespace CSD.TodoApplicationRestApp.Repositories
{
    public interface ITodoRepository : ICrudRepository<TodoInfo, int>
    {
        IEnumerable<TodoInfo> FindByMonth(int month);        
        IEnumerable<TodoInfo> FindByMonthAndYear(int month, int year);
        IEnumerable<TodoInfo> FindByYear(int year);
    }
}
