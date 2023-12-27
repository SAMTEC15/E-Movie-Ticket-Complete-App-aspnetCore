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
    public class MovieRepository : IMovieRepository
    {
        private readonly EMovieTicketDbContext _eMovieTicketDbContext;

        public MovieRepository(EMovieTicketDbContext eMovieTicketDbContext)
        {
            _eMovieTicketDbContext = eMovieTicketDbContext;
        }
        public async Task<List<Movie>> GetAllMovies() => await _eMovieTicketDbContext.Movies.ToListAsync();

        
        
    }
}
