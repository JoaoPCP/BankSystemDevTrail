using ProjetoDevTrail.Application.UseCase.Transactions.Deposit;
using ProjetoDevTrail.Application.UseCase.Transactions.GetTransactionById;
using ProjetoDevTrail.Infra.Repositories.TransactionRepositories;

namespace ProjetoDevTrail.Api.Utills.DependecyInjectionHelpers.Transactions
{
    public static class TransactionDependencyInjection
    {
        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddScoped<ITransactionRepository, TransactionRepository>();
            return services;
        }

        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            services.AddScoped<IDepositHandler, DepositHandler>();
            services.AddScoped<IGetTransactionByIdHandler, GetTransactionByIdHandler>();

            return services;
        }
    }
}
