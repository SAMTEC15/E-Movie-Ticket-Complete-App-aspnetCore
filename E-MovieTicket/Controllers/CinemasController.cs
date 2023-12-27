using E_MovieTicket.Persistence.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace E_MovieTicket.Controllers
{
    public class CinemasController : Controller
    {
        private readonly ICinemaRepository _cinemaRepository;

        public CinemasController(ICinemaRepository cinemaRepository)
        {
            _cinemaRepository = cinemaRepository;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _cinemaRepository.GetAllCinemas();
            return View(data);
        }
    }
}
