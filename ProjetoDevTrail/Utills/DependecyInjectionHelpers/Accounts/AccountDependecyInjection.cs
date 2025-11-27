using ProjetoDevTrail.Application.UseCase.Accounts.CreateAccount;
using ProjetoDevTrail.Application.UseCase.Accounts.GetAccountById;
using ProjetoDevTrail.Application.UseCase.Accounts.GetAllAccounts;
using ProjetoDevTrail.Infra.Repositories.AccountRepositories;

namespace ProjetoDevTrail.Api.Utills.DependecyInjectionHelpers.Accounts
{
    public static class AccountDependecyInjection
    {
        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddScoped<IAccountRepository, AccountRepository>();
            return services;
        }

        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            // Clients Use Cases
            services.AddScoped<ICreateAccountHandler, CreateAccountHandler>();
            services.AddScoped<IGetAllAccountsHandler, GetAllAccountsHandler>();
            services.AddScoped<IGetAccountByIdHandler, GetAccountByIdHandler>();
            return services;
        }
    }
}
