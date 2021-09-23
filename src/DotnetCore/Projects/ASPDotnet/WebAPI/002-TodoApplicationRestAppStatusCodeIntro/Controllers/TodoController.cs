using CSD.TodoApplicationRestApp.Errors;
using CSD.TodoApplicationRestApp.Factories;
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
        public IActionResult FindAll()
        {
            try
            {
                return new ObjectResult(m_randomFactory.All);
            }
            catch (Exception) {
                return NotFound();
            }
        }

        [HttpGet("todos/randoms")]
        public IActionResult FindRandomTodosByCount(string count)
        {
            IActionResult actionResult;

            try
            {
                actionResult = new ObjectResult(m_randomFactory.FindRandomTodosByCount(int.Parse(count)));
            }
            catch (Exception ex) {
                actionResult = BadRequest(new ErrorInfo { Message = ex.Message, Data = count, Status = 400});
            }

            return actionResult;
        }

        [HttpGet("todos")]
        public IActionResult FindTodosByCount(string count)
        {
            IActionResult actionResult;

            try
            {
                actionResult = new ObjectResult(m_randomFactory.FindTodosByCount(int.Parse(count)));
            }
            catch (Exception)
            {
                actionResult = BadRequest();
            }

            return actionResult;
        }

        [HttpGet("todos/find")]
        public IActionResult FindTodosByTitleContains(string title)
        {
            try
            {
                return new ObjectResult(m_randomFactory.FindTodosByTitleContains(title));
            }
            catch (Exception) {
                return BadRequest();
            }
        }
    }
}
