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
       

        public Task<Cinema> GetCinemaById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Cinema> RemoveAllCinemas()
        {
            throw new NotImplementedException();
        }

        public Task<Cinema> RemoveCinema(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Cinema> UpdateCinema(int id, Cinema cinema)
        {
            throw new NotImplementedException();
        }
    }
}
