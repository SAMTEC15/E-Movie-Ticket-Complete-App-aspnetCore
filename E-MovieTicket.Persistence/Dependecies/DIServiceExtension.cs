using E_MovieTicket.Persistence.Context;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_MovieTicket.Persistence.Dependecies
{
    public static class DIServiceExtension
    {
        public static void AddDependencies(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<EMovieTicketDbContext>(options =>
            options.UseSqlServer(config.GetConnectionString("DefaultConnection")));
        }
    }
}
