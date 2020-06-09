using ComfortWPF.Mvvm;
using System.Windows.Controls;

namespace ComfortWPF.Demo
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
