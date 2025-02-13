using Application.Services;
using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer("Server=TNTRA-SNEHAL;Database=AuctifyPoCDb;Trusted_Connection=True; TrustServerCertificate=True");
            });

            //Registered the interface with the repository.
            services.AddScoped<CategoryInterface, CategoryRepository>();
            services.AddScoped<IdeaInterface, IdeaRepository>();

            // Registered the specific services.
            services.AddScoped<CategoryService>();
            services.AddScoped<IdeaService>();

            //return services;
        }
    }
}
