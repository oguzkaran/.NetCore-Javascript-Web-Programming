using CSD.TodoApplicationRestApp.DAL;
using CSD.Util.Data.Repository;
using CSD.Util.Data.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSD.TodoApplicationRestApp
{
    public class TodoAppService
    {
        private readonly TodoAppDAL m_todoAppDAL;
        

        public TodoAppService(TodoAppDAL todoAppDAL)
        {
            m_todoAppDAL = todoAppDAL;
        }

        public long CountTodos()
        {
            try
            {
                return m_todoAppDAL.CountTodos();
            }
            catch (RepositoryException ex)
            {
                //...
                throw new DataServiceException("TodoAppService.Count", ex.InnerException);
            }
            catch (Exception ex) {
                throw new DataServiceException("TodoAppService.Count", ex);
            }
            //...
        }

        public TodoInfo SaveTodo(TodoInfo todoInfo)
        {
            try
            {
                return m_todoAppDAL.SaveTodoInfo(todoInfo);
            }
            catch (RepositoryException ex)
            {
                //...
                throw new DataServiceException("TodoAppService.SaveTodo", ex.InnerException);
            }
            catch (Exception ex)
            {
                throw new DataServiceException("TodoAppService.SaveTodo", ex);
            }
        }

    }
}
