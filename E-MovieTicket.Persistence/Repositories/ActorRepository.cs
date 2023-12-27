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

        public async Task<List<Actor>> GetAllActor() => await _eMovieTicketDbContext.Actors.ToListAsync();

    }
}
