using Microsoft.VisualStudio.TestTools.UnitTesting;
using ComfortWPF.Mvvm;
using ComfortWPF.Services;

namespace ComfortWPF.Tests
{
    [TestClass]
    public class ViewResolverTest
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
        public void ResolveTShouldWork()
        {
            var viewResolver = serviceProvider.GetService<IViewResolver>();
            Assert.IsNotNull(viewResolver);

            var fooView = viewResolver.Resolve<FooView>();
            Assert.IsNotNull(fooView);
            BootStrapper.Dispose();
        }

        [TestMethod]
        public void ResolveByViewNameShouldWork()
        {
            var viewResolver = serviceProvider.GetService<IViewResolver>();
            Assert.IsNotNull(viewResolver);

            var fooView = viewResolver.Resolve(typeof(FooView).FullName);
            Assert.IsNotNull(fooView);
            BootStrapper.Dispose();
        }
    }
}
