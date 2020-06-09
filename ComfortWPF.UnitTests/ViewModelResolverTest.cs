using Microsoft.VisualStudio.TestTools.UnitTesting;
using ComfortWPF.Mvvm;
using ComfortWPF.Services;

namespace ComfortWPF.Tests
{
    [TestClass]
    public class ViewModelResolverTest
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
        public void ResolveShouldWork()
        {
            IViewModelResolver viewModelResolver = serviceProvider.GetService<IViewModelResolver>();
            Assert.IsNotNull(viewModelResolver);

            FooView fooView = new FooView();
            fooView.SetValue(ViewModelLocator.ViewModelProperty, typeof(FooViewModel).FullName);
            FooViewModel fooViewModel = viewModelResolver.Resolve<FooViewModel>();
            Assert.IsNotNull(fooViewModel);
            BootStrapper.Dispose();
        }
    }
}
