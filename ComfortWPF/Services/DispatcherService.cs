using System;
using System.ComponentModel.Composition;
using System.Windows.Threading;

namespace ComfortWPF.Services
{
    [Export(typeof(IDispatcherService))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class DispatcherService : IDispatcherService
    {
        private readonly Dispatcher _currentDispatcher;

        public DispatcherService()
        {
            _currentDispatcher = Dispatcher.CurrentDispatcher;
        }

        public void BeginInvoke(Delegate method, params object[] parameters)
        {
            if (_currentDispatcher != null)
                _currentDispatcher.BeginInvoke(method, parameters);
        }
    }
}
