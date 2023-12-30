using E_MovieTicket.Application.Interfaces;
using E_MovieTicket.Application.Services;
using E_MovieTicket.Domain.Models;
using E_MovieTicket.Domain.ViewModels;
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
        public async Task<IActionResult> filter(string searchString)
        {
            var data = await _moviesService.GetAllMovies();
            if (!string.IsNullOrWhiteSpace(searchString))
            {
                var filteredResult = data.Where(u => u.Title.Contains(searchString) || 
                u.Description.Contains(searchString)).ToList();
                return View("Index", filteredResult);
            }
                return View("Index", data);
        }
        public async Task<IActionResult> Details(int id)
        {
            var movieDetails = await _moviesService.GetMovieByIdAsync(id);
            return View(movieDetails);
        }
        public async Task<IActionResult> Create()
        {
            var movieDropdownData = await _moviesService.GetNewMovieDropdownsValue();
            ViewBag.Cinemas = new SelectList(movieDropdownData.Cinemas, "Id", "Name");
            ViewBag.Producers = new SelectList(movieDropdownData.Producers, "Id", "FirstName");
            ViewBag.Actors = new SelectList(movieDropdownData.Actors, "Id", "FirstName");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewMovieVM newMovie)
        {
            if (!ModelState.IsValid)
            {
                var movieDropdownData = await _moviesService.GetNewMovieDropdownsValue();
                ViewBag.Cinemas = new SelectList(movieDropdownData.Cinemas, "Id", "Name");
                ViewBag.Producers = new SelectList(movieDropdownData.Producers, "Id", "FirstName");
                ViewBag.Actors = new SelectList(movieDropdownData.Actors, "Id", "FirstName");

                return View();
            }
            await _moviesService.AddNewMovieAsync(newMovie);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var movieDetails = await _moviesService.GetMovieByIdAsync(id);
            if(movieDetails == null)
                return View("NotFound");
            var response = new NewMovieVM
            {
                Id = movieDetails.Id,
                Title = movieDetails.Title,
                Description = movieDetails.Description,
                Price = movieDetails.Price,
                ImageUrl = movieDetails.ImageUrl,
                MovieCategory = movieDetails.MovieCategory,
                StartDate = movieDetails.StartDate,
                EndDate = movieDetails.EndDate,
                CinemaId = movieDetails.CinemaId,
                ProducerId = movieDetails.ProducerId,
                ActorIds = movieDetails.ActorMovies.Select(u => u.ActorId).ToList(),
            };
            var movieDropdownData = await _moviesService.GetNewMovieDropdownsValue();
            ViewBag.Cinemas = new SelectList(movieDropdownData.Cinemas, "Id", "Name");
            ViewBag.Producers = new SelectList(movieDropdownData.Producers, "Id", "FirstName");
            ViewBag.Actors = new SelectList(movieDropdownData.Actors, "Id", "FirstName");
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewMovieVM newMovie)
        {
            if(id != newMovie.Id)
                return View("NotFound");
            if (!ModelState.IsValid)
            {
                var movieDropdownData = await _moviesService.GetNewMovieDropdownsValue();
                ViewBag.Cinemas = new SelectList(movieDropdownData.Cinemas, "Id", "Name");
                ViewBag.Producers = new SelectList(movieDropdownData.Producers, "Id", "FirstName");
                ViewBag.Actors = new SelectList(movieDropdownData.Actors, "Id", "FirstName");

                return View();
            }
            await _moviesService.UpdateMovieAsync(id, newMovie);
            return RedirectToAction(nameof(Index));
        }


    }
}
