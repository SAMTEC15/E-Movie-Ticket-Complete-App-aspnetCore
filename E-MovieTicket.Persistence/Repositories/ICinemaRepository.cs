using E_MovieTicket.Domain;
using E_MovieTicket.Domain.Models;
using E_MovieTicket.Persistence.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_MovieTicket.Persistence.Repositories
{
    public interface ICinemaRepository : IEntityBaseRepository<Cinema> 
    {
       // Task<List<Cinema>> GetAllCinemas();
    }
}
