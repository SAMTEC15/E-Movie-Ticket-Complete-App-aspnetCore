using E_MovieTicket.Application.Interfaces;
using E_MovieTicket.Domain.Models;
using E_MovieTicket.Domain.ViewModels;
using E_MovieTicket.Persistence.Context;
using Microsoft.AspNetCore.Identity;

namespace E_MovieTicket.Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly EMovieTicketDbContext _eMovieTicketDbContext;

        public AccountService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, EMovieTicketDbContext eMovieTicketDbContext)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _eMovieTicketDbContext = eMovieTicketDbContext;
        }

        public Task<ApplicationUser> Login(LoginVM login)
        {
            throw new NotImplementedException();
        }

        public Task<ApplicationUser> Register(RegisterVM register)
        {
            throw new NotImplementedException();
        }
    }
}
