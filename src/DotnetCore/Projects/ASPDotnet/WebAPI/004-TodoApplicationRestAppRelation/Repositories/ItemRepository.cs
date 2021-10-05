using CSD.TodoApplicationRestApp.Configuration;
using CSD.TodoApplicationRestApp.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CSD.TodoApplicationRestApp.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private const string ms_insertSqlCommandStr = "insert into ItemInfo (TodoId, Text) values (@TodoId, @Text)";

        private readonly ConnectionConfig m_connectionConfig;
        private readonly SqlConnection m_connection;

        public ItemRepository(ConnectionConfig connectionConfig)
        {
            m_connectionConfig = connectionConfig;
            m_connection = new(m_connectionConfig.ConnectionString);
        }

        public long Count()
        {
            //TODO:
            throw new NotImplementedException();
        }

        public IEnumerable<ItemInfo> FindByTodoIdOrderByLastUpdateDesc(int todoId)
        {
            //TODO: lastUpdate'e göre azalan sırada gelsin
            throw new NotImplementedException();
        }

        public ItemInfo Save(ItemInfo itemInfo)
        {
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

        
    }
}
