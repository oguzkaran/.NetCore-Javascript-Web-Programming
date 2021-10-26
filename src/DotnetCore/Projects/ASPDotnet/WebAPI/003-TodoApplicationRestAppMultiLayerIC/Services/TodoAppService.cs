using CSD.TodoApplicationRestApp.DAL;
using CSD.TodoApplicationRestApp.Entities;
using CSD.Util.Data.Repository;
using CSD.Util.Data.Service;
using System;
using System.Collections.Generic;
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

        public async Task<long> CountTodosAsyncAsync()
        {
            try
            {
                return await m_todoAppDAL.CountTodosAsync();
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

        public async Task<IEnumerable<TodoInfo>> FindAllTodosAsync()
        {
            try
            {
                return await m_todoAppDAL.FindAllTodosAsync();
            }
            catch (RepositoryException ex)
            {                
                throw new DataServiceException("TodoAppService.FindAllTodos", ex.InnerException);
            }
            catch (Exception ex)
            {
                throw new DataServiceException("TodoAppService.FindAllTodos", ex);
            }
        }

        public async Task<IEnumerable<TodoInfo>> FindTodosByMonthAsync(int month)
        {
            try
            {
                return await m_todoAppDAL.FindTodosByMonthAsync(month);
            }
            catch (RepositoryException ex)
            {
                throw new DataServiceException("TodoAppService.FindTodosByMonth", ex.InnerException);
            }
            catch (Exception ex)
            {
                throw new DataServiceException("TodoAppService.FindTodosByMonth", ex);
            }
        }

        public async Task<IEnumerable<TodoInfo>> FindTodosByLastUpdateMonthAsync(int month)
        {
            try
            {
                return await m_todoAppDAL.FindTodosByLastUpdateMonthAsync(month);
            }
            catch (RepositoryException ex)
            {
                throw new DataServiceException("TodoAppService.FindTodosByLastUpdateMonth", ex.InnerException);
            }
            catch (Exception ex)
            {
                throw new DataServiceException("TodoAppService.FindTodosByLastUpdateMonth", ex);
            }
        }

        public async Task<IEnumerable<TodoInfo>> FindTodosByMonthAndYearAsync(int month, int year)
        {
            try
            {
                return await m_todoAppDAL.FindTodosByMonthAndYearAsync(month, year);
            }
            catch (RepositoryException ex)
            { 
                throw new DataServiceException("TodoAppService.FindTodosByMonthAndYear", ex.InnerException); 
            }
            catch (Exception ex) 
            {                
                throw new DataServiceException("TodoAppService.FindTodosByMonthAndYear", ex); 
            }
        }

        public async Task<TodoInfo> SaveTodoAsync(TodoInfo todoInfo)
        {
            try
            {
                return await m_todoAppDAL.SaveTodoInfoAsync(todoInfo);
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
