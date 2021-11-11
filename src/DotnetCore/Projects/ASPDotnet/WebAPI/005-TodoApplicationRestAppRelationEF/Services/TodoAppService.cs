using CSD.TodoApplicationRestApp.DAL;
using CSD.TodoApplicationRestApp.DTO;
using CSD.TodoApplicationRestApp.Entities;
using CSD.Util.Data.Repository;
using CSD.Util.Data.Service;
using CSD.Util.Mappers;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using static CSD.Data.DatabaseUtil;

namespace CSD.TodoApplicationRestApp
{
    public class TodoAppService
    {
        private readonly TodoAppDAL m_todoAppDAL;
        private readonly IMapper m_mapper;

        #region TodoInfo callbacks
        private async Task<IEnumerable<TodoInfoDTO>> findAllTodosCallback()
        {
            var todos = await m_todoAppDAL.FindAllTodosAsync();

            return todos.ToList().Select(t => m_mapper.Map<TodoInfoDTO, TodoInfo>(t)).ToList();            
        }

        private async Task<IEnumerable<TodoInfoDTO>> findTodosByMonthCallback(int month)
        {
            var todos = await m_todoAppDAL.FindTodosByMonthAsync(month);

            return todos.ToList().Select(t => m_mapper.Map<TodoInfoDTO, TodoInfo>(t)).ToList();
        }

        private async Task<IEnumerable<TodoInfoDTO>> findTodosByYearCallback(int year)
        {
            var todos = await m_todoAppDAL.FindTodosByMonthAsync(year);

            return todos.ToList().Select(t => m_mapper.Map<TodoInfoDTO, TodoInfo>(t)).ToList();
        }

        private async Task<IEnumerable<TodoInfoDTO>> findTodosByMonthAndYearCallback(int month, int year)
        {
            var todos = await m_todoAppDAL.FindTodosByMonthAndYearAsync(month, year);

            return todos.ToList().Select(t => m_mapper.Map<TodoInfoDTO, TodoInfo>(t)).ToList();
        }

        public async Task<TodoInfoDTO> saveTodoCallback(TodoInfoDTO todoInfoDTO)
        {
            var todo = m_mapper.Map<TodoInfo, TodoInfoDTO>(todoInfoDTO);

            return m_mapper.Map<TodoInfoDTO, TodoInfo>(await m_todoAppDAL.SaveTodoInfoAsync(todo));
        }


        #endregion
        public TodoAppService(TodoAppDAL todoAppDAL, IMapper mapper)
        {
            m_todoAppDAL = todoAppDAL;
            m_mapper = mapper;
        }

        public Task<long> CountTodosAsync()
        {
            return SubscribeServiceAsync(m_todoAppDAL.CountTodosAsync, "TodoAppService.CountTodosAsync");            
        }

        public Task<IEnumerable<TodoInfoDTO>> FindAllTodosAsync()
        {
            return SubscribeServiceAsync(findAllTodosCallback, "TodoAppService.FindAllTodos");            
        }

        public Task<TodoInfoItem> FindTodoByItemIdAsync(int id)
        {
            //TODO:
            return SubscribeServiceAsync(() => m_todoAppDAL.FindTodoByItemIdAsync(id), "TodoAppService.FindTodoByItemIdAsync");            
        }

        public Task<IEnumerable<TodoInfoDTO>> FindTodosByMonthAsync(int month)
        {
            return SubscribeServiceAsync(() => findTodosByMonthCallback(month), "TodoAppService.FindTodosByMonthAsync");            
        }        

        public Task<IEnumerable<TodoInfoDTO>> FindTodosByYear(int year)
        {
            return SubscribeServiceAsync(() => findTodosByYearCallback(year), "TodoAppService.FindTodosByYearAsync");            
        }

        public Task<IEnumerable<TodoInfoDTO>> FindTodosByMonthAndYearAsync(int month, int year)
        {
            return SubscribeServiceAsync(() => findTodosByMonthAndYearCallback(month, year), "TodoAppService.FindTodosByMonthAndYearAsync");
        }

        public Task<TodoInfoDTO> SaveTodo(TodoInfoDTO todoInfo)
        {
            return SubscribeServiceAsync(() => saveTodoCallback(todoInfo), "TodoAppService.SaveTodoAsync");            
        }

        #region ITemInfo
        public Task<long> CountItemsAsync()
        {
            return SubscribeServiceAsync(m_todoAppDAL.CountItemsAsync, "TodoAppService.CountItemsAsync");
        }

        public Task<IEnumerable<ItemInfo>> FindItemByTodoIdOrderByLastUpdateDesc(int todoId)
        {
            return SubscribeServiceAsync(() => m_todoAppDAL.FindItemByTodoIdOrderByLastUpdateDesc(todoId), "TodoAppService.FindItemByTodoIdOrderByLastUpdateDesc");
        }


        public ItemInfo SaveItem(ItemInfo itemInfo)
        {
            //TODO:
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

       

        #endregion
    }
}
