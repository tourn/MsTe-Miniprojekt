﻿using AutoReservation.TestEnvironment;
using AutoReservation.Ui.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AutoReservation.Ui.Factory;
using Ninject;

namespace AutoReservation.Ui.Testing
{
    [TestClass]
    public class ViewModelTest
    {
        private IKernel kernel;

        [TestInitialize]
        public void InitializeTestData()
        {
            kernel = new StandardKernel();
            kernel.Load("Dependencies.Ninject.xml");

            TestEnvironmentHelper.InitializeTestData();
        }
        
        [TestMethod]
        public void Test_AutosLoad()
        {
            AutoViewModel vm = new AutoViewModel(kernel.Get<IServiceFactory>());
            vm.Init();

            Assert.IsTrue(vm.LoadCommand.CanExecute(null));
            vm.LoadCommand.Execute(null);
            Assert.AreEqual(3, vm.Autos.Count);
        }

        [TestMethod]
        public void Test_KundenLoad()
        {
            KundeViewModel vm = new KundeViewModel(kernel.Get<IServiceFactory>());
            vm.Init();

            Assert.IsTrue(vm.LoadCommand.CanExecute(null));
            vm.LoadCommand.Execute(null);
            Assert.AreEqual(4, vm.Kunden.Count);
        }

        [TestMethod]
        public void Test_ReservationenLoad()
        {
            ReservationViewModel vm = new ReservationViewModel(kernel.Get<IServiceFactory>());
            vm.Init();

            Assert.IsTrue(vm.LoadCommand.CanExecute(null));
            vm.LoadCommand.Execute(null);
            Assert.AreEqual(3, vm.Autos.Count);
        }
    }
}