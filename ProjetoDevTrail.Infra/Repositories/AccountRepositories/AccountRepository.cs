using Microsoft.EntityFrameworkCore;
using ProjetoDevTrail.Domain.Entities;
using ProjetoDevTrail.Infra.Context;
using ProjetoDevTrail.Infra.Repositories.Interface;

namespace ProjetoDevTrail.Infra.Repositories.AccountRepositories
{
    public class AccountRepository(BankContext db) : BaseRepository<Account>(db), IAccountRepository
    {
        public override async Task<List<Account>> GetAllAsync()
        {
            return await db.Accounts.Include(acc => acc.Owner).AsNoTracking().ToListAsync();
        }

        public override async Task<Account?> GetByIdAsync(Guid id)
        {
            return await db
                .Accounts.Include(acc => acc.Owner)
                .FirstOrDefaultAsync(acc => acc.Id == id);
        }

        public async Task<Account?> GetByAccountNumberAsync(string accountNumber)
        {
            return await db
                .Accounts.Include(acc => acc.Owner)
                .FirstOrDefaultAsync(acc => acc.Number == accountNumber);
        }

        public async Task<List<Account>> GetByClientIdAsync(Guid clientId)
        {
            return await db
                .Accounts.Include(acc => acc.Owner)
                .Where(acc => acc.Owner!.Id == clientId)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
