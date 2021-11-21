using Glossaries.Application.Contracts.Persistence;
using Glossaries.Infrastructure.Persistence;
using Glossaries.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Glossaries.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("SqlConnectionString")));

            services.AddScoped<IGlossaryRepository, GlossaryRepository>();

            return services;
        }
    }
}
