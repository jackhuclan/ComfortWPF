using ComfortWPF.IO;
using ComfortWPF.Mvvm;
using System.ComponentModel.Composition;

namespace ComfortWPF.Demo.ViewModels
{
    [InjectedViewModel(typeof(MainWindowViewModel))]
    public class MainWindowViewModel : ViewModelBase
    {
        private string text = "This is a test";
        public DelegateCommand<string> ResolveViewModelCommand { get; set; }
        public DelegateCommand<string> PopupDialogCommand { get; set; }
        private readonly IViewModelResolver viewModelResolver;
        private readonly IViewResolver viewResolver;

        public string Text
        {
            get => text;
            set
            {
                text = value;
                NotifyPropertyChanged(nameof(Text));
            }
        }

        [ImportingConstructor]
        public MainWindowViewModel(IFileOperator fileOperator, IViewModelResolver viewModelResolver, IViewResolver viewResolver)
        {
            ResolveViewModelCommand = new DelegateCommand<string>(OnResolveViewModelCommandExecuted, CanResolveViewModelCommandExecute);
            PopupDialogCommand = new DelegateCommand<string>(OnPopupDialogCommandExecuted, CanPopupDialogCommandExecute);
            this.viewModelResolver = viewModelResolver;
            this.viewResolver = viewResolver;
        }

        private void OnPopupDialogCommandExecuted(string obj)
        {
            var popupWindow = viewResolver.Resolve<PopupWindow>();
            popupWindow.ShowDialog();
        }

        private bool CanPopupDialogCommandExecute(string arg)
        {
            return true;
        }

        private bool CanResolveViewModelCommandExecute(string arg)
        {
            return true;
        }

        private void OnResolveViewModelCommandExecuted(string obj)
        {
            //show how to get arbitrary view model at anytime
            var viewModel = viewModelResolver.Resolve<UserControl1ViewModel>();


        }
    }
}
