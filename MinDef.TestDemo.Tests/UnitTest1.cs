﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MinDef.TestDemo;
using MinDef.TestDemo.Objects;
using System.Transactions;
using System.Linq;
using Moq;
using System.Collections.Generic;

namespace MinDef.TestDemo.Tests
{
    [TestClass]
    public class UnitTest1
    {
        private TransactionScope _scope;
        [TestInitialize]
        public void Init()
        {
            _scope = new TransactionScope();
        }

        [TestCleanup]
        public void CleanUp()
        {
            _scope.Dispose();
        }

        [TestMethod]
        public void TestMethod1()
        {
            // Arrange
            object o = new Tank { Kenteken = "AA-123" };
            ObjectStorer storer = new ObjectStorer();

            // Act
            bool result = storer.Store(o);

            // Assert
            Assert.IsTrue(result);
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        [TestCategory("integratie")]
        [ExpectedException(typeof(DuplicateKentekenException))]
        public void TwoTanksWithIdenticalKentekenPlaat_Store_DuplicateKentekenException()
        //public void ElkeTankIsUniek_TankMetKentekenPlaatTweeKeerOpslaanGeeftException()
        {
            // Arrange -> Given
            object tank1 = new Tank { Kenteken = "AA-123" };
            object tank2 = new Tank { Kenteken = "AA-123" };
            var storer = new ObjectStorer();

            // Act -> When
            storer.Store(tank1);
            storer.Store(tank2);

            // Assert?!?!?!?!?!
        }

        [TestMethod]
        public void GivenAnUnkownObjectWhenStoreThenResultIsFalse()
        {
            object input = new object();
            var storer = new ObjectStorer();

            var result = storer.Store(input);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GivenAValidTankWhenStoreThenTankIsSaved()
        {
            StoreContextFake context = new StoreContextFake();
            var tank = new Tank { Kenteken = "AA-123" };
            var storer = new ObjectStorer(context);

            var result = storer.Store(tank);

            CollectionAssert.Contains(context.Tanks.ToList(), tank);
            Assert.IsTrue(context.IsSaveChangesCalled());
        }

        [TestMethod]
        public void GivenAValidTankWhenStoreThenTankIsSaved_UsingMoq()
        {
            var context = new Mock<IStoreContext>();
            context.Setup(c => c.SaveChanges()).Verifiable();
            context.Setup(c => c.Tanks).Returns(new List<Tank>()).Verifiable();
            
            var tank = new Tank { Kenteken = "AA-123" };
            
            var storer = new ObjectStorer(context.Object);

            var result = storer.Store(tank);

            context.Verify();
            
        }
    }
}
