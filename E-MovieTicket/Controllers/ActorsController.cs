using E_MovieTicket.Persistence.Context;
using E_MovieTicket.Persistence.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace E_MovieTicket.Controllers
{
    public class ActorsController : Controller
    {
        private readonly IActorRespository _actorRespository;

        public ActorsController(IActorRespository actorRespository)
        {
            _actorRespository = actorRespository;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _actorRespository.GetAllActor();
            return View(data);
        }
    }
}
