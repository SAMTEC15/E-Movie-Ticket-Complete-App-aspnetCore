using E_MovieTicket.Domain;
using E_MovieTicket.Domain.Models;
using E_MovieTicket.Persistence.Base;

namespace E_MovieTicket.Persistence.Repositories
{
    public interface IProducerRepository : IEntityBaseRepository<Producer>
    {
       // Task<List<Producer>> GetAllProducers();
    }
}
