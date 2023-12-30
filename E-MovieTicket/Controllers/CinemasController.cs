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
                return View();
            }
            await _cinemasService.AddCinema(cinema);
            return RedirectToAction(nameof(Index));
        }
    }
}
