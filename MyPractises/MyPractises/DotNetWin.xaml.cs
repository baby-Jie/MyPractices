using MyPractises.DotnetWindows;
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

namespace MyPractises
{
    /// <summary>
    /// Interaction logic for DotNetWin.xaml
    /// </summary>
    public partial class DotNetWin : Window
    {
        public DotNetWin()
        {
            InitializeComponent();
        }

        private void btnEnum_Click(object sender, RoutedEventArgs e)
        {
            EnumWin win = new EnumWin();
            win.ShowDialog();
        }

        private void btnEqual_Click(object sender, RoutedEventArgs e)
        {
            EqualWin win = new EqualWin();
            win.ShowDialog();
        }

        private void btnString_Click(object sender, RoutedEventArgs e)
        {
            StringWin win = new StringWin();
            win.ShowDialog();
        }

        private void btnArray_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
