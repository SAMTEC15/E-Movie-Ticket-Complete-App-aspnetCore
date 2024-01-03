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
        private readonly EMovieTicketDbContext _eMovieTicketDbContext;

        public AccountService(UserManager<ApplicationUser> userManager, EMovieTicketDbContext eMovieTicketDbContext)
        {
            _userManager = userManager;          
            _eMovieTicketDbContext = eMovieTicketDbContext;
        }

        public Task<string> Login(LoginVM login)
        {
            throw new NotImplementedException();
        }

        public async Task<string> Register(RegisterVM register)
        {
            var user = await _userManager.FindByEmailAsync(register.EmailAddress);
            if (user != null)
            {
                return null;
            }

            var newUser = new ApplicationUser()
            {
                FirsName = register.FirsName,
                LastName = register.LastName,
                Email = register.EmailAddress,
                UserName = register.EmailAddress
            };
            var newUserResponse = await _userManager.CreateAsync(newUser, register.Password);
            return newUserResponse.ToString();
        }
    }
}
