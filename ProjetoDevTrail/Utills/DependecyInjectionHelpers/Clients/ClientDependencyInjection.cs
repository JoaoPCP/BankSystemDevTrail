using ProjetoDevTrail.Application.UseCase.Clients.CreateClient;
using ProjetoDevTrail.Application.UseCase.Clients.DeleteClient;
using ProjetoDevTrail.Application.UseCase.Clients.GetAllClients;
using ProjetoDevTrail.Application.UseCase.Clients.GetClientById;
using ProjetoDevTrail.Application.UseCase.Clients.UpdateClient;
using ProjetoDevTrail.Infra.Repositories.ClientRepositories;

namespace ProjetoDevTrail.Api.Utills.DependecyInjectionHelpers.Clients
{
    public static class ClientDependencyInjection
    {
        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddScoped<IClientRepository, ClientRepository>();
            return services;
        }

        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            // Clients Use Cases
            services.AddScoped<ICreateClientHandler, CreateClientHandler>();
            services.AddScoped<IGetAllClientsHandler, GetAllClientsHandler>();
            services.AddScoped<IGetClientByIdHandler, GetClientByIdHandler>();
            services.AddScoped<IUpdateClientHandler, UpdateClientHandler>();
            services.AddScoped<IDeleteClientHandler, DeleteClientHandler>();

            return services;
        }
    }
}
