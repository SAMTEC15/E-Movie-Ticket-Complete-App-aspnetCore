using E_MovieTicket.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_MovieTicket.Application.Interfaces
{
    public interface ICinemasService
    {
        Task<Cinema> GetCinemaById(int id);
        Task<IEnumerable<Cinema>> GetAllCinemas();
        Task<Cinema> AddCinema(Cinema cinema);
        Task<Cinema> RemoveCinema(int id);
        Task<Cinema> UpdateCinema(int id, Cinema cinema);
        Task<Cinema> RemoveAllCinemas();
    }
}
