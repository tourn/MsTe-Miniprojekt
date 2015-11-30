using AutoReservation.Dal;
using AutoReservation.TestEnvironment;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AutoReservation.BusinessLayer.Testing
{
    [TestClass]
    public class BusinessLayerTest
    {
        private AutoReservationBusinessComponent target;
        private AutoReservationBusinessComponent Target
        {
            get
            {
                if (target == null)
                {
                    target = new AutoReservationBusinessComponent();
                }
                return target;
            }
        }


        [TestInitialize]
        public void InitializeTestData()
        {
            TestEnvironmentHelper.InitializeTestData();
        }
        
        [TestMethod]
        public void Test_GetAuto()
        {
            var auto = Target.GetAuto(1);
            Assert.AreEqual("Fiat Punto", auto.Marke);
        }

        [TestMethod]
        public void Test_UpdateAuto()
        {
            var orig = Target.GetAuto(1);
            var mod = Target.GetAuto(1);
            mod.Marke = "Duck Car";
            target.UpdateAuto(mod, orig);

            mod = target.GetAuto(1);
            Assert.AreEqual("Duck Car", mod.Marke);
        }

        [TestMethod]
        [ExpectedException(typeof(LocalOptimisticConcurrencyException<Auto>))]
        public void Test_UpdateAutoModifiedElsewhere()
        {
            var target1 = new AutoReservationBusinessComponent();
            var target2 = new AutoReservationBusinessComponent();
            var orig1 = target1.GetAuto(1);
            var orig2 = target2.GetAuto(1);
            var mod1 = target1.GetAuto(1);
            var mod2 = target2.GetAuto(1);

            mod1.Marke = "Duck Car";
            target1.UpdateAuto(mod1, orig1);

            mod2.Marke = "Cat Car";
            target2.UpdateAuto(mod2, orig2);
        }

        [TestMethod]
        public void Test_UpdateKunde()
        {
            var orig = Target.GetKunde(1);
            var mod = Target.GetKunde(1);
            mod.Nachname = "Duck";
            target.UpdateKunde(mod, orig);

            var updated = Target.GetKunde(1);
            Assert.AreEqual("Duck", mod.Nachname);
        }

        [TestMethod]
        public void Test_UpdateReservation()
        {
            var orig = Target.GetReservation(1);
            var mod = Target.GetReservation(1);
            var auto = Target.GetAuto(2);
            mod.Auto = auto;
            mod.AutoId = auto.Id;
            target.UpdateReservation(mod, orig);

            var updated = Target.GetReservation(1);
            Assert.AreEqual(auto.Id, updated.Auto.Id);
        }
    }
}
