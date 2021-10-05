using CSD.TodoApplicationRestApp.Entities;
using CSD.TodoApplicationRestApp.Repositories;
using CSD.Util.Data.Repository;
using System;
using System.Collections;
using System.Collections.Generic;

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

        public IEnumerable<TodoInfo> FindAllTodos()
        {
            try {
                return m_todoRepository.FindAll();
            }
            catch (Exception ex)
            {
                throw new RepositoryException("TodoAppDAL.FindAllTodos", ex);
            }
        }


        public IEnumerable<TodoInfo> FindTodosByMonth(int month)
        {
            try
            {
                return m_todoRepository.FindByMonth(month);
            }
            catch (Exception ex)
            {
                throw new RepositoryException("TodoAppDAL.FindTodosByMonth", ex);
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
