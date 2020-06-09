using ComfortWPF.Mvvm;
using System.Windows;

namespace ComfortWPF.Demo
{
    [PopupView(typeof(PopupWindow))]
    public partial class PopupWindow : Window
    {
        public PopupWindow()
        {
            InitializeComponent();
        }
    }
}
