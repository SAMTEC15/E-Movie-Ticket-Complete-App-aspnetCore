using E_MovieTicket.Application.Interfaces;
using E_MovieTicket.Application.Services;
using E_MovieTicket.Domain.Models;
using E_MovieTicket.Persistence.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace E_MovieTicket.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMoviesService _moviesService;
        public MoviesController(IMoviesService moviesService)
        {           
           _moviesService = moviesService;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _moviesService.GetAllMovies();
            return View(data);
        }
        public async Task<IActionResult> Details(int id)
        {
            var movieDetails = await _moviesService.GetMovieByIdAsync(id);
            return View(movieDetails);
        }
        public async Task<IActionResult> Create()
        {
            var movieDropdownData = await _moviesService.GetNewMovieDropdownsValue();
            ViewBag.CinemaId = new SelectList(movieDropdownData.Cinemas, "Id", "Name");
            ViewBag.CinemaId = new SelectList(movieDropdownData.Producers, "Id", "FirstName");
            ViewBag.CinemaId = new SelectList(movieDropdownData.Actors, "Id", "FirstName");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            await _moviesService.AddMovie(movie);
            return RedirectToAction(nameof(Index));
        }

        
       
  
    }
}
