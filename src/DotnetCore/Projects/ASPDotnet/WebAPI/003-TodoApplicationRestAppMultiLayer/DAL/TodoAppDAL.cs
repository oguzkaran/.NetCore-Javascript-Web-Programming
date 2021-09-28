using CSD.TodoApplicationRestApp.Repositories;
using CSD.Util.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSD.TodoApplicationRestApp.DAL
{
    public class TodoAppDAL
    {
        private readonly ITodoRepository m_todoRepository;

        public TodoAppDAL(ITodoRepository todoRepository)
        {
            m_todoRepository = todoRepository;
        }

        public long CountTodos()
        {
            try
            {
                return m_todoRepository.Count();
            }
            catch (Exception ex)
            {
                throw new RepositoryException("TodoAppDAL.CountTodos", ex);
            }
        }

        public TodoInfo SaveTodoInfo(TodoInfo todoInfo)
        {
            try
            {
                return m_todoRepository.Save(todoInfo);
            }
            catch (Exception ex) {
                throw new RepositoryException("TodoAppDAL.SaveTodoInfo", ex);
            }            
        }

        
        
        //...
    }
}
