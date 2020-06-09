using System;

namespace ComfortWPF.Services
{
    public interface IDispatcherService 
    {
        void BeginInvoke(Delegate method, params object[] parameters);
    }
}
