using System.Windows;

namespace ComfortWPF.Mvvm
{
    public interface IViewResolver
    {
        DependencyObject Resolve(string viewName);
        T Resolve<T>();
    }
}
