using E_MovieTicket.Persistence.Context;
using E_MovieTicket.Persistence.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_MovieTicket.Controllers
{
    public class ActorsController : Controller
    {
        private readonly EMovieTicketDbContext _eMovieTicketDbContext;

        public ActorsController(EMovieTicketDbContext eMovieTicketDbContext)
        {
            _eMovieTicketDbContext = eMovieTicketDbContext;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _eMovieTicketDbContext.Actors.ToListAsync();
            return View(data);
        }
    }
}
