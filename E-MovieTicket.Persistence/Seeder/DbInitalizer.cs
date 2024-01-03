using E_MovieTicket.Common.Enums;
using E_MovieTicket.Domain.Models;
using E_MovieTicket.Persistence.Context;
using E_MovieTicket.Persistence.Roles;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace E_MovieTicket.Persistence.Seeder
{
    public class DbInitalizer
    {
        public static async void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<EMovieTicketDbContext>();

                context.Database.EnsureCreated();

                if (!context.Cinemas.Any())
                {
                    // Create a list of cinemas to be added
                    var cinemas = new List<Cinema>()
                    {
                              new Cinema()
                              {

                                    Name = "Cinema 1",
                                    Logo = "http://dotnethow.net/images/cinemas/cinema-1.jpeg",
                                    Description = "This is the description of the first cinema"
                              },

                            new Cinema()
                            {
                                Name = "Cinema 2",
                                Logo = "http://dotnethow.net/images/cinemas/cinema-2.jpeg",
                                Description = "This is the description of the first cinema"
                            },
                            new Cinema()
                            {
                                Name = "Cinema 3",
                                Logo = "http://dotnethrow.net/images/cinemas/cinema-3.jpeg",
                                Description = "This is the description of the first cinema"
                            },
                            new Cinema()
                            {
                                Name = "Cinema 4",
                                Logo = "http://dotnethrow.net/images/cinemas/cinema-4.jpeg",
                                Description = "This is the description of the first cinema"
                            },
                            new Cinema()
                            {
                                Name = "Cinema 5",
                                Logo = "http://dotnethrow.net/images/cinemas/cinema-5.jpeg",
                                Description = "This is the description of the first cinema"
                            },
                    };

                    // Add the list of cinemas to the context
                    await context.Cinemas.AddRangeAsync(cinemas);
                    await context.SaveChangesAsync(); // Save changes to the database
                }

                if (!context.Actors.Any())
                {
                    var actors = new List<Actor>()
                    {
                        new Actor()
                        {
                            FirstName = "Peter",
                            LastName = "Mike",
                            ProfilePictureUrl = "http://dotnethrow.net/images/Actor/actor-1.jpeg",
                            Biography = "This is the description of Actor 1"
                        },
                        new Actor()
                        {
                            FirstName = "John",
                            LastName = "Mike",
                            ProfilePictureUrl = "http://dotnethrow.net/images/Actor/actor-2.jpeg",
                            Biography = "This is the description of Actor 2"
                        },
                         new Actor()
                        {
                                FirstName = "James ",
                                LastName = "Mike",
                                ProfilePictureUrl = "http://dotnethrow.net/images/Actor/actor-3.jpeg",
                                Biography = "This is the description of Actor 3"
                        },
                        new Actor()
                        {
                                FirstName = "Benjamin ",
                                LastName = "Mike",
                                ProfilePictureUrl = "http://dotnethrow.net/images/Actor/actor-4.jpeg",
                                Biography = "This is the description of Actor 4"
                        },
                        new Actor()
                        {
                                FirstName = "Paul ",
                                LastName = "Grace",
                                ProfilePictureUrl = "http://dotnethrow.net/images/Actor/actor-5.jpeg",
                                Biography = "This is the description of Actor 5"
                        },
                    };

                    await context.Actors.AddRangeAsync(actors);
                    await context.SaveChangesAsync(); // Save changes to the database using async
                }

                if (!context.Producers.Any())
                {
                    var Addproducers = new List<Producer>()
                    {
                        new Producer()
                        {
                                FirstName = "Peter ",
                                LastName = "Mike",
                                ProfilePictureUrl = "http://dotnethrow.net/images/produce/producer-1.jpeg",
                                Biography = "This is the description of Producer 1",
                        },
                        new Producer()
                        {
                                FirstName = "John ",
                                LastName = "Mike",
                                ProfilePictureUrl = "http://dotnethrow.net/images/Producer/Producer-2.jpeg",
                                Biography = "This is the description of Producer 2"
                        },
                        new Producer()
                        {
                                FirstName = "James ",
                                LastName = "Mike",
                                ProfilePictureUrl = "http://dotnethrow.net/images/Producer/Producer-3.jpeg",
                                Biography = "This is the description of Producer 3"
                        },
                        new Producer()
                        {
                                FirstName = "Benjamin ",
                                LastName = "Mike",
                                ProfilePictureUrl = "http://dotnethrow.net/images/Producer/Producer-4.jpeg",
                                Biography = "This is the description of Producer 4"
                        },
                        new Producer()
                        {
                                FirstName = "Paul ",
                                LastName = "Grace",
                                ProfilePictureUrl = "http://dotnethrow.net/images/Producer/Producer-5.jpeg",
                                Biography = "This is the description of Producer 5"
                        },
                    };
                    await context.Producers.AddRangeAsync(Addproducers);
                    await context.SaveChangesAsync();

                };

                if (!context.Movies.Any())
                {
                    var movies = new List<Movie>()
                    {
                        new Movie()
                        {
                            Title = "things fall apart",
                            Price = 600,
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(-2),
                            CinemaId = 2,
                            ProducerId = 3,
                            ImageUrl = "http://dotnethrow.net/images/Movie/Movie-1.jpeg",
                            Description = "This is the description of Movie 1",
                            MovieCategory = MovieCategory.Comedy,
                        },
                        new Movie()
                        {
                            Title = "Place fall apart",
                            Price = 800,
                            StartDate = DateTime.Now.AddDays(-8),
                            EndDate = DateTime.Now.AddDays(-4),
                            CinemaId = 3,
                            ProducerId = 3,
                            ImageUrl = "http://dotnethrow.net/images/Movie/Movie-1.jpeg",
                            Description = "This is the description of Movie 1",
                            MovieCategory = MovieCategory.Action,
                        },
                        new Movie()
                        {
                            Title = "House fall apart",
                            Price = 600,
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(-2),
                            CinemaId = 3,
                            ProducerId = 3,
                            ImageUrl = "http://dotnethrow.net/images/Movie/Movie-1.jpeg",
                            Description = "This is the description of Movie 1",
                            MovieCategory = MovieCategory.Comedy,
                        },
                       new Movie()
                        {
                            Title = "General rise",
                            Price = 600,
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(-2),
                            CinemaId = 2,
                            ProducerId = 3,
                            ImageUrl = "http://dotnethrow.net/images/Movie/Movie-1.jpeg",
                            Description = "This is the description of Movie 1",
                            MovieCategory = MovieCategory.Horror,
                        },
                        new Movie()
                        {
                            Title = "things fall apart",
                            Price = 600,
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(-2),
                            CinemaId = 2,
                            ProducerId = 3,
                            ImageUrl = "http://dotnethrow.net/images/Movie/Movie-1.jpeg",
                            Description = "This is the description of Movie 1",
                            MovieCategory = MovieCategory.Comedy,
                        },
                    };

                    await context.Movies.AddRangeAsync(movies);
                    await context.SaveChangesAsync(); // Save changes to the database using async
                }

                if (!context.ActorMovies.Any())
                {
                    var movies = new List<ActorMovie>()
                    {
                            new ActorMovie()
                            {
                                ActorId = 1,
                                MovieId = 3,
                            },
                            new ActorMovie()
                            {
                                ActorId = 2,
                                MovieId = 4,
                            },
                            new ActorMovie()
                            {
                                ActorId = 3,
                                MovieId = 5,
                            },
                            new ActorMovie()
                            {
                                ActorId = 4,
                                MovieId = 6,
                            },
                            new ActorMovie()
                            {
                                ActorId = 5,
                                MovieId = 7,
                            },

                    };

                    await context.ActorMovies.AddRangeAsync(movies);
                    await context.SaveChangesAsync();
                }
            }


        }

        public static async void SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {

                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                string adminUserEmail = "admin@etickets.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new ApplicationUser()
                    {
                        FirsName = "Admin",
                        LastName = "User",
                        UserName = "admin-user",
                        Email = adminUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAdminUser, "Coding@1234#");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }


                string appUserEmail = "user@etickets.com";

                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new ApplicationUser()
                    {
                        FirsName = "Application",
                        LastName = "User",
                        UserName = "app-user",
                        Email = appUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAppUser, "Coding@1234#");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }
            }
        }
    }
}



