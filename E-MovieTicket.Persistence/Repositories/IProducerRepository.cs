using E_MovieTicket.Domain.Models;

namespace E_MovieTicket.Persistence.Repositories
{
    public interface IProducerRepository
    {
        Task<List<Producer>> GetAllProducers();
    }
}
