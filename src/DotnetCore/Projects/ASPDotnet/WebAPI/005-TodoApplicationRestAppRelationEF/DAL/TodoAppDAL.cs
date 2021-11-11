using CSD.TodoApplicationRestApp.Entities;
using CSD.TodoApplicationRestApp.Repositories;
using CSD.Util.Data.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static CSD.Data.DatabaseUtil;

namespace CSD.TodoApplicationRestApp.DAL
{
    public class TodoAppDAL
    {
        private readonly ITodoRepository m_todoRepository;
        private readonly IItemRepository m_itemRepository;
       
        public TodoAppDAL(ITodoRepository todoRepository, IItemRepository itemRepository)
        {
            m_todoRepository = todoRepository;
            m_itemRepository = itemRepository;
        }

        #region TodoInfo
        public Task<long> CountTodosAsync()
        {
            return SubscribeRepositoryAsync(m_todoRepository.CountAsync, "TodoAppDAL.CountTodosAsync");            
        }

        public Task<IEnumerable<TodoInfo>> FindAllTodosAsync()
        {
            return SubscribeRepositoryAsync(m_todoRepository.FindAllAsync, "TodoAppDAL.FindAllTodosAsync");
        }

        public Task<TodoInfoItem> FindTodoByItemIdAsync(int id)
        {
            return SubscribeRepositoryAsync(() => m_todoRepository.FindByItemIdAsync(id), "TodoAppDAL.FindTodoByItemIdAsync");           
        }

        public Task<IEnumerable<TodoInfo>> FindTodosByMonthAsync(int month)
        {
            return SubscribeRepositoryAsync(() => m_todoRepository.FindByMonthAsync(month), "TodoAppDAL.FindTodosByMonthAsync");
        }

        public Task<IEnumerable<TodoInfo>> FindTodosByYearAsync(int year)
        {
            return SubscribeRepositoryAsync(() => m_todoRepository.FindByYearAsync(year), "TodoAppDAL.FindTodosByYearAsync");
        }

        public Task<IEnumerable<TodoInfo>> FindTodosByMonthAndYearAsync(int month,int year)
        {
            return SubscribeRepositoryAsync(() => m_todoRepository.FindByMonthAndYearAsync(month, year), "TodoAppDAL.FindTodosByMonthAndYearAsync");
        }

        public Task<TodoInfo> SaveTodoInfoAsync(TodoInfo todoInfo)
        {
            return SubscribeRepositoryAsync(() => m_todoRepository.SaveAsync(todoInfo), "TodoAppDAL.FindTodosByMonthAndYearAsync");            
        }
        #endregion

        #region ItemInfo

        public Task<long> CountItemsAsync()
        {
            return SubscribeRepositoryAsync(m_itemRepository.CountAsync, "TodoAppDAL.CountItemsAsync");
        }

        public Task<IEnumerable<ItemInfo>> FindItemByTodoIdOrderByLastUpdateDesc(int todoId)
        {
            return SubscribeRepositoryAsync(() => m_itemRepository.FindByTodoIdOrderByLastUpdateDesc(todoId), "TodoAppDAL.FindItemByTodoIdOrderByLastUpdateDesc");
        }


        public ItemInfo SaveItemInfo(ItemInfo itemInfo)
        {
            //TODO:
            try
            {
                return m_itemRepository.Save(itemInfo);
            }
            catch (Exception ex)
            {
                throw new RepositoryException("TodoAppDAL.SaveItemInfo", ex);
            }
        }

        #endregion
        //...
    }
}
