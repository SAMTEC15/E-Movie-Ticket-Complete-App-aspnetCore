using E_MovieTicket.Persistence.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace E_MovieTicket.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieRepository _movieRepository;

        public MoviesController(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _movieRepository.GetAllMovies();
            return View(data);
        }
    }
}
