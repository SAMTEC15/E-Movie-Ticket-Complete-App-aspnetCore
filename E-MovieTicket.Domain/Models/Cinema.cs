using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_MovieTicket.Domain.Models
{
    public class Cinema
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Cinema Logo")]
        public string Logo { get; set; }
        [Display(Name = "Cinema Name")]
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Movie> Movies { get; set; }
    }
}
