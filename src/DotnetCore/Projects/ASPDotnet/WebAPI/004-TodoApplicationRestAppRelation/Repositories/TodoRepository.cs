using CSD.TodoApplicationRestApp.Configuration;
using CSD.TodoApplicationRestApp.Entities;
using CSD.Util.Data.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

using static CSD.Util.Error.ExceptionUtil;

namespace CSD.TodoApplicationRestApp.Repositories
{
    public class TodoRepository : ITodoRepository
    {        
        private const string ms_insertSqlCommandStr = "insert into TodoInfo (Title, Description) values (@Title, @Description)";
        private const string ms_countSqlCommandStr = "select count(*) from TodoInfo";
        private const string ms_selectAllSqlCommandStr = "select * from TodoInfo";
        private const string ms_selectByMonthSqlCommandStr = "select * from TodoInfo where month(CreateDateTime)=@month";
        private const string ms_selectByMonthAndYearSqlCommandStr = "select * from TodoInfo where month(CreateDateTime)=@month and year(CreateDateTime)=@year";
        private const string ms_selectByItemIdSqlCommanStr = 
            "select t.Title, t.Description, t.CreateDateTime, i.Text, i.LastUpdate" + 
            " from TodoInfo t inner join ItemInfo i on t.Id=i.TodoId where i.Id=@ItemId";        

        private readonly ConnectionConfig m_connectionConfig;
        private readonly SqlConnection m_connection;        

        private TodoInfo getTodoInfo(SqlDataReader reader)
        {
            return new() { Id = (int)reader[0], Title = (string)reader[1], Description = (string)reader[2], 
                CreateDateTime = (DateTime)reader[3], Completed = (bool)reader[4] };
        }

        private TodoInfoItem getTodoInfoItem(SqlDataReader reader)
        {
            return new()
            {                
                Title = (string)reader[0],
                Description = (string)reader[1],
                CreateDateTime = (DateTime)reader[2],
                Text = (string)reader[3],
                LastUpdate = (DateTime)reader[4],
            };
        }

        private void closeConnection()
        {
            if (m_connection.State == System.Data.ConnectionState.Open)
                m_connection.Close();
        }

        #region callbacks
        private long countCallback()
        {
            var command = new SqlCommand(ms_countSqlCommandStr, m_connection);
            m_connection.Open();
            var reader = command.ExecuteReader();

            reader.Read();

            return (int)reader[0];
        }

        private IEnumerable<TodoInfo> findAllCallback()
        {
            var command = new SqlCommand(ms_selectAllSqlCommandStr, m_connection);
            var list = new List<TodoInfo>();
            m_connection.Open();
            var reader = command.ExecuteReader();

            while (reader.Read())
                list.Add(getTodoInfo(reader));

            return list;            
        }

        private TodoInfoItem findByItemIdCallback(int id)
        {
            var command = new SqlCommand(ms_selectByItemIdSqlCommanStr, m_connection);

            command.Parameters.AddWithValue("@ItemId", id);
            m_connection.Open();
            var reader = command.ExecuteReader();

            return reader.Read() ? getTodoInfoItem(reader) : null;            
        }

        private IEnumerable<TodoInfo> findByMonthCallback(int month)
        {
            var list = new List<TodoInfo>();
            var command = new SqlCommand(ms_selectByMonthSqlCommandStr, m_connection);

            command.Parameters.AddWithValue("@month", month);
            m_connection.Open();
            var reader = command.ExecuteReader();

            while (reader.Read())
                list.Add(getTodoInfo(reader));

            return list;            
        }

        private IEnumerable<TodoInfo> findByMonthAndYear(int month, int year)
        {
            var list = new List<TodoInfo>();
            var command = new SqlCommand(ms_selectByMonthAndYearSqlCommandStr, m_connection);

            command.Parameters.AddWithValue("@month", month);
            command.Parameters.AddWithValue("@year", year);
            m_connection.Open();
            var reader = command.ExecuteReader();

            while (reader.Read())
                list.Add(getTodoInfo(reader));

            return list;
        }

        private TodoInfo saveCallback(TodoInfo todoInfo)
        {
            var command = new SqlCommand(ms_insertSqlCommandStr, m_connection);

            command.Parameters.AddWithValue("@Title", todoInfo.Title);
            command.Parameters.AddWithValue("@Description", todoInfo.Description);
            m_connection.Open();

            command.ExecuteNonQuery();

            return todoInfo;            
        }
        #endregion

        public TodoRepository(ConnectionConfig connectionConfig)
        {
            m_connectionConfig = connectionConfig;
            m_connection = new(m_connectionConfig.ConnectionString);
        }

        public Task<long> CountAsync()
        {
            return SubscribeAsync(() => new Task<long>(countCallback), () => new Task(closeConnection));
        }

        public Task<IEnumerable<TodoInfo>> FindAllAsync()
        {
            return SubscribeAsync(() => new Task<IEnumerable<TodoInfo>>(findAllCallback), () => new Task(closeConnection));
        }

        public Task<TodoInfoItem> FindByItemIdAsync(int id)
        {
            return SubscribeAsync(() => new Task<TodoInfoItem>(() => findByItemIdCallback(id)), () => new Task(closeConnection));
        }

        public Task<IEnumerable<TodoInfo>> FindByMonthAsync(int month)
        {
            return SubscribeAsync(() => new Task<IEnumerable<TodoInfo>>(() => findByMonthCallback(month)), () => new Task(closeConnection));
        }

        public Task<IEnumerable<TodoInfo>> FindByMonthAndYearAsync(int month, int year)
        {
            return SubscribeAsync(() => new Task<IEnumerable<TodoInfo>>(() => findByMonthAndYear(month, year)), () => new Task(closeConnection));
        }

        public Task<TodoInfo> SaveAsync(TodoInfo todoInfo)
        {
            return SubscribeAsync(() => new Task<TodoInfo>(() => saveCallback(todoInfo)), () => new Task(closeConnection));
        }        

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Delete(TodoInfo entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteAll()
        {
            throw new NotImplementedException();
        }

        public void DeleteAll(IEnumerable<TodoInfo> entities)
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

        
        public TodoInfo FindById(int id)
        {
            throw new NotImplementedException();
        }        

        public IEnumerable<TodoInfo> SaveAll(IEnumerable<TodoInfo> entities)
        {
            throw new NotImplementedException();
        }        

        public IEnumerable<TodoInfo> FindByYear(int year)
        {
            throw new NotImplementedException();
        }        

        public Task DeleteAsync(TodoInfo entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task DeleteAllAsync(IEnumerable<TodoInfo> entities)
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

        public Task<TodoInfo> FindByIdAsync(int id)
        {
            throw new NotImplementedException();
        }        

        public Task<IEnumerable<TodoInfo>> SaveAllAsync(IEnumerable<TodoInfo> entities)
        {
            throw new NotImplementedException();
        }

        public long Count()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TodoInfo> FindByMonth(int month)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TodoInfo> FindByMonthAndYear(int month, int year)
        {
            throw new NotImplementedException();
        }

        public TodoInfoItem FindByItemId(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TodoInfo> FindAll()
        {
            throw new NotImplementedException();
        }

        TodoInfo ICrudRepository<TodoInfo, int>.Save(TodoInfo entity)
        {
            throw new NotImplementedException();
        }
        

        public Task<IEnumerable<TodoInfo>> FindByYearAsync(int year)
        {
            throw new NotImplementedException();
        }
    }
}
