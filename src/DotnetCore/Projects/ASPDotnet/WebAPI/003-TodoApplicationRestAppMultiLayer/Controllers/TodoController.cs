using CSD.TodoApplicationRestApp.Errors;

using CSD.Util.Data.Service;
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
        private readonly TodoAppService m_todoAppService;

        public TodoController(TodoAppService todoAppService)
        {
            m_todoAppService = todoAppService;
        }

        [HttpGet("todos/count")]
        public IActionResult CountTodos()
        {
            try
            {
                return new ObjectResult(new { Count =  m_todoAppService.CountTodos() });
            }
            catch (DataServiceException ex)
            {
                return NotFound(new ErrorInfo { Message = ex.Message, Status = 404, Detail = "Internal DB problem"});
            }
        }


        [HttpPost]
        public IActionResult SaveTodo([FromBody] TodoInfo todoInfo)
        {
            try
            {
                return new ObjectResult(m_todoAppService.SaveTodo(todoInfo));
            }
            catch (DataServiceException ex)
            {
                return NotFound(new ErrorInfo { Message = ex.Message, Status = 404, Detail = "Internal DB problem" });
            }
        }

    }
}
