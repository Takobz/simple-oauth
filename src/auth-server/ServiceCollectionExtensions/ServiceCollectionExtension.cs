using SimpleAuthServer.Services;
using SimpleAuthServer.Services.Orchestrator;
using SimpleAuthServer.Data;
using SimpleAuthServer.Data.Repositories;

namespace SimpleAuthServer.ServiceCollectionExtensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddSimpleAuthServices(this IServiceCollection services)
        {
            services.AddTransient<IClientsService, ClientService>();
            services.AddTransient<IRegistrationOrchestrator, RegistrationOrchestrator>();
            return services;
        }

        public static IServiceCollection AddRepo(this IServiceCollection services)
        {
            services.AddDbContext<AuthServerContext>();
            services.AddTransient<IClientRepo, ClientRepo>();
            services.AddTransient<IAuthServerContext, AuthServerContext>();
            return services;
        }
    }
}