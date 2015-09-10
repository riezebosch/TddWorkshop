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
        [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
        class SchoolServiceSingleInstance : SchoolService
        {
            public SchoolServiceSingleInstance(SchoolContext db) :
                base(db)
            {
            }
        }

        [TestMethod]
        public void TestMethod1()
        {
            using(new TransactionScope())
            using (var db = new SchoolContext())
            {
                var service = new SchoolServiceSingleInstance(db);
                var host = new ServiceHost(service);

                try
                {
                    // Arrange
                    host.Description.Behaviors
                        .Find<ServiceDebugBehavior>().IncludeExceptionDetailInFaults = true;

                    host.AddServiceEndpoint(typeof(ISchoolService),
                        new NetNamedPipeBinding(), "net.pipe://localhost/schoolservice");

                    host.Open();

                    var client = ChannelFactory<ISchoolService>
                        .CreateChannel(new NetNamedPipeBinding(),
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

                    Assert.IsTrue(db.People.Any(p => p.FirstName == "Manuel"));
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
        }
    }
}
