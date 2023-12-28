using E_MovieTicket.Application.Interfaces;
using E_MovieTicket.Domain.Models;
using E_MovieTicket.Persistence.Context;
using E_MovieTicket.Persistence.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace E_MovieTicket.Controllers
{
    public class ActorsController : Controller
    {
        private readonly IActorsService _actorsService;

        public ActorsController(IActorsService actorsService)
        {
            _actorsService = actorsService;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _actorsService.GetAllActors();
            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("FirstName, LastName, ProfilePictureUrl, Biography")] Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            await _actorsService.AddActor(actor);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var actorDetails = await _actorsService.GetActorById(id);
            if (actorDetails == null)
                return View("NotFound");
            return View(actorDetails);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var actorDetails = await _actorsService.GetActorById(id);
            if (actorDetails == null)
                return View("NotFound");
            return View(actorDetails);

        }
        [HttpPost]
        public async Task<IActionResult> Edit([Bind("FirstName, LastName, ProfilePictureUrl, Biography")] Actor actor, int id)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }
            var update = await _actorsService.UpdateActor(id, actor);
            if (update == null)
                return View("NotFound");
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var actorDetails = await _actorsService.GetActorById(id);
            if (actorDetails == null)
                return View("NotFound");
            return View(actorDetails);

        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteActor(int id)
        {
            var actorDetails = await _actorsService.GetActorById(id);
            if (actorDetails == null)
                return View("NotFound");
            var deleteActor = await _actorsService.RemoveActor(id);
            if (deleteActor == null)
                return View("NotFound");
            return RedirectToAction(nameof(Index));
        }
    }
}
