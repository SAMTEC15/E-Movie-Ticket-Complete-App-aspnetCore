using E_MovieTicket.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_MovieTicket.Persistence.Repositories
{
    public interface IActorRespository
    {
        Task<List<Actor>> GetAllActor();
        Task<Actor> GetActorById(int? id);       
        Task<Actor> AddActor(Actor actor);
        Task<Actor> RemoveActor(int id);
        Task<Actor> UpdateActor(int id, Actor actor);
        Task<Actor> RemoveAllActors();
    }
}
