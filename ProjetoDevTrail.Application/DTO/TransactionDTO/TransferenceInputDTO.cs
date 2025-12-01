using System.ComponentModel.DataAnnotations;
using ProjetoDevTrail.Domain.Entities;
using ProjetoDevTrail.Domain.Enum.Transaction;

namespace ProjetoDevTrail.Application.DTO.TransactionDTO
{
    public class TransferenceInputDTO
    {
        [Required(ErrorMessage = "O valor da transferência é obrigatório.")]
        public decimal Amount { get; }

        [Required(ErrorMessage = "O número da conta de origem é obrigatório.")]
        public string OriginAccountNumber { get; }

        [Required(ErrorMessage = "O número da conta de destino é obrigatório.")]
        public string DestinationAccountNumber { get; }

        public TransferenceInputDTO(
            decimal amount,
            string originAccountNumber,
            string destinationAccountNumber
        )
        {
            Amount = amount;
            OriginAccountNumber = originAccountNumber;
            DestinationAccountNumber = destinationAccountNumber;
        }
    }
}
