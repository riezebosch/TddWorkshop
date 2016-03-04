using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using System.Diagnostics;

namespace TddDemo.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [Timeout(6000)]
        public async Task TestMethod1()
        {
            var sw = Stopwatch.StartNew();
            var result = await ServerCall();

            Assert.IsTrue(result.Contains("body"));
        }

        private static async Task<string> ServerCall()
        {
            await Task.Delay(5000);

            return "<html><head></head><body></body></html>";
        }
    }
}
