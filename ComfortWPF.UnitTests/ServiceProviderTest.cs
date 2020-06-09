using Microsoft.VisualStudio.TestTools.UnitTesting;
using ComfortWPF.Mvvm;
using ComfortWPF.Services;

namespace ComfortWPF.Tests
{
    [TestClass]
    public class ServiceProviderTest
    {
        private IServiceProvider serviceProvider;

        [TestInitialize]
        public void Initialize()
        {
            BootStrapper.AddAssemblyCatalog(typeof(ServiceProviderTest));
            BootStrapper.AddAssemblyCatalog(typeof(BootStrapper));
            BootStrapper.Initialize();
            serviceProvider = BootStrapper.Container.GetExportedValue<IServiceProvider>();
        }

        [TestMethod]
        public void GetServiceShouldWork()
        {
            Assert.IsNotNull(serviceProvider.GetService<IMessageChannel>());
            Assert.IsNotNull(serviceProvider.GetService<IDialogService>());
            Assert.IsNotNull(serviceProvider.GetService<IDispatcherService>());
            Assert.IsNotNull(serviceProvider.GetService<IOpenFileService>());
            Assert.IsNotNull(serviceProvider.GetService<IMessageBoxService>());
            Assert.IsNotNull(serviceProvider.GetService<ISaveFileService>());
            Assert.IsNotNull(serviceProvider.GetService<IViewResolver>());
            Assert.IsNotNull(serviceProvider.GetService<IViewModelResolver>());
        }
    }
}
