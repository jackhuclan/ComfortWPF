using ComfortWPF.Mvvm;
using System.Windows;

namespace ODT.MvvnDemo
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
