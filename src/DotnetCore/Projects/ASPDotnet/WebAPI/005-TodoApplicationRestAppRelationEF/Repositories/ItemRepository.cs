using CSD.TodoApplicationRestApp.Configuration;
using CSD.TodoApplicationRestApp.Data;
using CSD.TodoApplicationRestApp.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using static CSD.Util.TPL.TaskUtil;

namespace CSD.TodoApplicationRestApp.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private const string ms_insertSqlCommandStr = "insert into ItemInfo (TodoId, Text) values (@TodoId, @Text)";
        private const string ms_countSqlCommandStr = "select count(*) from ItemInfo";
        private const string ms_findByTodoIdLastUpdateDescSqlComdStr =
            "select * from ItemInfo where TodoId = @TodoId order by LastUpdate desc";

        private readonly ConnectionConfig m_connectionConfig;
        private readonly SqlConnection m_connection;

        private readonly TodoDbContext m_todoDbContext;

        private ItemInfo getItemInfo(SqlDataReader dataReader)
        {
            return new()
            {
                Id = (int)dataReader[0],
                TodoId = (int)dataReader[1],
                Text = dataReader[2].ToString(),
                CreateDateTime = (DateTime)dataReader[3],
                LastUpdate = (DateTime)dataReader[4],
                Completed = (bool)dataReader[5]
            };
        }

        #region callbacks
        private long countCallback()
        {
            return m_todoDbContext.ItemInfos.LongCount();
        }

        public IEnumerable<ItemInfo> findByTodoIdOrderByLastUpdateDesc(int todoId)
        {
            return m_todoDbContext.ItemInfos.Where(i => i.TodoId == todoId).OrderBy(i => i.LastUpdate);               
        }

        #endregion

        public ItemRepository(TodoDbContext todoDbContext)
        {
            m_todoDbContext = todoDbContext;
        }

        public Task<long> CountAsync()
        {
            return Create(countCallback);                          
        }

        public Task<IEnumerable<ItemInfo>> FindByTodoIdOrderByLastUpdateDesc(int todoId)
        {
            return Create(() => findByTodoIdOrderByLastUpdateDesc(todoId));
        }

        public ItemInfo Save(ItemInfo itemInfo)
        {

            //TODO:
            try
            {
                var command = new SqlCommand(ms_insertSqlCommandStr, m_connection);

                command.Parameters.AddWithValue("@TodoId", itemInfo.TodoId);
                command.Parameters.AddWithValue("@Text", itemInfo.Text);
                m_connection.Open();

                command.ExecuteNonQuery();
            }
            finally
            {
                if (m_connection.State == System.Data.ConnectionState.Open)
                    m_connection.Close();
            }

            return itemInfo;
        }


        /////////////////////////////////////////////////////////////////////////////////////
        
        public void Delete(ItemInfo entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteAll()
        {
            throw new NotImplementedException();
        }

        public void DeleteAll(IEnumerable<ItemInfo> entities)
        {
            throw new NotImplementedException();
        }

        public void DeleteAllById(IEnumerable<int> ids)
        {
            throw new NotImplementedException();
        }

        public void DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public bool ExistsById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ItemInfo> FindAll()
        {
            throw new NotImplementedException();
        }

        public ItemInfo FindById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ItemInfo> SaveAll(IEnumerable<ItemInfo> entities)
        {
            throw new NotImplementedException();
        }

        public long Count()
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(ItemInfo entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task DeleteAllAsync(IEnumerable<ItemInfo> entities)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAllByIdAsync(IEnumerable<int> ids)
        {
            throw new NotImplementedException();
        }

        public Task DeleteByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistsByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ItemInfo>> FindAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ItemInfo> FindByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ItemInfo> SaveAsync(ItemInfo entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ItemInfo>> SaveAllAsync(IEnumerable<ItemInfo> entities)
        {
            throw new NotImplementedException();
        }
    }
}
