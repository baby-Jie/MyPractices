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
    /// Interaction logic for ImprovePerformanceOfItemsControlWin.xaml
    /// </summary>
    public partial class ImprovePerformanceOfItemsControlWin : Window
    {
        public ImprovePerformanceOfItemsControlWin()
        {
            InitializeComponent();
        }

        List<int> testLst = new List<int>();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 100000; i++)
            {
                testLst.Add(i);
            }
            
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            cbTest.ItemsSource = testLst;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            lstTest.ItemsSource = testLst;
        }
    }
}
