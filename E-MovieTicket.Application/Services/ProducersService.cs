using E_MovieTicket.Application.Interfaces;
using E_MovieTicket.Domain.Models;
using E_MovieTicket.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace E_MovieTicket.Application.Services
{
    public class ProducersService : IProducersService
    {
        private readonly IProducerRepository _producerRepository;

        public ProducersService(IProducerRepository producerRepository)
        {
            _producerRepository = producerRepository;
        }
        public async Task<Producer> AddProducer(Producer producer)
        {
            var addProducer = await _producerRepository.AddAsync(producer);
            if (addProducer == null)
            {
                return null;
            }
            return addProducer;
        }

        public Task<IEnumerable<Producer>> GetAllProducers() => _producerRepository.GetAllAsync();
        

        public async Task<Producer> GetProducersById(int id)
        {
            if (id == null)
                return null;
            var details = await _producerRepository.GetByIdAsync(id);
            if (details == null)
                return null;
            return details;
        }

        public Task<Producer> RemoveAllProducers()
        {
           throw new NotImplementedException();
        }

        public async Task<Producer> RemoveProducer(int id)
        {
            if (id == null)
                return null;
            var actor = await _producerRepository.DeleteAsync(id);
            return actor; 
        }

        public async Task<Producer> UpdateProducer(int id, Producer producer)
        {
            if (id == null)
                return null;
            await _producerRepository.UpdateAsync(id, producer);
            return producer;
        }
    }
}
