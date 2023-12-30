using E_MovieTicket.Domain.Models;
using E_MovieTicket.Domain.ViewModels;
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
        Task<Movie> RemoveAllMovies();
        Task<Movie> GetMovieByIdAsync(int id);
        Task<NewMovieDropdownsVM> GetNewMovieDropdownsValue();
        Task<Movie> AddNewMovieAsync(NewMovieVM newMovieVM);
        Task<Movie> UpdateMovieAsync(int id, NewMovieVM newMovieVM);

    }

}
