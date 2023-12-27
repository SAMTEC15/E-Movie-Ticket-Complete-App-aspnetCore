using E_MovieTicket.Persistence.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace E_MovieTicket.Controllers
{
    public class ProducersController : Controller
    {
        private readonly IProducerRepository _producerRepository;

        public ProducersController(IProducerRepository producerRepository)
        {
            _producerRepository = producerRepository;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _producerRepository.GetAllProducers();
            return View();
        }
    }
}
