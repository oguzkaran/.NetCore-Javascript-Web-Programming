using CSD.Util.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSD.TodoApplicationRestApp.Repositories
{
    public interface ITodoRepository : ICrudRepository<TodoInfo, int>
    {

    }
}
