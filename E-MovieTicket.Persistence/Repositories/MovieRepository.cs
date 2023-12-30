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
    public class MovieRepository : EntityBaseRepository<Movie>, IMovieRepository
    {
        private readonly EMovieTicketDbContext _eMovieTicketDbContext;

        public MovieRepository(EMovieTicketDbContext eMovieTicketDbContext) : base(eMovieTicketDbContext) 
        {
            _eMovieTicketDbContext = eMovieTicketDbContext;
        }

        public async Task<Movie> GetMovieByIdAsync(int id)
        {
            var movieDetails = await _eMovieTicketDbContext.Movies
                .Include(u => u.Cinema)
                .Include(u => u.Producer)
                .Include(u => u.ActorMovies).ThenInclude(u => u.Actor)
                .FirstOrDefaultAsync(u  => u.Id == id);
            return  movieDetails;
        }


        //  public async Task<List<Movie>> GetAllMovies() => await _eMovieTicketDbContext.Movies.Include(u => u.Cinema).OrderBy(u => u.Title).ToListAsync();



    }
}
