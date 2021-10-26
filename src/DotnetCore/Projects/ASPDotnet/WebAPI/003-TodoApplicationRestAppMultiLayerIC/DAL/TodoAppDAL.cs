using CSD.TodoApplicationRestApp.Entities;
using CSD.TodoApplicationRestApp.Repositories;
using CSD.Util.Data.Repository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSD.TodoApplicationRestApp.DAL
{
    public class TodoAppDAL
    {
        private readonly ITodoRepository m_todoRepository;

        private static Task<T> createTask<T>(Func<T> action)
        {
            var task = new Task<T>(action);

            task.Start();

            return task;
        }

        private long countTodosCallback()
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

        private IEnumerable<TodoInfo> findAllTodosCallback()
        {
            try
            {
                return m_todoRepository.FindAll();
            }
            catch (Exception ex)
            {
                throw new RepositoryException("TodoAppDAL.FindAllTodos", ex);
            }
        }

        private IEnumerable<TodoInfo> findTodosByMonthCallback(int month)
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

        private IEnumerable<TodoInfo> findTodosByLastUpdateMonthCallback(int month)
        {
            try
            {
                return m_todoRepository.FindByLastUpdateMonth(month);
            }
            catch (Exception ex)
            {
                throw new RepositoryException("TodoAppDAL.FindTodosByLastUpdateMonth", ex);
            }
        }

        private IEnumerable<TodoInfo> findTodosByMonthAndYearCallback(int month, int year)
        {
            try
            {
                return m_todoRepository.FindByMonthAndYear(month, year);
            }
            catch (Exception ex)
            {
                throw new RepositoryException("TodoAppDAL.FindTodosByMonthAndYear", ex);
            }
        }


        private TodoInfo saveTodoInfo(TodoInfo todoInfo)
        {
            try
            {
                return m_todoRepository.Save(todoInfo);
            }
            catch (Exception ex)
            {
                throw new RepositoryException("TodoAppDAL.SaveTodoInfo", ex);
            }
        }

        public TodoAppDAL(ITodoRepository todoRepository)
        {
            m_todoRepository = todoRepository;
        }

        public Task<long> CountTodosAsync()
        {
            return createTask(countTodosCallback);
        }


        public Task<IEnumerable<TodoInfo>> FindAllTodosAsync()
        {
            return createTask(findAllTodosCallback);            
        }

        public Task<IEnumerable<TodoInfo>> FindTodosByMonthAsync(int month)
        {
            return createTask(() => findTodosByMonthCallback(month));            
        }

        public Task<IEnumerable<TodoInfo>> FindTodosByLastUpdateMonthAsync(int month)
        {
            return createTask(() => findTodosByLastUpdateMonthCallback(month));            
        }

        public Task<IEnumerable<TodoInfo>> FindTodosByMonthAndYearAsync(int month,int year)
        {
            return createTask(() => findTodosByMonthAndYearCallback(month, year));            
        }

        public Task<TodoInfo> SaveTodoInfoAsync(TodoInfo todoInfo)
        {
            return createTask(() => saveTodoInfo(todoInfo));
        }        
        
        //...
    }
}
