using CSD.TodoApplicationRestApp.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CSD.TodoApplicationRestApp.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private const string ms_connectionString = @"Server=.;Database=TodoAppDb;Trusted_Connection=True;";
        private readonly static SqlConnection ms_connection = new(ms_connectionString);
        private const string ms_insertSqlCommandStr = "insert into TodoInfo (Title, Text) values (@Title, @Text)";
        private const string ms_countSqlCommandStr = "select count(*) from TodoInfo";
        private const string ms_selectAllSqlCommandStr = "select * from TodoInfo";
        private const string ms_selectByMonthSqlCommandStr = "select * from TodoInfo where month(CreateDateTime)=@month";

        private TodoInfo getTodoInfo(SqlDataReader reader)
        {
            return new TodoInfo { Id = (int)reader[0], Title = (string)reader[1], Text = (string)reader[2], 
                CreateDateTime = (DateTime)reader[3], LastUpdate = (DateTime)reader[4], Completed = (bool)reader[5] };
        }

        public long Count()
        {
            try
            {
                var command = new SqlCommand(ms_countSqlCommandStr, ms_connection);
                ms_connection.Open();
                var reader = command.ExecuteReader();

                reader.Read();

                return (int)reader[0];
            }
            finally
            {
                if (ms_connection.State == System.Data.ConnectionState.Open)
                    ms_connection.Close();
            }
        }
        public IEnumerable<TodoInfo> FindAll()
        {
            try
            {
                var command = new SqlCommand(ms_selectAllSqlCommandStr, ms_connection);
                var list = new List<TodoInfo>();
                ms_connection.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                    list.Add(getTodoInfo(reader));

                return list;
            }
            finally
            {
                if (ms_connection.State == System.Data.ConnectionState.Open)
                    ms_connection.Close();
            }
        }

        public IEnumerable<TodoInfo> FindByMonth(int month)
        {
            try
            {
                var list = new List<TodoInfo>();
                var command = new SqlCommand(ms_selectByMonthSqlCommandStr, ms_connection);

                command.Parameters.AddWithValue("@month", month);                
                ms_connection.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                    list.Add(getTodoInfo(reader));

                return list;
            }
            finally
            {
                if (ms_connection.State == System.Data.ConnectionState.Open)
                    ms_connection.Close();
            }
        }


        public TodoInfo Save(TodoInfo todoInfo)
        {
            try
            {
                var command = new SqlCommand(ms_insertSqlCommandStr, ms_connection);

                command.Parameters.AddWithValue("@Title", todoInfo.Title);
                command.Parameters.AddWithValue("@Text", todoInfo.Text);
                ms_connection.Open();

                command.ExecuteNonQuery();
            }
            finally {
                if (ms_connection.State == System.Data.ConnectionState.Open)
                    ms_connection.Close();
            }

            return todoInfo;
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
