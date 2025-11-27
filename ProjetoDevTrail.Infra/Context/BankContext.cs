using Microsoft.EntityFrameworkCore;
using ProjetoDevTrail.Domain.Entities;

namespace ProjetoDevTrail.Infra.Context
{
    public class BankContext : DbContext
    {
        public BankContext(DbContextOptions<BankContext> options)
            : base(options) { }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Account entity configuration
            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(acc => acc.Id);
                entity.Property(acc => acc.Numero).IsRequired().HasMaxLength(20);
                entity.Property(acc => acc.Balance).IsRequired().HasColumnType("decimal(18,2)");
                entity.Property(acc => acc.Type).IsRequired();
                entity.Property(acc => acc.Status).IsRequired();
                entity.Property(acc => acc.CreatedAt).IsRequired();
                entity.Property(acc => acc.UpdatedAt);
                entity
                    .HasOne(acc => acc.Owner)
                    .WithMany(c => c.Accounts)
                    .HasForeignKey(acc => acc.OwnerID)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // Client entity configuration
            modelBuilder.Entity<Client>(entity =>
            {
                entity.HasKey(client => client.Id);
                entity.Property(client => client.Name).HasMaxLength(100);
                entity.Property(client => client.Email).HasMaxLength(100);
                entity.Property(client => client.CPF).HasMaxLength(11);
                entity.Property(client => client.BirthDate);
                entity.Property(client => client.CreatedAt);
                entity.Property(client => client.UpdatedAt);
            });

            // Transaction entity configuration
            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.HasKey(tr => tr.Id);
                entity.Property(tr => tr.Type);
                entity.Property(tr => tr.Amount).HasColumnType("decimal(18,2)");
                entity.Property(tr => tr.TransactionDate);
                entity
                    .HasOne(tr => tr.OriginAccount)
                    .WithMany(account => account.IngoingTransactions)
                    .HasForeignKey(tr => tr.OriginAccount_Id)
                    .OnDelete(DeleteBehavior.Restrict);
                entity
                    .HasOne(tr => tr.DestinationAccount)
                    .WithMany(account => account.OutgoingTransactions)
                    .HasForeignKey(tr => tr.DestinationAccount_Id)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
