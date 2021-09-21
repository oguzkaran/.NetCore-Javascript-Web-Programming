using CSD.TodoApplicationRestApp.Factory;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSD.TodoApplicationRestApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly TodoRandomFactory m_randomFactory;

        public TodoController(TodoRandomFactory factory)
        {
            m_randomFactory = factory;
        }

        [HttpGet("all")]
        public IEnumerable<TodoInfo> FindAll()
        {
            return m_randomFactory.All;
        }

        [HttpGet("todos/randoms")]
        public IEnumerable<TodoInfo> FindTodosByCount(string count)
        {
            return int.TryParse(count, out int result) ? FindTodosByCount(result) : new List<TodoInfo>();
        }

        [HttpGet("todos/random")]
        public IEnumerable<TodoInfo> FindTodosByCount(int count)
        {            
            var todos = new List<TodoInfo>();

            for (int i = 0; i < count; ++i)
                todos.Add(m_randomFactory.RandomTodo);

            return todos;
        }

        [HttpGet("todo/random")]
        public TodoInfo FindTodo()
        {
            return m_randomFactory.RandomTodo;
        }
    }
}
