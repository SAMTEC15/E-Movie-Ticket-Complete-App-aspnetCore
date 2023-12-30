using E_MovieTicket.Application.Interfaces;
using E_MovieTicket.Application.Services;
using E_MovieTicket.Domain.Models;
using E_MovieTicket.Persistence.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace E_MovieTicket.Controllers
{
    public class ProducersController : Controller
    {
        private readonly IProducersService _producersService;

        public ProducersController(IProducersService producersService)
        {
            _producersService = producersService;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _producersService.GetAllProducers();
            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("FirstName, LastName, ProfilePictureUrl, Biography")] Producer producer)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            await _producersService.AddProducer(producer);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var producerDetails = await _producersService.GetProducersById(id);
            if (producerDetails == null)
                return View("NotFound");
            return View(producerDetails);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var producerDetails = await _producersService.GetProducersById(id);
            if (producerDetails == null)
                return View("NotFound");
            return View(producerDetails);

        }
        [HttpPost]
        public async Task<IActionResult> Edit([Bind("FirstName, LastName, ProfilePictureUrl, Biography")] Producer producer, int id)
        {
            if (!ModelState.IsValid)
            {
                return View(producer);
            }
            if (id == producer.Id)
            {
                var update = await _producersService.UpdateProducer(id, producer);
                if (update == null)
                    return View(producer);
                return RedirectToAction(nameof(Index));
            }
            return View(producer);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var producerDetails = await _producersService.GetProducersById(id);
            if (producerDetails == null)
                return View("NotFound");
            return View(producerDetails);

        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteActor(int id)
        {
            var actorDetails = await _producersService.GetProducersById(id);
            if (actorDetails == null)
                return View("NotFound");
            var deleteActor = await _producersService.RemoveProducer(id);
            //if (deleteActor == null)
            //return View("NotFound");
            return RedirectToAction(nameof(Index));
        }
    }
}
