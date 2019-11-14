using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TddDemo.Tests
{
    public class EntityFrameworkDemo
    {
        [Fact]
        public async Task TestAsync()
        {
            // Arrange
            using (var context = new DemoContext(new DbContextOptionsBuilder<DemoContext>().UseSqlServer(@"Data Source=.\SQLEXPRESS;Initial Catalog=bank;Trusted_Connection=true").Options))
            {
                context.Database.EnsureCreated();
                context.BankAccounts.Add(new BankAccount(0, "123456782"));
                context.SaveChanges();
            }

            using (var context = new DemoContext(new DbContextOptionsBuilder<DemoContext>().UseSqlServer(@"Data Source=.\SQLEXPRESS;Initial Catalog=bank;Trusted_Connection=true").Options))
            {
                (await context.BankAccounts.AnyAsync()).Should().BeTrue();
            }
        }
    }
}
