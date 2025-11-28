using ProjetoDevTrail.Api.Utills.DependecyInjectionHelpers.Accounts;
using ProjetoDevTrail.Api.Utills.DependecyInjectionHelpers.Clients;
using ProjetoDevTrail.Api.Utills.DependecyInjectionHelpers.Transactions;

namespace ProjetoDevTrail.Api.Utills.DependecyInjectionHelpers
{
    public static class DependencyInjector
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services)
        {
            services = ClientDependencyInjection.AddRepository(services);
            services = ClientDependencyInjection.AddUseCases(services);
            services = AccountDependecyInjection.AddRepository(services);
            services = AccountDependecyInjection.AddUseCases(services);
            services = TransactionDependencyInjection.AddRepository(services);
            services = TransactionDependencyInjection.AddUseCases(services);
            return services;
        }
    }
}
