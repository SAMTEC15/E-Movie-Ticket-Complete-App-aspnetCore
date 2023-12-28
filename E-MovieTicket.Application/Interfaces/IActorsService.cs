using E_MovieTicket.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_MovieTicket.Application.Interfaces
{
    public interface IActorService
    {
        IEnumerable<Actor> GetAllActor();
    }
}
