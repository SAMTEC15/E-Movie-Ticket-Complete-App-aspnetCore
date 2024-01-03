using E_MovieTicket.Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_MovieTicket.Persistence.Context
{
    public class EMovieTicketDbContext : IdentityDbContext<ApplicationUser>
    {
        public EMovieTicketDbContext(DbContextOptions<EMovieTicketDbContext> options) : base(options) { }


        public DbSet<Actor> Actors { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<ActorMovie> ActorMovies { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ActorMovie>().HasKey(
               u => new
               {
                   u.ActorId,
                   u.MovieId
               });
            modelBuilder.Entity<ActorMovie>().HasOne(u => u.Movie).WithMany(u => u.ActorMovies).HasForeignKey(u => u.MovieId);
            modelBuilder.Entity<ActorMovie>().HasOne(u => u.Actor).WithMany(u => u.ActorMovies).HasForeignKey(u => u.ActorId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
