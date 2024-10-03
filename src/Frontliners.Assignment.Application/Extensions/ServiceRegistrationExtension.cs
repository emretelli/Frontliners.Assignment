using Frontliners.Assignment.Application.Services;
using Frontliners.Assignment.Domain.Interfaces;
using Frontliners.Assignment.Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Frontliners.Assignment.Application.Extensions
{
    public static class ServiceRegistrationExtension
    {
        public static IServiceCollection RegisterApplicationServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IAppDbContext, AppDbContext>();
            serviceCollection.AddSingleton<IKafkaProxy, KafkaProxy>();
            serviceCollection.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

            return serviceCollection;
        }
    }
}
