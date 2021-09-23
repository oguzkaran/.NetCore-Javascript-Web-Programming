using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSD.TodoApplicationRestApp.Factories
{
    public class TodoRandomFactory
    {
        private List<TodoInfo> m_todos;
        private readonly Random m_random = new();

        private void loadTodos()
        {
            m_todos = new List<TodoInfo> { 
                new TodoInfo { Title = "Eczane", Text = "Vitamin, Aspirin"},
                new TodoInfo { Title = "Market", Text = "Gofret, Biberon"},
                new TodoInfo { Title = "Okul", Text = "Intro to prog, Software Engin."},
                new TodoInfo { Title = "SüperMarket", Text = "Çay"},
            };
        }

        public TodoRandomFactory()
        {
            loadTodos();    
        }

        public IEnumerable<TodoInfo> All => m_todos;

        public TodoInfo RandomTodo => m_todos[m_random.Next(m_todos.Count)]; 

        public IEnumerable<TodoInfo> FindTodosByTitleContains(string title)
        {
            var list = new List<TodoInfo>();

            foreach (var todo in m_todos) // İleride böyle bir döngü yazmamız gerekmeyecek
                if (todo.Title.Contains(title))
                    list.Add(todo);

            return list;
        }        

        public IEnumerable<TodoInfo> FindTodosByCount(int count)
        {
            var list = new List<TodoInfo>();

            int n = count < m_todos.Count ? count : m_todos.Count;

            for (var i = 0; i < n; ++i)
                list.Add(m_todos[i]);

            return list;           
        }

        public IEnumerable<TodoInfo> FindRandomTodosByCount(int count)
        {
            var list = new List<TodoInfo>();

            for (var i = 0; i < count; ++i)
                list.Add(RandomTodo);

            return list;

        }
    }
}
