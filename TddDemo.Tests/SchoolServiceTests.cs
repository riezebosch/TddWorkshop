using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ServiceModel;
using TddDemo.Contracts;
using System.ServiceModel.Description;
using FluentAssertions;
using TddDemo.DataAccess;
using System.Linq;
using System.Transactions;
using System.ServiceModel.Security;
using System.Security.Cryptography.X509Certificates;

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
                    ServiceHost host = OpenHost();

                    try
                    {
                        // Arrange
                        var binding = new WSHttpBinding(SecurityMode.Message) { TransactionFlow = true };
                        
                        var factory = new ChannelFactory<ISchoolService>(binding);
                        var credentials = factory.Endpoint.EndpointBehaviors.OfType<ClientCredentials>().Single();
                        credentials.ServiceCertificate.Authentication.CertificateValidationMode = X509CertificateValidationMode.None;

                        

                        factory.Credentials.UserName.UserName = "Manuel";
                        factory.Credentials.UserName.Password = "Pa$$w0rd";

                        var client = factory.CreateChannel(new EndpointAddress("http://localhost:6789/schoolservice"));

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
                        CloseHost(host);
                    }
                }

                Assert.IsFalse(db.People.Any(p => p.FirstName == "Manuel"));

            }
        }

        private static void CloseHost(ServiceHost host)
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

        private static ServiceHost OpenHost()
        {
            var host = new ServiceHost(typeof(SchoolService));
            host.Description.Behaviors
                .Find<ServiceDebugBehavior>().IncludeExceptionDetailInFaults = true;

            host.Description.Behaviors.Find<ServiceAuthorizationBehavior>().PrincipalPermissionMode = PrincipalPermissionMode.UseAspNetRoles;

            var credentials = new ServiceCredentials();
            credentials.ServiceCertificate.SetCertificate(StoreLocation.LocalMachine, StoreName.My, X509FindType.FindBySubjectName, "localhost");
            credentials.UserNameAuthentication.UserNamePasswordValidationMode = UserNamePasswordValidationMode.Custom;
            credentials.UserNameAuthentication.CustomUserNamePasswordValidator = new CustomUserNamePasswordValidator();
            host.Description.Behaviors.Add(credentials);

            var binding = new WSHttpBinding(SecurityMode.Message) { TransactionFlow = true };
            binding.Security.Message.ClientCredentialType = MessageCredentialType.UserName;
            binding.Security.Message.NegotiateServiceCredential = false;

            host.AddServiceEndpoint(typeof(ISchoolService),
                 binding, "http://localhost:6789/schoolservice");

            host.Open();

            return host;
        }

        [TestMethod]
        [ExpectedException(typeof(SecurityAccessDeniedException))]
        public void TestAuthentication()
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

                client.AddPerson(new DataContracts.Person { LastName = "Riezebosch" });
            }
            finally
            {
                CloseHost(host);
            }
        }


        TransactionScope _scope;
        [TestInitialize]
        public void TestInitialize()
        {
            _scope = new TransactionScope();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _scope.Dispose();
        }

    }
}
