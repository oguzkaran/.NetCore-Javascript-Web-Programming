using CSD.MovieRestServiceApplication.Data.DTO;
using CSD.MovieRestServiceApplication.Data.Service;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CSD.MovieRestServiceApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly MoviesService m_moviesService;

        public MovieController(MoviesService moviesService)
        {
            m_moviesService = moviesService;
        }

        [HttpGet("find/yearmonth")]
        public async Task<IActionResult> FindMoviesByYearAndMonthAsync(int y, int m)
        {
            return new ObjectResult(await m_moviesService.FindMoviesByYearAndMonthAsync(y, m));
        }

        [HttpGet("find/year")]
        public async Task<IActionResult> FindMoviesByYearAsync(int y)
        {
            return new ObjectResult(await m_moviesService.FindMoviesByYearAsync(y));
        }

        [HttpGet("find/director")]
        public async Task<IActionResult> FindMoviesByDirectorIdAsync(int id)
        {
            return new ObjectResult(await m_moviesService.FindMoviesByDirectorIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> SaveMovieAsync([FromBody] MovieSaveModel movieSaveModel)
        {
            return new ObjectResult(await m_moviesService.SaveMovieAsync(movieSaveModel));
        }

        //...
    }
}
