using ProjetoDevTrail.Application.DTO.TransactionDTO;
using ProjetoDevTrail.Application.Utils.Exceptions;
using ProjetoDevTrail.Domain.Entities;
using ProjetoDevTrail.Infra.Repositories.AccountRepositories;
using ProjetoDevTrail.Infra.Repositories.TransactionRepositories;

namespace ProjetoDevTrail.Application.UseCase.Transactions.Transfer
{
    public class TransferenceHandler : ITransferenceHandler
    {
        private readonly ITransactionRepository _transRepo;
        private readonly IAccountRepository _accRepo;

        public TransferenceHandler(ITransactionRepository transRepo, IAccountRepository accRepo)
        {
            _transRepo = transRepo;
            _accRepo = accRepo;
        }

        public async Task<TransferenceViewDTO> HandleAsync(TransferenceInputDTO dto)
        {
            var originAccount = await _accRepo.GetByAccountNumberAsync(dto.OriginAccountNumber);
            if (originAccount == null)
                throw new NotFoundException("Conta de origem não encontrada");
            var destinationAccount = await _accRepo.GetByAccountNumberAsync(
                dto.DestinationAccountNumber
            );
            if (destinationAccount == null)
                throw new NotFoundException("Conta de destino não encontrada");

            bool SuceedWidraw = originAccount.Withdraw(dto.Amount);
            if (!SuceedWidraw)
                throw new BadRequestException("Saldo insuficiente para realizar a transferência");
            destinationAccount.Deposit(dto.Amount);
            DateTime transactionDate = DateTime.UtcNow;
            originAccount.UpdatedAt = transactionDate;
            destinationAccount.UpdatedAt = transactionDate;
            await _accRepo.UpdateAsync(originAccount);
            await _accRepo.UpdateAsync(destinationAccount);

            Transaction transaction = Transaction.CreateTransfer(
                dto.Amount,
                originAccount.Id,
                destinationAccount.Id,
                transactionDate
            );
            await _transRepo.AddAsync(transaction);

            return new TransferenceViewDTO(
                transaction.Id,
                originAccountNumber: originAccount.Number,
                destinationAccountNumber: destinationAccount.Number,
                amount: transaction.Amount,
                transactionDate: transactionDate
            );
        }
    }
}
