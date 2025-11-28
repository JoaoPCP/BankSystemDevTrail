using ProjetoDevTrail.Application.DTO.TransactionDTO;
using ProjetoDevTrail.Application.Utils.Exceptions;
using ProjetoDevTrail.Domain.Entities;
using ProjetoDevTrail.Infra.Repositories.AccountRepositories;
using ProjetoDevTrail.Infra.Repositories.TransactionRepositories;

namespace ProjetoDevTrail.Application.UseCase.Transactions.Deposit
{
    public class DepositHandler : IDepositHandler
    {
        private readonly ITransactionRepository _transRepo;
        private readonly IAccountRepository _accRepo;

        public DepositHandler(ITransactionRepository transRepo, IAccountRepository accRepo)
        {
            _accRepo = accRepo;
            _transRepo = transRepo;
        }

        public async Task<DepositViewDTO> HandleAsync(DepositInputDTO dto)
        {
            if (dto.Value <= 0)
                throw new BadRequestException("Valor do depósito deve ser maior que 0");
            var account = await _accRepo.GetByAccountNumberAsync(dto.accountNumber);
            if (account == null)
                throw new NotFoundException("Conta não encontrada");
            DateTime trasactionTime = DateTime.UtcNow;
            account.Deposit(dto.Value);
            account.UpdatedAt = trasactionTime;
            Transaction transaction = Transaction.CreateDeposit(
                originAccount_Id: account.Id,
                amount: dto.Value,
                transactionDate: trasactionTime
            );
            await _accRepo.UpdateAsync(account);
            await _transRepo.AddAsync(transaction);
            return new DepositViewDTO(
                transaction.Id,
                account.Number,
                transaction.Amount,
                transaction.TransactionDate
            );
        }
    }
}
