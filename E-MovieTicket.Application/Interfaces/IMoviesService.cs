using E_MovieTicket.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_MovieTicket.Application.Interfaces
{
    public interface IMoviesService
    {
        Task<Movie> GetMovieById(int id);
        Task<IEnumerable<Movie>> GetAllMovies();
        Task<Movie> AddMovie(Movie movie);
        Task<Movie> RemoveMovie(int id);
        Task<Movie> UpdateMovie(int id, Movie movie);
        Task<Movie> RemoveAllMovies();
        Task<Movie> GetMovieByIdAsync(int id);

    }

}
