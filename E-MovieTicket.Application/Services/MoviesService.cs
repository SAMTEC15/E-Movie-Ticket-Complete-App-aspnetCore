using E_MovieTicket.Application.Interfaces;
using E_MovieTicket.Domain.Models;
using E_MovieTicket.Domain.ViewModels;
using E_MovieTicket.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_MovieTicket.Application.Services
{
    public class MoviesService : IMoviesService
    {
        private readonly IMovieRepository _movieRepository;

        public MoviesService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }
        public async Task<Movie> AddMovie(Movie movie)
        {
            await _movieRepository.AddAsync(movie);
            return movie;
        }

        public Task<IEnumerable<Movie>> GetAllMovies() => _movieRepository.GetAllAsync();


        public Task<Movie> GetMovieById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Movie> RemoveAllMovies()
        {
            throw new NotImplementedException();
        }

        public Task<Movie> RemoveMovie(int id)
        {
            throw new NotImplementedException();
        }
        
        public async Task<Movie> GetMovieByIdAsync(int id)
        {
            return await _movieRepository.GetMovieByIdAsync(id);
        }

        public Task<NewMovieDropdownsVM> GetNewMovieDropdownsValue() => _movieRepository.NewMovieDropdownsValue();

        public async Task<Movie> AddNewMovieAsync(NewMovieVM newMovieVM)
        {
           var addMovie = await _movieRepository.AddNewMovie(newMovieVM);
            return addMovie;
          
        }

        public async Task<Movie> UpdateMovieAsync(int id, NewMovieVM newMovieVM)
        {
            /*    var movieDetails = await _movieRepository.GetMovieByIdAsync(id);
                if (movieDetails == null)
                    return null;
                var response = new NewMovieVM
                {
                    Id = movieDetails.Id,
                    Title = movieDetails.Title,
                    Description = movieDetails.Description,
                    Price = movieDetails.Price,
                    ImageUrl = movieDetails.ImageUrl,
                    MovieCategory = movieDetails.MovieCategory,
                    CinemaId = movieDetails.CinemaId,
                    ProducerId = movieDetails.ProducerId,
                    ActorIds = movieDetails.ActorMovies.Select(u => u.ActorId).ToList(),
                };
                var updateMovieDetails = _movieRepository.UpdateMovie(response);
                return updateMovieDetails;*/

            return await _movieRepository.UpdateMovieAsync(newMovieVM);
        }
    }
}
