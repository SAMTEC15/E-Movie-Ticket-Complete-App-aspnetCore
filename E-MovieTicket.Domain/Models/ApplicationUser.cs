using System.ComponentModel.DataAnnotations;

namespace E_MovieTicket.Domain.Models
{
    public class ApplicationUser //: IdentityUser
    {
        [Display(Name = "First name")]
        public string FirsName { get; set; }
        [Display(Name = "Last name")]
        public string LastName { get; set; }
    }
}
