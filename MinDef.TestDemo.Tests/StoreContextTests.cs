using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MinDef.TestDemo;
using MinDef.TestDemo.Objects;
using System.Data.Entity;

namespace MinDef.TestDemo.Tests
{
    [TestClass]
    public class StoreContextTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<StoreContext>());
            using (var context = new StoreContext())
            {
                context.Tanks.Add(new Tank { Kenteken = "AA-123" });
                context.SaveChanges();
            }
        }
    }
}
