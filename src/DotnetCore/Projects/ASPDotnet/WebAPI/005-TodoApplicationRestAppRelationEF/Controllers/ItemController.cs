using CSD.TodoApplicationRestApp.Entities;
using CSD.TodoApplicationRestApp.Errors;

using CSD.Util.Data.Service;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CSD.TodoApplicationRestApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly TodoAppService m_todoAppService;

        public ItemController(TodoAppService todoAppService)
        {
            m_todoAppService = todoAppService;
        }

        [HttpGet("items/todo")]
        public IEnumerable<ItemInfo> FindItemByTodoIdOrderByLastUpdateDesc(int id)
        {
            return m_todoAppService.FindItemByTodoIdOrderByLastUpdateDesc(id);
        }

        [HttpGet("items/count")]
        public IActionResult CountItems()
        {
            try
            {
                return new ObjectResult(new { Count = m_todoAppService.CountItems() });
            }
            catch (DataServiceException ex)
            {
                return NotFound(new ErrorInfo { Message = ex.Message, Status = 404, Detail = "Internal DB problem" });
            }
        }


        [HttpPost]
        public IActionResult SaveItem([FromBody] ItemInfo itemInfo)
        {
            try
            {
                return new ObjectResult(m_todoAppService.SaveItem(itemInfo));
            }
            catch (DataServiceException ex)
            {
                return NotFound(new ErrorInfo { Message = ex.Message, Status = 404, Detail = "Internal DB problem" });
            }
        }

    }
}
