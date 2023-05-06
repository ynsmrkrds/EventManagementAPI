using EventManagement.Domain.Repositories;
using EventManagement.Infrastructure.Context;
using EventManagement.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Scrutor;
using System.Reflection;

namespace EventManagement.Infrastructure.Extensions.Registrations
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("EventManagementDB")!;

            services.AddDbContext<EventManagementDBContext>(opt =>
            {
                opt.UseSqlServer(connectionString, asm =>
                {
                    asm.MigrationsAssembly(Assembly.GetAssembly(typeof(EventManagementDBContext))?.GetName().Name);
                });
            });

            services.Scan(scan =>
            {
                scan.FromAssembliesOf(typeof(Repository<>))
                    .AddClasses(classes => classes.AssignableTo(typeof(IRepository<>)))
                    .UsingRegistrationStrategy(RegistrationStrategy.Skip)
                    .AsImplementedInterfaces()
                    .WithScopedLifetime();
            });

            return services;
        }
    }
}
