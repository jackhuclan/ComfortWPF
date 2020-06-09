using ComfortWPF.Mvvm;
using System.ComponentModel.Composition;

namespace ODT.MvvnDemo.ViewModels
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
