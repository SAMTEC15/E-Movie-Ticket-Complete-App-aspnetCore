using E_MovieTicket.Domain.Models;
using E_MovieTicket.Domain.ViewModels;
using E_MovieTicket.Persistence.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_MovieTicket.Persistence.Repositories
{
    public interface IMovieRepository : IEntityBaseRepository<Movie>
    {
       // Task<List<Movie>> GetAllMovies();
       Task<Movie> GetMovieByIdAsync(int id);
        Task<NewMovieDropdownsVM> NewMovieDropdownsValue();
        Task<Movie> AddNewMovie(NewMovieVM newMovieVM);
        Task<Movie> UpdateMovieAsync(NewMovieVM newMovieVM);
    }
}
