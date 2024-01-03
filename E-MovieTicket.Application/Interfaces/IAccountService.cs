using E_MovieTicket.Domain.Models;
using E_MovieTicket.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_MovieTicket.Application.Interfaces
{
    public interface IAccountService
    {
        Task<ApplicationUser> Register(RegisterVM register);
        Task<ApplicationUser> Login(LoginVM login);
    }
}
