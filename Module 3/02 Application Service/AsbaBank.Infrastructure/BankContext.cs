using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AsbaBank.Domain.Models;

namespace AsbaBank.Infrastructure
{
    public class BankContext: DbContext
    {
       public DbSet<Client> Clients { get; set; }
        
    }
}
