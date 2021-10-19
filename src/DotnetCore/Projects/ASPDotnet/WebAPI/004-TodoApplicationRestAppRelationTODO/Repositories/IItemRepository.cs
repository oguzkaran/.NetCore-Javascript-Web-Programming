using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSD.TodoApplicationRestApp.Entities;
using CSD.Util.Data.Repository;

namespace CSD.TodoApplicationRestApp.Repositories
{
    public interface IItemRepository : ICrudRepository<ItemInfo, int>
    {
        IEnumerable<ItemInfo> FindByTodoIdOrderByLastUpdateDesc(int todoId);
    }
}
