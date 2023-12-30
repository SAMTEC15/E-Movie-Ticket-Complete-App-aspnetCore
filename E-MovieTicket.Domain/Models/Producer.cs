using System.ComponentModel.DataAnnotations;

namespace E_MovieTicket.Domain.Models
{
    public class Producer : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Profile Picture")]
        public string ProfilePictureUrl { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Biography { get; set; }
        public List<Movie> Movies { get; set; }
    }
}
