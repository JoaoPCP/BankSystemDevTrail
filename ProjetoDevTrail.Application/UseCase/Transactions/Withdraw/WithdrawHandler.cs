using ProjetoDevTrail.Application.DTO.TransactionDTO;
using ProjetoDevTrail.Application.Utils.Exceptions;
using ProjetoDevTrail.Domain.Entities;
using ProjetoDevTrail.Infra.Repositories.AccountRepositories;
using ProjetoDevTrail.Infra.Repositories.TransactionRepositories;

namespace ProjetoDevTrail.Application.UseCase.Transactions.Withdraw
{
    public class WithdrawHandler : IWithdrawHandler
    {
        private readonly ITransactionRepository _transRepo;
        private readonly IAccountRepository _accRepo;

        public WithdrawHandler(ITransactionRepository transRepo, IAccountRepository accRepo)
        {
            _accRepo = accRepo;
            _transRepo = transRepo;
        }

        public async Task<WithdrawViewDTO> HandleAsync(WithdrawInputDTO dto)
        {
            if (dto.Value <= 0)
                throw new BadRequestException("Valor do depósito deve ser maior que 0");
            var account = await _accRepo.GetByAccountNumberAsync(dto.accountNumber);
            if (account == null)
                throw new NotFoundException("Conta não encontrada");
            DateTime trasactionTime = DateTime.UtcNow;
            bool suceedWithdraw = account.Withdraw(dto.Value);
            if (!suceedWithdraw)
                throw new BadRequestException("Saldo insuficiente para realizar o saque");

            account.UpdatedAt = trasactionTime;
            Transaction transaction = Transaction.CreateWithdraw(
                originAccount_Id: account.Id,
                amount: dto.Value,
                transactionDate: trasactionTime
            );
            await _accRepo.UpdateAsync(account);
            await _transRepo.AddAsync(transaction);
            return new WithdrawViewDTO(
                transaction.Id,
                transaction.Amount,
                transaction.TransactionDate,
                originAccountNumber: account.Number
            );
        }
    }
}
