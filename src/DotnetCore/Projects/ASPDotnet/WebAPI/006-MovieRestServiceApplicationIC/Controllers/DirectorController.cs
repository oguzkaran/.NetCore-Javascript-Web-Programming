using CSD.MovieRestServiceApplication.Data.DTO;
using CSD.MovieRestServiceApplication.Data.Service;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CSD.MovieRestServiceApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DirectorController : ControllerBase
    {
        private readonly MoviesService m_moviesService;

        public DirectorController(MoviesService moviesService)
        {
            m_moviesService = moviesService;
        }

        [HttpGet("all")]
        public async Task<IActionResult> FindAllDirectorsAsync()
        {
            return new ObjectResult(await m_moviesService.FindAllDirectorsAsync());
        }

        [HttpGet("find/age/greater")]
        public async Task<IActionResult> FindDirectorByAgeGreaterAsync(int t)
        {
            return new ObjectResult(await m_moviesService.FindDirectorByAgeGreaterAsync(t));
        }

        [HttpGet("find/age/less")]
        public async Task<IActionResult> FindDirectorByAgeLessAsync(int t)
        {
            return new ObjectResult(await m_moviesService.FindDirectorByAgeLessAsync(t));
        }

        [HttpPost]
        public async Task<IActionResult> SaveMovieAsync([FromBody] DirectorSaveModel movieSaveModel)
        {
            return new ObjectResult(await m_moviesService.SaveDirectorAsync(movieSaveModel));
        }

        //...
    }
}
