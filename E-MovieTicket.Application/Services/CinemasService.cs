using E_MovieTicket.Application.Interfaces;
using E_MovieTicket.Domain.Models;
using E_MovieTicket.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace E_MovieTicket.Application.Services
{
    public class CinemasService : ICinemasService
    {
        private readonly ICinemaRepository _cinemaRepository;

        public CinemasService(ICinemaRepository cinemaRepository)
        {
            _cinemaRepository = cinemaRepository;
        }
        public async Task<Cinema> AddCinema(Cinema cinema)
        {
            var addCinema = await _cinemaRepository.AddAsync(cinema);
            if (cinema == null)
            {
                return null;
            }
            return addCinema;
        }

        public Task<IEnumerable<Cinema>> GetAllCinemas() => _cinemaRepository.GetAllAsync();
       

        public async Task<Cinema> GetCinemaById(int id)
        {
            if (id == null)
                return null;
            var details = await _cinemaRepository.GetByIdAsync(id);
            if (details == null)
                return null;
            return details;
        }

        public Task<Cinema> RemoveAllCinemas()
        {
            throw new NotImplementedException();
        }

        public async Task<Cinema> RemoveCinema(int id)
        {
            if (id == null)
                return null;
            var cinemas = await _cinemaRepository.DeleteAsync(id);
            return cinemas;
        }

        public async Task<Cinema> UpdateCinema(int id, Cinema cinema)
        {
            if (id == null)
                return null;
            await _cinemaRepository.UpdateAsync(id, cinema);
            return cinema;
        }
    }
}
