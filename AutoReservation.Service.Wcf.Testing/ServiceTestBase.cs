﻿using AutoReservation.Common.DataTransferObjects;
using AutoReservation.Common.Interfaces;
using AutoReservation.TestEnvironment;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace AutoReservation.Service.Wcf.Testing
{
    [TestClass]
    public abstract class ServiceTestBase
    {
        protected abstract IAutoReservationService Target { get; }

        [TestInitialize]
        public void InitializeTestData()
        {
            TestEnvironmentHelper.InitializeTestData();
        }

        [TestMethod]
        public void Test_GetAutos()
        {
            Assert.AreEqual(3, Target.GetAutos().Count);
        }

        [TestMethod]
        public void Test_GetKunden()
        {
            Assert.AreEqual(4, Target.GetKunden().Count);
        }

        [TestMethod]
        public void Test_GetReservationen()
        {
            Assert.AreEqual(3, Target.GetReservationen().Count);
        }

        [TestMethod]
        public void Test_GetAutoById()
        {
            var auto = Target.GetAuto(1);
            Assert.AreEqual(1, auto.Id);
            Assert.AreEqual("Fiat Punto", auto.Marke);
            Assert.AreEqual(2, auto.AutoKlasse);
        }

        [TestMethod]
        public void Test_GetKundeById()
        {
            var kunde = Target.GetKunde(1);
            Assert.AreEqual(1, kunde.Id);
        }

        [TestMethod]
        public void Test_GetReservationByNr()
        {
            Assert.Inconclusive("Test not implemented.");
        }

        [TestMethod]
        public void Test_GetReservationByIllegalNr()
        {
            Assert.Inconclusive("Test not implemented.");
        }

        [TestMethod]
        public void Test_InsertAuto()
        {
            Assert.Inconclusive("Test not implemented.");
        }

        [TestMethod]
        public void Test_InsertKunde()
        {
            Assert.Inconclusive("Test not implemented.");
        }

        [TestMethod]
        public void Test_InsertReservation()
        {
            Assert.Inconclusive("Test not implemented.");
        }

        [TestMethod]
        public void Test_UpdateAuto()
        {
            Assert.Inconclusive("Test not implemented.");
        }

        [TestMethod]
        public void Test_UpdateKunde()
        {
            Assert.Inconclusive("Test not implemented.");
        }

        [TestMethod]
        public void Test_UpdateReservation()
        {
            Assert.Inconclusive("Test not implemented.");
        }

        [TestMethod]
        [ExpectedException(typeof(FaultException<AutoDto>))]
        public void Test_UpdateAutoWithOptimisticConcurrency()
        {
            Assert.Inconclusive("Test not implemented.");
        }

        [TestMethod]
        [ExpectedException(typeof(FaultException<KundeDto>))]
        public void Test_UpdateKundeWithOptimisticConcurrency()
        {
            Assert.Inconclusive("Test not implemented.");
        }

        [TestMethod]
        [ExpectedException(typeof(FaultException<ReservationDto>))]
        public void Test_UpdateReservationWithOptimisticConcurrency()
        {
            Assert.Inconclusive("Test not implemented.");
        }

        [TestMethod]
        public void Test_DeleteKunde()
        {
            Assert.Inconclusive("Test not implemented.");
        }

        [TestMethod]
        public void Test_DeleteAuto()
        {
            Assert.Inconclusive("Test not implemented.");
        }

        [TestMethod]
        public void Test_DeleteReservation()
        {
            Assert.Inconclusive("Test not implemented.");
        }
    }
}
