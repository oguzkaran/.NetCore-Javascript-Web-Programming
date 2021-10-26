using CSD.TodoApplicationRestApp.DAL;
using CSD.TodoApplicationRestApp.DTO;
using CSD.TodoApplicationRestApp.Entities;
using CSD.Util.Data.Repository;
using CSD.Util.Data.Service;
using CSD.Util.Mappers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static CSD.Data.DatabaseUtil;

namespace CSD.TodoApplicationRestApp
{
    public class TodoAppService
    {
        private readonly TodoAppDAL m_todoAppDAL;
        private readonly IMapper m_mapper;

        private async Task<IEnumerable<TodoInfoDTO>> findAllTodosCallback()
        {
            var todos = await m_todoAppDAL.FindAllTodosAsync();


            var todosDTO = new List<TodoInfoDTO>();

            foreach (var todo in todos)
                todosDTO.Add(m_mapper.Map<TodoInfoDTO, TodoInfo>(todo));

            return todosDTO;            
        }

        public TodoAppService(TodoAppDAL todoAppDAL, IMapper mapper)
        {
            m_todoAppDAL = todoAppDAL;
            m_mapper = mapper;
        }

        public Task<long> CountTodosAsync()
        {
            return SubscribeServiceAsync(m_todoAppDAL.CountTodosAsync, "TodoAppService.CountTodos");            
        }

        public Task<IEnumerable<TodoInfoDTO>> FindAllTodosAsync()
        {
            return SubscribeServiceAsync(findAllTodosCallback, "TodoAppService.FindAllTodos");            
        }

        public Task<TodoInfoItem> FindTodoByItemIdAsync(int id)
        {
            return SubscribeServiceAsync(() => m_todoAppDAL.FindTodoByItemIdAsync(id), "TodoAppService.FindTodoByItemIdAsync");            
        }

        public Task<IEnumerable<TodoInfo>> FindTodosByMonthAsync(int month)
        {
            return SubscribeServiceAsync(() => m_todoAppDAL.FindTodosByMonthAsync(month), "TodoAppService.FindTodosByMonthAsync");            
        }        

        public Task<IEnumerable<TodoInfo>> FindTodosByMonthAndYearAsync(int month, int year)
        {
            return SubscribeServiceAsync(() => m_todoAppDAL.FindTodosByMonthAndYearAsync(month, year), "TodoAppService.FindTodosByMonthAndYearAsync");            
        }

        public Task<TodoInfo> SaveTodo(TodoInfo todoInfo)
        {
            return SubscribeServiceAsync(() => m_todoAppDAL.SaveTodoInfoAsync(todoInfo), "TodoAppService.SaveTodoAsync");            
        }

        //////////////////////////////////////////////////////////////////
        public IEnumerable<ItemInfo> FindItemByTodoIdOrderByLastUpdateDesc(int todoId)
        {
            try
            {
                return m_todoAppDAL.FindItemByTodoIdOrderByLastUpdateDesc(todoId);
            }
            catch (Exception ex)
            {
                throw new RepositoryException("TodoAppDAL.FindItemByTodoIdOrderByLastUpdateDesc", ex);
            }
        }


        public ItemInfo SaveItem(ItemInfo itemInfo)
        {
            try
            {
                return m_todoAppDAL.SaveItemInfo(itemInfo);
            }
            catch (RepositoryException ex)
            {
                //...
                throw new DataServiceException("TodoAppService.SaveItem", ex.InnerException);
            }
            catch (Exception ex)
            {
                throw new DataServiceException("TodoAppService.SaveItem", ex);
            }
        }

        public long CountItems()
        {
            try
            {
                return m_todoAppDAL.CountItems();
            }
            catch (RepositoryException ex)
            {
                //...
                throw new DataServiceException("TodoAppService.CountItems", ex.InnerException);
            }
            catch (Exception ex)
            {
                throw new DataServiceException("TodoAppService.CountItems", ex);
            }
            //...
        }
    }
}
