using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MyPractises.Windows
{
    /// <summary>
    /// Interaction logic for MiniAndShutdownWin.xaml
    /// </summary>
    public partial class MiniAndShutdownWin : Window
    {
        public MiniAndShutdownWin()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            App.Current.MainWindow.WindowState = WindowState.Minimized;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //  App.Current.Shutdown();  //关闭程序
            //  App.Current.MainWindow.Close();
            this.Close();
        }
    }
}
