using E_MovieTicket.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_MovieTicket.Application.Interfaces
{
    public interface IProducersService
    {
        Task<Producer> GetProducersById(int id);
        Task<IEnumerable<Producer>> GetAllProducers();
        Task<Producer> AddProducer(Producer producer);
        Task<Producer> RemoveProducer(int id);
        Task<Producer> UpdateProducer(int id, Producer producer);
        Task<Producer> RemoveAllProducers();
    }
}
