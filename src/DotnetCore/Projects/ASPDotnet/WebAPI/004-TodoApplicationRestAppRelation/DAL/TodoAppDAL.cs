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
        private readonly IItemRepository m_itemRepository;

        public TodoAppDAL(ITodoRepository todoRepository, IItemRepository itemRepository)
        {
            m_todoRepository = todoRepository;
            m_itemRepository = itemRepository;
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

        public TodoInfoItem FindTodoByItemId(int id)
        {
            try
            {
                return m_todoRepository.FindByItemId(id);
            }
            catch (Exception ex)
            {
                throw new RepositoryException("TodoAppDAL.FindTodoByItemId", ex);
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

        public IEnumerable<TodoInfo> FindTodosByMonthAndYear(int month,int year)
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
