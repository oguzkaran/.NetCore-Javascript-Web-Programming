using CSD.TodoApplicationRestApp.Entities;
using CSD.TodoApplicationRestApp.Errors;

using CSD.Util.Data.Service;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

using static CSD.Util.Error.ExceptionUtil;

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
        public async Task<IActionResult> CountTodosAsync()
        {            
            try
            {
                return new ObjectResult(new { Count =  await m_todoAppService.CountTodosAsync() });
            }
            catch (DataServiceException ex)
            {
                return NotFound(new ErrorInfo { Message = ex.Message, Status = 404, Detail = "Internal DB problem"});
            }
        }

        [HttpGet("todos/all")]
        public async Task<IActionResult> FindAllAsync()
        {
            try
            {
                return new ObjectResult(await m_todoAppService.FindAllTodosAsync());
            }
            catch (DataServiceException ex)
            {
                return NotFound(new ErrorInfo { Message = ex.Message, Status = 404, Detail = "Internal DB problem" });
            }
        }


        [HttpGet("todos/find/item")]
        public async Task<IActionResult> FindTodoByItemIdAsync(int id)
        {
            try
            {
                var todo = await m_todoAppService.FindTodoByItemIdAsync(id);

                return todo != null ? new ObjectResult(todo) : NotFound();
            }
            catch (DataServiceException ex)
            {
                return BadRequest(new ErrorInfo { Message = ex.Message, Status = 400, Detail = "Internal DB problem" });
            }
        }


        [HttpGet("todos/find/cdate/month")]
        public async Task<IActionResult> FindTodosByMonthAsync(int mon)
        {
            try
            {
                return new ObjectResult(await m_todoAppService.FindTodosByMonthAsync(mon));
            }
            catch (DataServiceException ex)
            {
                return NotFound(new ErrorInfo { Message = ex.Message, Status = 404, Detail = "Internal DB problem" });
            }
        }

        [HttpGet("todos/find/cdate/monyear")]
        public async Task<IActionResult> FindTodosByMonthAndYearAsync(int mon, int year)
        {
            try
            {
                return new ObjectResult(await m_todoAppService.FindTodosByMonthAndYearAsync(mon, year));
            }
            catch (DataServiceException ex)
            {
                return NotFound(new ErrorInfo { Message = ex.Message, Status = 404, Detail = "Internal DB problem" });
            }
        }        

        [HttpPost]
        public async Task<IActionResult> SaveTodoAsync([FromBody] TodoInfo todoInfo)
        {
            try
            {
                return new ObjectResult(await m_todoAppService.SaveTodo(todoInfo));
            }
            catch (DataServiceException ex)
            {
                return NotFound(new ErrorInfo { Message = ex.Message, Status = 404, Detail = "Internal DB problem" });
            }
        }

    }
}
