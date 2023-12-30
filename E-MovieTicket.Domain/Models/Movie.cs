using E_MovieTicket.Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_MovieTicket.Domain.Models
{
    public class Movie : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string ImageUrl { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; } 
        public MovieCategory MovieCategory { get; set; }
        //Relationship
        public List<ActorMovie> ActorMovies { get; set; } 
        //Cinema
        public int CinemaId { get; set; }
        public Cinema Cinema { get; set; }
        //Producer
        public int ProducerId { get; set; }
        public Producer Producer { get; set; }
    }
}
