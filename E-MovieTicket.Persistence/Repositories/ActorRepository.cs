using E_MovieTicket.Domain.Models;
using E_MovieTicket.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_MovieTicket.Persistence.Repositories
{
    public class ActorRepository : IActorRespository
    {
        private readonly EMovieTicketDbContext _eMovieTicketDbContext;

        public ActorRepository(EMovieTicketDbContext eMovieTicketDbContext)
        {
            _eMovieTicketDbContext = eMovieTicketDbContext;
        }

        public async Task<Actor> AddActor(Actor actor)
        {
          
           if(actor == null)
            {
                return null;
            }
            var addActor =  await _eMovieTicketDbContext.Actors.AddAsync(actor);
            await _eMovieTicketDbContext.SaveChangesAsync();
            return actor;
        }

        public async Task<Actor> GetActorById(int? id)
        {
            var details = await _eMovieTicketDbContext.Actors.FirstOrDefaultAsync(a => a.Id == id);
            if (details == null)
                return null;
            return details;
        }

        public async Task<List<Actor>> GetAllActor() => await _eMovieTicketDbContext.Actors.ToListAsync();

        public async Task<Actor> RemoveActor(int id)
        {
           var existing = await _eMovieTicketDbContext.Actors.FirstOrDefaultAsync(u => u.Id == id);
            if (existing == null)
                return null;
            var delete =  _eMovieTicketDbContext.Remove(existing); 
           await _eMovieTicketDbContext.SaveChangesAsync();
            return existing;
        }

        public Task<Actor> RemoveAllActors()
        {
            throw new NotImplementedException();
        }

        public async Task<Actor> UpdateActor(int id, Actor actor)
        {
            var actorCheck = await _eMovieTicketDbContext.Actors.FirstOrDefaultAsync(u => u.Id ==  id);
            if(actorCheck == null)
            {
                return null;
            }
            actorCheck.ProfilePictureUrl = actor.ProfilePictureUrl;
            actorCheck.FirstName = actor.FirstName;
            actorCheck.LastName = actor.LastName;
            actorCheck.Biography = actor.Biography;
           await _eMovieTicketDbContext.SaveChangesAsync();
            return actorCheck;
        }

       
    }
}
