using E_MovieTicket.Domain.Models;
using E_MovieTicket.Persistence.Base;
using E_MovieTicket.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_MovieTicket.Persistence.Repositories
{
    public class CinemaRepository : EntityBaseRepository<Cinema>, ICinemaRepository
    {
        private readonly EMovieTicketDbContext _eMovieTicketDbContext;

        public CinemaRepository(EMovieTicketDbContext eMovieTicketDbContext) : base(eMovieTicketDbContext) { }
       

        //public async Task<List<Cinema>> GetAllCinemas() => await _eMovieTicketDbContext.Cinemas.ToListAsync();

    }
}
