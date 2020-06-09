using ComfortWPF.Mvvm;
using System.ComponentModel.Composition;

namespace ComfortWPF.Services
{
    [Export(typeof(IServiceProvider))]
    public class ServiceProvider : IServiceProvider
    {
        public T GetService<T>()
        {
            return BootStrapper.Container.GetExportedValue<T>();
        }
    }
}
