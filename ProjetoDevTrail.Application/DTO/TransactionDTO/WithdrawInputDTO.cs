using System.ComponentModel.DataAnnotations;

namespace ProjetoDevTrail.Application.DTO.TransactionDTO
{
    public class WithdrawInputDTO
    {
        [Required(ErrorMessage = "O número da conta é obrigatório.")]
        public string accountNumber { get; }

        [Required(ErrorMessage = "O valor do depósito é obrigatório.")]
        [EnumDataType(typeof(decimal), ErrorMessage = "O valor do depósito deve ser numérico.")]
        public decimal Value { get; }

        public WithdrawInputDTO(string accountNumber, decimal value)
        {
            this.accountNumber = accountNumber;
            Value = value;
        }
    }
}
