using AutoReservation.Common.DataTransferObjects;
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
            Assert.AreEqual(AutoKlasse.Standard, auto.AutoKlasse);
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
            var res1 = Target.GetReservation(1);
            Assert.AreEqual(1, res1.Auto.Id);
        }

        [TestMethod]
        public void Test_GetReservationByIllegalNr()
        {
            var res = Target.GetReservation(-1);
            Assert.IsNull(res);
        }

        [TestMethod]
        public void Test_InsertAuto()
        {
            var count = Target.GetAutos().Count;
            var auto = new AutoDto();
            auto.AutoKlasse = AutoKlasse.Luxusklasse;
            auto.Marke = "Duck Car";
            auto.Basistarif = 1337;
            Target.AddAuto(auto);
            Assert.AreEqual(count + 1, Target.GetAutos().Count);
        }

        [TestMethod]
        public void Test_InsertKunde()
        {
            var count = Target.GetKunden().Count;
            var kunde = new KundeDto();
            kunde.Vorname = "Hans";
            kunde.Nachname = "Duck";
            Target.AddKunde(kunde);
            Assert.AreEqual(count+1, Target.GetKunden().Count);
        }

        [TestMethod]
        public void Test_InsertReservation()
        {
            var count = Target.GetReservationen().Count;
            var res = new ReservationDto();
            res.Kunde = Target.GetKunde(1);
            res.Auto = Target.GetAuto(1);
            Target.AddReservation(res);
            Assert.AreEqual(count+1, Target.GetReservationen().Count);
        }

        [TestMethod]
        public void Test_UpdateAuto()
        {
            var orig = Target.GetAuto(1);
            var mod = orig.Clone();
            mod.Marke = "DuckCar";
            Target.UpdateAuto(mod, orig);

            var updated = Target.GetAuto(1);
            Assert.AreEqual("DuckCar", updated.Marke);
        }

        [TestMethod]
        public void Test_UpdateKunde()
        {
            var orig = Target.GetKunde(1);
            var mod = orig.Clone();
            mod.Nachname = "Duck";
            Target.UpdateKunde(mod, orig);

            var updated = Target.GetKunde(1);
            Assert.AreEqual("Duck", updated.Nachname);
        }

        [TestMethod]
        public void Test_UpdateReservation()
        {
            var orig = Target.GetReservation(1);
            var mod = orig.Clone();
            var kunde = Target.GetKunde(2);
            mod.Kunde = kunde;

            Target.UpdateReservation(mod, orig);

            var updated = Target.GetReservation(1);
            Assert.AreEqual(2, updated.Kunde.Id);
        }

        [TestMethod]
        [ExpectedException(typeof(FaultException<AutoDto>))]
        public void Test_UpdateAutoWithOptimisticConcurrency()
        {
            var orig = Target.GetAuto(1);
            var mod1 = orig.Clone();
            var mod2 = orig.Clone();

            mod1.Marke = "DuckCar";
            Target.UpdateAuto(mod1, orig);

            mod2.Marke = "BunnyCar";
            Target.UpdateAuto(mod2, orig);
        }

        [TestMethod]
        [ExpectedException(typeof(FaultException<KundeDto>))]
        public void Test_UpdateKundeWithOptimisticConcurrency()
        {
            var orig = Target.GetKunde(1);
            var mod1 = orig.Clone();
            var mod2 = orig.Clone();

            mod1.Nachname = "Duck";
            Target.UpdateKunde(mod1, orig);

            mod2.Nachname = "Bunny";
            Target.UpdateKunde(mod2, orig);
        }

        [TestMethod]
        [ExpectedException(typeof(FaultException<ReservationDto>))]
        public void Test_UpdateReservationWithOptimisticConcurrency()
        {
            var orig = Target.GetReservation(1);
            var mod1 = orig.Clone();
            var mod2 = orig.Clone();
            var auto1 = Target.GetAuto(2);
            var auto2 = Target.GetAuto(3);

            mod1.Auto = auto1;
            Target.UpdateReservation(mod1, orig);

            mod2.Auto = auto2;
            Target.UpdateReservation(mod2, orig);
        }

        [TestMethod]
        public void Test_DeleteKunde()
        {
            var count = Target.GetKunden().Count;
            var kunde = Target.GetKunde(1);
            Target.DeleteKunde(kunde);
            Assert.AreEqual(count -1, Target.GetKunden().Count);
            Assert.IsNull(Target.GetKunde(1));
        }

        [TestMethod]
        public void Test_DeleteAuto()
        {
            var count = Target.GetAutos().Count;
            var auto = Target.GetAuto(1);
            Target.DeleteAuto(auto);
            Assert.AreEqual(count -1, Target.GetAutos().Count);
            Assert.IsNull(Target.GetAuto(1));
        }

        [TestMethod]
        public void Test_DeleteReservation()
        {
            var count = Target.GetReservationen().Count;
            var res = Target.GetReservation(1);
            Target.DeleteReservation(res);
            Assert.AreEqual(count -1, Target.GetReservationen().Count);
            Assert.IsNull(Target.GetReservation(1));
        }
    }
}
