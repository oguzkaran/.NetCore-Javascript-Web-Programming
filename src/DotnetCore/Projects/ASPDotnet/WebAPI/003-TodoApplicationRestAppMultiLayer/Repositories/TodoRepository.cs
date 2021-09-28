using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace CSD.TodoApplicationRestApp.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private const string ms_connectionString = @"Server=.;Database=TodoAppDb;Trusted_Connection=True;";
        private readonly static SqlConnection ms_connection = new(ms_connectionString);
        private const string ms_insertSqlCommandStr = "insert into TodoInfo (Title, Text) values (@Title, @Text)";
        private const string ms_countSqlCommandStr = "select count(*) from TodoInfo";

        public long Count()
        {
            var command = new SqlCommand(ms_countSqlCommandStr, ms_connection);

            try
            {
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


        public TodoInfo Save(TodoInfo todoInfo)
        {
            var command = new SqlCommand(ms_insertSqlCommandStr, ms_connection);

            command.Parameters.AddWithValue("@Title", todoInfo.Title);
            command.Parameters.AddWithValue("@Text", todoInfo.Text);

            try
            {
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

        public IEnumerable<TodoInfo> FindAll()
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
    }
}
