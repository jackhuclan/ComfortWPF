using ComfortWPF.Mvvm;

namespace ODT.MvvnDemo.ViewModels
{
    [InjectedViewModel(typeof(UserControl1ViewModel))]
    public class UserControl1ViewModel : ViewModelBase
    {
        public UserControl1ViewModel()
        {
            
        }
    }
}
