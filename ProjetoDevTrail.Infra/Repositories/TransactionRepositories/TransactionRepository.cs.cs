using Microsoft.EntityFrameworkCore;
using ProjetoDevTrail.Domain.Commons;
using ProjetoDevTrail.Domain.Entities;
using ProjetoDevTrail.Infra.Context;
using ProjetoDevTrail.Infra.Repositories.Interface;

namespace ProjetoDevTrail.Infra.Repositories.TransactionRepositories
{
    public class TransactionRepository : BaseRepository<Transaction>, ITransactionRepository
    {
        private readonly BankContext db;

        public TransactionRepository(BankContext context)
            : base(context)
        {
            db = context;
        }

        public override async Task<Transaction?> GetByIdAsync(Guid id)
        {
            var result = await db
                .Transactions.Include(t => t.OriginAccount)
                .Include(t => t.DestinationAccount)
                .FirstOrDefaultAsync(t => t.Id == id);
            return result;
        }

        public async Task<List<Transaction>> GetByAccountIdAsync(Guid accountID)
        {
            var result = await db
                .Transactions.Where(t =>
                    t.OriginAccount_Id == accountID || t.DestinationAccount_Id == accountID
                )
                .Include(t => t.OriginAccount)
                .Include(t => t.DestinationAccount)
                .OrderByDescending(t => t.TransactionDate)
                .AsNoTracking()
                .ToListAsync();
            return result;
        }
    }
}
