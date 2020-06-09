using ComfortWPF.Mvvm;
using System.ComponentModel.Composition;

namespace ComfortWPF.Demo.ViewModels
{
    [InjectedViewModel(typeof(PopupWindowViewModel))]
    public class PopupWindowViewModel : ViewModelBase
    {
        [ImportingConstructor]
        public PopupWindowViewModel()
        {
            
        }
    }
}
