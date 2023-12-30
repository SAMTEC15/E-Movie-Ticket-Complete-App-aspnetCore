using E_MovieTicket.Application.Interfaces;
using E_MovieTicket.Application.Services;
using E_MovieTicket.Domain.Models;
using E_MovieTicket.Persistence.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace E_MovieTicket.Controllers
{
    public class CinemasController : Controller
    {
        private readonly ICinemasService _cinemasService;

        public CinemasController(ICinemasService cinemasService)
        {
            _cinemasService = cinemasService;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _cinemasService.GetAllCinemas();
            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Cinema cinema)
        {
            if (!ModelState.IsValid)
            {
                return View(cinema);
            }
            await _cinemasService.AddCinema(cinema);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var cinemaDetails = await _cinemasService.GetCinemaById(id);
            if (cinemaDetails == null)
                return View("NotFound");
            return View(cinemaDetails);
        }      

        public async Task<IActionResult> Edit(int id)
        {
            var cinemaDetails = await _cinemasService.GetCinemaById(id);
            if (cinemaDetails == null)
                return View("NotFound");
            return View(cinemaDetails);

        }
        [HttpPost]
        public async Task<IActionResult> Edit(Cinema cinema, int id)
        {
            if (!ModelState.IsValid)
            {
                return View(cinema);
            }
            var update = await _cinemasService.UpdateCinema(id, cinema);// await _cinemasService.AddCinema(cinema);
            if (update == null)
                return View("NotFound");
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var actorDetails = await _cinemasService.GetCinemaById(id);
            if (actorDetails == null)
                return View("NotFound");
            return View(actorDetails);

        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteActor(int id)
        {
            var actorDetails = await _cinemasService.GetCinemaById(id);
            if (actorDetails == null)
                return View("NotFound");
            var deleteActor = await _cinemasService.RemoveCinema(id);
            //if (deleteActor == null)
            // return View("NotFound");
            return RedirectToAction(nameof(Index));
        }
    }
}
