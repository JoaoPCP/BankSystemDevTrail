using ProjetoDevTrail.Api.Utills.DependecyInjectionHelpers.Clients;

namespace ProjetoDevTrail.Api.Utills.DependecyInjectionHelpers
{
    public static class DependencyInjector
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services)
        {
            services = ClientDependencyInjection.AddRepository(services);
            services = ClientDependencyInjection.AddUseCases(services);
            return services;
        }
    }
}
