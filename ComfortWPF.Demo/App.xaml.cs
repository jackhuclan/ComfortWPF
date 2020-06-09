using ComfortWPF.Extensions;
using ComfortWPF.Mvvm;
using System.Windows;

namespace ComfortWPF.Demo
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            BootStrapper.AddAssemblyCatalog(this.GetType())
                        .AddAssemblyCatalog(typeof(BootStrapper));
            BootStrapper.Initialize();
        }
    }
}
