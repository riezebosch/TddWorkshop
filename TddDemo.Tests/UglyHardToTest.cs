using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.QualityTools.Testing.Fakes;

namespace TddDemo.Tests
{
    [TestClass]
    public class UglyHardToTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            Console.WriteLine(DateTime.Today);
            using (ShimsContext.Create())
            {
                Console.WriteLine(DateTime.Today);
                System.Fakes.ShimDateTime.TodayGet = () => new DateTime(2015, 02, 17);
                Console.WriteLine(DateTime.Today);

                int age = CalcAge(new DateTime(1990, 10, 11));
                Assert.AreEqual(25, age); 
            }

            Console.WriteLine(DateTime.Today);
        }

        private int CalcAge(DateTime dateTime)
        {
            return DateTime.Today.Year - dateTime.Year;
        }
    }
}
