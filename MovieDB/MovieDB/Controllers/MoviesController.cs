using Microsoft.AspNetCore.Mvc;
using MovieDB.Service;
using RestSharp;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MovieDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly MovieService _movieService;

        public MoviesController(MovieService movieService)
        {
            _movieService = movieService;
        }

        public IActionResult GetPopularMovies()
        {
            var popularMovies = _movieService.GetPopularMovies().Result; // Using .Result for simplicity (avoid in production)
            return Ok(popularMovies);
        }
    }
}
