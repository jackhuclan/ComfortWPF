using ComfortWPF.Mvvm;
using System.Windows.Controls;

namespace ODT.MvvnDemo
{
    [PartialView(typeof(UserControl1))]
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }
    }
}
