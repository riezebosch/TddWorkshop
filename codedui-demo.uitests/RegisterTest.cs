﻿using codedui_demo.uitests.Account;
//using Microsoft.Services.TestTools.UITesting.Html;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shouldly;
using codedui_demo.uitests.Home;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using CUITe.ObjectRepository;

namespace codedui_demo.uitests
{
    [CodedUITest]
    public class RegisterTest
    {
        public TestContext TestContext { get; set; }

        [TestMethod]
        [AspNetDevelopmentServer("web", "codedui-demo")]
        public void Register()
        {
            
            var home = Page.Launch<HomePage>(FromAspNetDevelopmentServer());
            var register = home
                .ClickRegister();

            var email = CreateUniqueEmail();
            register.EnterEmail(email)
                .EnterPassword("P@ssw0rd")
                .EnterConfirmPassword("P@ssw0rd")
                .ClickRegister()
                .IsLoggedIn(email)
                .ShouldBeTrue();
        }


        [TestMethod]
        [AspNetDevelopmentServer("web", "codedui-demo")]
        public void RegisterAndLogOff()
        {
            var home = Page.Launch<HomePage>(FromAspNetDevelopmentServer());
            var register = home
                .ClickRegister();

            var email = CreateUniqueEmail();
            register.EnterEmail(email)
                .EnterPassword("P@ssw0rd")
                .EnterConfirmPassword("P@ssw0rd")
                .ClickRegister()
                .Logoff()
                .IsLoggedIn()
                .ShouldBeFalse();
        }

        [TestMethod]
        [AspNetDevelopmentServer("web", "codedui-demo")]
        public void TestWeakPassword()
        {
            var home = Page.Launch<HomePage>(FromAspNetDevelopmentServer());
            var register = home
                .ClickRegister();

            var email = CreateUniqueEmail();
            register.EnterEmail(email)
                .EnterPassword("password")
                .EnterConfirmPassword("password")
                .ClickRegister();

            register
                .Errors
                .Any(m => m.Contains("Passwords must have"))
                .ShouldBeTrue();

        }

        private Uri FromAspNetDevelopmentServer()
        {
            var stack = new StackTrace();
            var attr = stack.GetFrame(1).GetMethod().GetCustomAttributes(true).OfType<AspNetDevelopmentServerAttribute>().FirstOrDefault();

            if (attr == null)
            {
                throw new InvalidOperationException("This method may only be called directly from the test method and that method should have the AspNetDevelopmentServer attribute.");
            }

            return (Uri)TestContext.Properties[$"{TestContext.AspNetDevelopmentServerPrefix}{attr.Name}"];
        }

        private static string CreateUniqueEmail()
        {
            return $"{Guid.NewGuid()}@gmail.com";
        }
    }
}
