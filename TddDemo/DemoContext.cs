using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

namespace TddDemo
{
    public class DemoContext : DbContext
    {
        public DemoContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<BankAccount> BankAccounts { get; set; }
    }
}