using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ServiceModel;
using TddDemo.Contracts;
using System.ServiceModel.Description;
using FluentAssertions;
using TddDemo.DataAccess;
using System.Linq;
using System.Transactions;

namespace TddDemo.Tests
{
    [TestClass]
    public class SchoolServiceTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            using (var db = new SchoolContext())
            {
                using (new TransactionScope())
                {
                    var host = new ServiceHost(typeof(SchoolService));

                    try
                    {
                        // Arrange
                        host.Description.Behaviors
                            .Find<ServiceDebugBehavior>().IncludeExceptionDetailInFaults = true;

                        host.AddServiceEndpoint(typeof(ISchoolService),
                            new NetNamedPipeBinding() { TransactionFlow = true }, "net.pipe://localhost/schoolservice");

                        host.Open();

                        var client = ChannelFactory<ISchoolService>
                            .CreateChannel(new NetNamedPipeBinding() { TransactionFlow = true },
                            new EndpointAddress("net.pipe://localhost/schoolservice"));

                        // Act
                        var result = client.AddPerson(new DataContracts.Person
                        {
                            Id = 0,
                            FirstName = "Manuel",
                            LastName = "Riezebosch",
                            HireDate = new DateTime(2007, 03, 01),
                            EnrollmentDate = null
                        });

                        // Assert
                        Assert.IsNotNull(result);
                        Assert.AreNotEqual(0, result.Id);

                        var expected = new DataContracts.Person
                        {
                            FirstName = "Manuel",
                            LastName = "Riezebosch",
                            HireDate = new DateTime(2007, 03, 01),
                            EnrollmentDate = null
                        };

                        expected.ShouldBeEquivalentTo(result, options => options.Excluding(o => o.Id));
                        Assert.AreEqual(1, db.People.Count(p => p.FirstName == "Manuel"));
                    }
                    finally
                    {
                        if (host.State != CommunicationState.Faulted)
                        {
                            try
                            {
                                host.Close();
                            }
                            finally
                            {
                                host.Abort();
                            }
                        }
                        else
                        {
                            host.Abort();
                        }
                    }
                }

                Assert.IsFalse(db.People.Any(p => p.FirstName == "Manuel"));

            }
        }
    }
}
