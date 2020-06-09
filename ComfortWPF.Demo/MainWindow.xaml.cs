using ComfortWPF.Mvvm;
using System.Windows;

namespace ComfortWPF.Demo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //show how to get arbitrary view at anytime
            var userControl1 = ViewResolver.Instance.Resolve<UserControl1>();
            this.cc.Content = userControl1;
        }
    }
}
