using E_MovieTicket.Application.Interfaces;
using E_MovieTicket.Domain.Models;
using E_MovieTicket.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_MovieTicket.Application.Services
{
    public class ActorsService : IActorsService
    {
        private readonly IActorRespository _actorRepository;

        public ActorsService(IActorRespository actorRepository)
        {
           _actorRepository = actorRepository;
        }
        public async Task<Actor> AddActor(Actor actor)
        {
            var addActor = await _actorRepository.AddAsync(actor);
            if(addActor == null )
            {
                return null;
            }
            return addActor;
        }

        public async Task<Actor> GetActorById(int id)
        {
            if (id == null)
                return null;
          var details = await _actorRepository.GetByIdAsync(id);
            if (details == null)
                return null;
            return details;
        }

        public async Task<IEnumerable<Actor>> GetAllActors()
        {
            var result = await _actorRepository.GetAllAsync();
            return result;
        }

        public async Task<Actor> RemoveActor(int id)
        {           
            if (id == null)
                return null;
           var actor = await _actorRepository.DeleteAsync(id);
            return actor;

        }

        public Task<Actor> RemoveAllActors()
        {
            throw new NotImplementedException();
        }

        public async Task<Actor> UpdateActor(int id, Actor actor)
        {
            if (id == null)
                return null;
           await _actorRepository.UpdateAsync(id, actor);
            return actor;
        }
    }
}
