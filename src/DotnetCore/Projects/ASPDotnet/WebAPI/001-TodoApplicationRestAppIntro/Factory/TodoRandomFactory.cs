using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSD.TodoApplicationRestApp.Factory
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
    }
}
