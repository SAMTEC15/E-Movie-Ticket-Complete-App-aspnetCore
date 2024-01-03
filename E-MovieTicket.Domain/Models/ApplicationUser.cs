using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace E_MovieTicket.Domain.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Display(Name = "First Name")]
        public string FirsName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

    }
}
