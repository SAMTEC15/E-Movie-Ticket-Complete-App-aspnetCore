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

        public Task<Movie> UpdateMovie(int id, Movie movie)
        {
            throw new NotImplementedException();
        }
        public async Task<Movie> GetMovieByIdAsync(int id)
        {
          return  await _movieRepository.GetMovieByIdAsync(id);
        }
    }
}
