using Microsoft.VisualStudio.TestTools.UnitTesting;
using ComfortWPF.Mvvm;
using ComfortWPF.Services;

namespace ComfortWPF.Tests
{
    [TestClass]
    public class MessageChannelTest
    {
        private Services.IServiceProvider serviceProvider;

        [TestInitialize]
        public void Initialize()
        {
            BootStrapper.AddAssemblyCatalog(typeof(ServiceProviderTest));
            BootStrapper.AddAssemblyCatalog(typeof(BootStrapper));
            BootStrapper.Initialize();
            serviceProvider = BootStrapper.Container.GetExportedValue<IServiceProvider>();
        }

        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}
