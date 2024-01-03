using E_MovieTicket.Application.Interfaces;
using E_MovieTicket.Application.Services;
using E_MovieTicket.Domain.Models;
using E_MovieTicket.Persistence.Base;
using E_MovieTicket.Persistence.Cart;
using E_MovieTicket.Persistence.Context;
using E_MovieTicket.Persistence.Repositories;
using E_MovieTicket.Persistence.Seeder;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

//var configuration = builder.Configuration;
//builder.Services.AddDependencies(configuration);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<EMovieTicketDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IActorRespository, ActorRepository>();
builder.Services.AddScoped<IActorsService, ActorsService>();
builder.Services.AddScoped<IProducerRepository, ProducerRepository>();
builder.Services.AddScoped<IProducersService, ProducersService>();
builder.Services.AddScoped<IMovieRepository, MovieRepository>();
builder.Services.AddScoped<IMoviesService,  MoviesService>();
builder.Services.AddScoped<ICinemaRepository, CinemaRepository>();
builder.Services.AddScoped<ICinemasService, CinemasService>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrdersService, OrdersService>();
builder.Services.AddScoped<IAccountService, AccountService>();
//builder.Services.AddScoped<IEntityBaseRepository, EntityBaseRepository>();

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped(u => ShoppingCart.GetShoppingCart(u));

//Authentication and Authorization
builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<EMovieTicketDbContext>();
builder.Services.AddMemoryCache();
builder.Services.AddSession();
builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
DbInitalizer.Seed(app); 
DbInitalizer.SeedUsersAndRolesAsync(app);

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseSession();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Movies}/{action=Index}/{id?}");

app.Run();
