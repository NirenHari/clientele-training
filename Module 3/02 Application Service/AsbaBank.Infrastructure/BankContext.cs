using System.Data.Entity;
using AsbaBank.Domain.Models;

namespace AsbaBank.Infrastructure
{
    public class BankContext: DbContext
    {
       //public DbSet<Account> Accounts { get; set; }
       public DbSet<Address> Addresses { get; set; }
       //public DbSet<BankCard> BankCards { get; set; }
       public DbSet<Client> Clients { get; set; }
       //public DbSet<Transaction> Transactions { get; set; }

       public BankContext(string connectionString) : base(connectionString)
       {
           //if (Database.Exists())
           //{
           //    return;
           //}
           Database.Delete();
           Database.Create();
       }

    }
}
