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
    /// Interaction logic for DependencyPropertySetValueWin.xaml
    /// </summary>
    public partial class DependencyPropertySetValueWin : Window
    {
        public DependencyPropertySetValueWin()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            btn.SetValue(Grid.RowProperty, 1);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            Grid.SetRow(btn, 2);
        }
    }
}
