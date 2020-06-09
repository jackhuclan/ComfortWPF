using ComfortWPF.Services;
using System.ComponentModel.Composition;

namespace ComfortWPF.Tests
{
    [Export(typeof(ConstructorInjection))]
    public class ConstructorInjection
    {
        [ImportingConstructor]
        public ConstructorInjection(IDialogService dialogService, IDispatcherService dispatcherService)
        {
            DialogService = dialogService;
            DispatcherService = dispatcherService;
        }

        public IDialogService DialogService { get; }
        public IDispatcherService DispatcherService { get; }
    }
}
