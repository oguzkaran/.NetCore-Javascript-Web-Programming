using CSD.TodoApplicationRestApp.Configuration;
using CSD.TodoApplicationRestApp.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Linq;

using static CSD.Util.Error.ExceptionUtil;
using CSD.Util.TPL;
using static CSD.Util.TPL.TaskUtil;
using CSD.TodoApplicationRestApp.Data;

namespace CSD.TodoApplicationRestApp.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly TodoDbContext m_dbContext;

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
            return new()
            {
                Id = (int)reader[0],
                Title = (string)reader[1],
                Description = (string)reader[2],
                CreateDateTime = (DateTime)reader[3],
                Completed = (bool)reader[4]
            };
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
            return m_dbContext.TodoInfos.LongCount();            
        }        

        private IEnumerable<TodoInfo> findAllCallback()
        {
            return m_dbContext.TodoInfos.ToList();
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
            return from ti in m_dbContext.TodoInfos
                   where ti.CreateDateTime.Month == month
                   select ti;

            //return m_dbContext.TodoInfos.Where(t => t.CreateDateTime.Month == month);
        }

        private IEnumerable<TodoInfo> findByMonthAndYearCallback(int month, int year)
        {
            return m_dbContext.TodoInfos.Where(t => t.CreateDateTime.Month == month).Where(t => t.CreateDateTime.Year == year);
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

        public TodoRepository(TodoDbContext dbContext)
        {
            m_dbContext = dbContext;
        }

        public Task<long> CountAsync()
        {
            return SubscribeAsync(() => Create(countCallback), ex => throw ex);            
        }

        public Task<IEnumerable<TodoInfo>> FindAllAsync()
        {
            return SubscribeAsync(() => new Task<IEnumerable<TodoInfo>>(findAllCallback).Create(), ex => throw ex);
        }

        public Task<TodoInfoItem> FindByItemIdAsync(int id)
        {
            return SubscribeAsync(() => new Task<TodoInfoItem>(() => findByItemIdCallback(id)).Create(), 
                () => new Task(closeConnection).Create());
        }

        public Task<IEnumerable<TodoInfo>> FindByMonthAsync(int month)
        {
            return SubscribeAsync(() => new Task<IEnumerable<TodoInfo>>(() => findByMonthCallback(month)).Create(), ex => throw ex);
        }

        public Task<IEnumerable<TodoInfo>> FindByMonthAndYearAsync(int month, int year)
        {
            return SubscribeAsync(() => new Task<IEnumerable<TodoInfo>>(() => findByMonthAndYearCallback(month, year)).Create(), 
                ex => throw ex);
        }

        public Task<TodoInfo> SaveAsync(TodoInfo todoInfo)
        {
            return SubscribeAsync(() => new Task<TodoInfo>(() => saveCallback(todoInfo)).Create(), () => new Task(closeConnection).Create());
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public Task<IEnumerable<TodoInfo>> FindByYearAsync(int year)
        {
            throw new NotImplementedException();
        }

        public long Count()
        {
            throw new NotImplementedException();
        }

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

        public IEnumerable<TodoInfo> FindAll()
        {
            throw new NotImplementedException();
        }

        public TodoInfo FindById(int id)
        {
            throw new NotImplementedException();
        }

        public TodoInfo Save(TodoInfo entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TodoInfo> SaveAll(IEnumerable<TodoInfo> entities)
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
    }
}
