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
    public class ProducerRepository : EntityBaseRepository<Producer> , IProducerRepository
    {
        private readonly EMovieTicketDbContext _eMovieTicketDbContext;

        public ProducerRepository(EMovieTicketDbContext eMovieTicketDbContext) : base(eMovieTicketDbContext) { }
       

       // public async Task<List<Producer>> GetAllProducers() => await _eMovieTicketDbContext.Producers.ToListAsync();

    }
}
