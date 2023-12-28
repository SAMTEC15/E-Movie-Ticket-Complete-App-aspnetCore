using E_MovieTicket.Persistence.Context;
using E_MovieTicket.Persistence.Repositories;
using E_MovieTicket.Persistence.Seeder;
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
builder.Services.AddScoped<IProducerRepository, ProducerRepository>();
builder.Services.AddScoped<IMovieRepository, MovieRepository>();
builder.Services.AddScoped<ICinemaRepository, CinemaRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
DbInitalizer.Seed(app); 

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Movies}/{action=Index}/{id?}");

app.Run();
