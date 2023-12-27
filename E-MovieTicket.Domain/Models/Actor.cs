using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_MovieTicket.Domain.Models
{
    public class Actor
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Profile Picture")]
        public string ProfilePictureUrl { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Biography { get; set; }
        public List<ActorMovie> ActorMovies { get; set; }
    }
}
