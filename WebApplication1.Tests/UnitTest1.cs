using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using TddDemo;
using WebApplication1.Controllers;
using Xunit;

namespace WebApplication1.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Get()
        {
            // Arrange
            var context = new DemoContext(new DbContextOptionsBuilder<DemoContext>().UseInMemoryDatabase(nameof(UnitTest1)).Options);
            context.BankAccounts.Add(new BankAccount(0, "iban"));
            context.SaveChanges();

            var controller = new BankAccountController(context);

            // Act
            var actual = controller.Get("iban");

            // Assert
            actual
                .Result
                .Should()
                .BeOfType<OkObjectResult>();

            ((OkObjectResult)actual.Result)
                .Value
                .Should()
                .BeEquivalentTo(new BankAccount(1, "iban"));
        }

        [Fact]
        public void NotFound()
        {
            // Arrange
            using (var context = new DemoContext(new DbContextOptionsBuilder<DemoContext>().UseInMemoryDatabase(nameof(UnitTest1)).Options))
            {
                var controller = new BankAccountController(context);

                // Act
                var account = controller.Get("other");

                // Assert
                account
                    .Result
                    .Should()
                    .BeOfType<NotFoundResult>();
            }
        }
    }
}
