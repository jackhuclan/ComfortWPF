using System.ComponentModel.Composition;
using System.Windows;

namespace ComfortWPF.Mvvm
{
    public interface IViewModelResolver
    {
        T Resolve<T>();
    }
}
