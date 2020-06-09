using ComfortWPF.Mvvm;

namespace ComfortWPF.Demo.ViewModels
{
    [InjectedViewModel(typeof(UserControl1ViewModel))]
    public class UserControl1ViewModel : ViewModelBase
    {
        public UserControl1ViewModel()
        {
            
        }
    }
}
