using E_MovieTicket.Domain.Models;
using E_MovieTicket.Domain.ViewModels;
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

        public async Task<Movie> AddNewMovie(NewMovieVM newMovieVM)
        {
            var newMovie = new Movie()
            {
                Title = newMovieVM.Title,
                Description = newMovieVM.Description,
                Price = newMovieVM.Price,
                ImageUrl = newMovieVM.ImageUrl,
                CinemaId = newMovieVM.CinemaId,
                StartDate = newMovieVM.StartDate,
                EndDate = newMovieVM.EndDate,
                MovieCategory = newMovieVM.MovieCategory,
                ProducerId = newMovieVM.ProducerId,
            };
           await _eMovieTicketDbContext.Movies.AddAsync(newMovie);
           await _eMovieTicketDbContext.SaveChangesAsync();

            foreach(var actorId in newMovieVM.ActorIds)
            {
                var newActorMovie = new ActorMovie()
                {
                    MovieId = newMovie.Id,
                    ActorId = actorId,
                };
                await _eMovieTicketDbContext.ActorMovies.AddAsync(newActorMovie);
                await _eMovieTicketDbContext.SaveChangesAsync();
            }
            return newMovie;
        }

        public async Task<Movie> GetMovieByIdAsync(int id)
        {
            var movieDetails = await _eMovieTicketDbContext.Movies
                .Include(u => u.Cinema)
                .Include(u => u.Producer)
                .Include(u => u.ActorMovies).ThenInclude(u => u.Actor)
                .FirstOrDefaultAsync(u => u.Id == id);
            return movieDetails;
        }

        public async Task<NewMovieDropdownsVM> NewMovieDropdownsValue()
        {
            var response = new NewMovieDropdownsVM()
            {
                Actors = await _eMovieTicketDbContext.Actors.OrderBy(u => u.FirstName).ToListAsync(),
                Cinemas = await _eMovieTicketDbContext.Cinemas.OrderBy(u => u.Name).ToListAsync(),
                Producers = await _eMovieTicketDbContext.Producers.OrderBy(u => u.FirstName).ToListAsync(),

            };
            return response;
        }

        public async Task<Movie> UpdateMovieAsync(NewMovieVM newMovieVM)
        {
            var dbMovie = _eMovieTicketDbContext.Movies.FirstOrDefault(u => u.Id == newMovieVM.Id);
            if (dbMovie == null)
                return null;

            dbMovie.Title = newMovieVM.Title;
            dbMovie.Description = newMovieVM.Description;
            dbMovie.Price = newMovieVM.Price;
            dbMovie.ImageUrl = newMovieVM.ImageUrl;
            dbMovie.CinemaId = newMovieVM.CinemaId;
            dbMovie.StartDate = newMovieVM.StartDate;
            dbMovie.EndDate = newMovieVM.EndDate;
            dbMovie.MovieCategory = newMovieVM.MovieCategory;
            dbMovie.ProducerId = newMovieVM.ProducerId;            
            
            await _eMovieTicketDbContext.SaveChangesAsync();

            //Remove exsiting actor
            var existingActor = await _eMovieTicketDbContext.ActorMovies.Where(u => u.MovieId == newMovieVM.Id).ToListAsync();
             _eMovieTicketDbContext.RemoveRange(existingActor);
            await _eMovieTicketDbContext.SaveChangesAsync();

            foreach (var actorId in newMovieVM.ActorIds)
            {
                var newActorMovie = new ActorMovie()
                {
                    MovieId = newMovieVM.Id,
                    ActorId = actorId,
                };
                await _eMovieTicketDbContext.ActorMovies.AddAsync(newActorMovie);
                await _eMovieTicketDbContext.SaveChangesAsync();
            }
            return dbMovie;
        }


        //  public async Task<List<Movie>> GetAllMovies() => await _eMovieTicketDbContext.Movies.Include(u => u.Cinema).OrderBy(u => u.Title).ToListAsync();



    }
}
