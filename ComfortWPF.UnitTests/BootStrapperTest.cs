using System;
using System.ComponentModel.Composition;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ComfortWPF.Mvvm;
using ComfortWPF.Services;

namespace ComfortWPF.Tests
{
    [TestClass]
    public class BootStrapperTest
    {
        [TestInitialize]
        public void Initialize()
        {
            BootStrapper.AddAssemblyCatalog(typeof(BootStrapperTest));
            BootStrapper.AddAssemblyCatalog(typeof(BootStrapper));
            BootStrapper.Initialize();
        }

        [TestMethod]
        public void GetExportedValueShouldWork()
        {
            Assert.IsNotNull(BootStrapper.Container.GetExportedValue<Services.IServiceProvider>());
            Assert.IsNotNull(BootStrapper.Container.GetExportedValue<IMessageChannel>());
            Assert.IsNotNull(BootStrapper.Container.GetExportedValue<IDialogService>());
            Assert.IsNotNull(BootStrapper.Container.GetExportedValue<IDispatcherService>());
            Assert.IsNotNull(BootStrapper.Container.GetExportedValue<IOpenFileService>());
            Assert.IsNotNull(BootStrapper.Container.GetExportedValue<IMessageBoxService>());
            Assert.IsNotNull(BootStrapper.Container.GetExportedValue<ISaveFileService>());
            Assert.IsNotNull(BootStrapper.Container.GetExportedValue<IViewResolver>());
            Assert.IsNotNull(BootStrapper.Container.GetExportedValue<IViewModelResolver>());
        }

        [TestMethod]
        public void SetterInjectionShouldWork()
        {
            var importTest = new SetterInjection();
            BootStrapper.Container.SatisfyImportsOnce(importTest);
            Assert.IsNotNull(importTest.DialogService);
        }

        [TestMethod]
        public void ConstructorInjectionShouldWork()
        {
            var constructorInjection = BootStrapper.Container.GetExportedValue<ConstructorInjection>();
            Assert.IsNotNull(constructorInjection);
            Assert.IsNotNull(constructorInjection.DialogService);
            Assert.IsNotNull(constructorInjection.DispatcherService);
        }
    }
}
