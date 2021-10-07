using CSD.TodoApplicationRestApp.Configuration;
using CSD.TodoApplicationRestApp.Entities;
using CSD.Util.Data.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

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

        public TodoRepository(ConnectionConfig connectionConfig)
        {
            m_connectionConfig = connectionConfig;
            m_connection = new(m_connectionConfig.ConnectionString);
        }

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

        public long Count()
        {
            try
            {
                var command = new SqlCommand(ms_countSqlCommandStr, m_connection);
                m_connection.Open();
                var reader = command.ExecuteReader();

                reader.Read();

                return (int)reader[0];
            }
            finally
            {
                if (m_connection.State == System.Data.ConnectionState.Open)
                    m_connection.Close();
            }
        }
        public IEnumerable<TodoInfo> FindAll()
        {
            try
            {
                var command = new SqlCommand(ms_selectAllSqlCommandStr, m_connection);
                var list = new List<TodoInfo>();
                m_connection.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                    list.Add(getTodoInfo(reader));

                return list;
            }
            finally
            {
                if (m_connection.State == System.Data.ConnectionState.Open)
                    m_connection.Close();
            }
        }

        public TodoInfoItem FindByItemId(int id)
        {
            try
            {                
                var command = new SqlCommand(ms_selectByItemIdSqlCommanStr, m_connection);

                command.Parameters.AddWithValue("@ItemId", id);
                m_connection.Open();
                var reader = command.ExecuteReader();

                return reader.Read() ? getTodoInfoItem(reader) : null;
            }
            finally
            {
                if (m_connection.State == System.Data.ConnectionState.Open)
                    m_connection.Close();
            }
        }       

        public IEnumerable<TodoInfo> FindByMonth(int month)
        {
            try
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
            finally
            {
                if (m_connection.State == System.Data.ConnectionState.Open)
                    m_connection.Close();
            }
        }        

        public IEnumerable<TodoInfo> FindByMonthAndYear(int month, int year)
        {
            try
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
            finally
            {
                if (m_connection.State == System.Data.ConnectionState.Open)
                    m_connection.Close();
            }
        }

        public TodoInfo Save(TodoInfo todoInfo)
        {
            try
            {
                var command = new SqlCommand(ms_insertSqlCommandStr, m_connection);

                command.Parameters.AddWithValue("@Title", todoInfo.Title);
                command.Parameters.AddWithValue("@Description", todoInfo.Description);
                m_connection.Open();

                command.ExecuteNonQuery();
            }
            finally {
                if (m_connection.State == System.Data.ConnectionState.Open)
                    m_connection.Close();
            }

            return todoInfo;
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

        
    }
}
