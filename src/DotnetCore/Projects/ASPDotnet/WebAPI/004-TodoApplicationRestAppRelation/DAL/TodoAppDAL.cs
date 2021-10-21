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

        public Task<IEnumerable<TodoInfo>> FindTodosByMonthAndYearAsync(int month,int year)
        {
            return SubscribeRepositoryAsync(() => m_todoRepository.FindByMonthAndYearAsync(month, year), "TodoAppDAL.FindTodosByMonthAndYearAsync");
        }

        public Task<TodoInfo> SaveTodoInfoAsync(TodoInfo todoInfo)
        {
            return SubscribeRepositoryAsync(() => m_todoRepository.SaveAsync(todoInfo), "TodoAppDAL.FindTodosByMonthAndYearAsync");            
        }

        

        public long CountItems()
        {
            try
            {
                return m_itemRepository.Count();
            }
            catch (Exception ex)
            {
                throw new RepositoryException("TodoAppDAL.CountItems", ex);
            }
        }

        public IEnumerable<ItemInfo> FindItemByTodoIdOrderByLastUpdateDesc(int todoId)
        {
            try
            {
                return m_itemRepository.FindByTodoIdOrderByLastUpdateDesc(todoId);
            }
            catch (Exception ex)
            {
                throw new RepositoryException("TodoAppDAL.FindItemByTodoIdOrderByLastUpdateDesc", ex);
            }
        }


        public ItemInfo SaveItemInfo(ItemInfo itemInfo)
        {
            try
            {
                return m_itemRepository.Save(itemInfo);
            }
            catch (Exception ex)
            {
                throw new RepositoryException("TodoAppDAL.SaveItemInfo", ex);
            }
        }        
        
        //...
    }
}
