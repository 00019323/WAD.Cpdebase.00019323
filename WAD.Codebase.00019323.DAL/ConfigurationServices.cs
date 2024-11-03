using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using WAD.Codebase._00019323.Data;
using WAD.Codebase._00019323.Interfaces;
using WAD.Codebase._00019323.Repositories;

namespace WAD.Codebase._00019323.DAL
{
    public static class ConfigurationServices
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<INewspaperRepository, NewspaperRepository>();
            services.AddScoped<IArticleRepository, ArticleRepository>();

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
