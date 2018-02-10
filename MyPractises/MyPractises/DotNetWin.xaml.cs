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
            ArrayListWin win = new ArrayListWin();
            win.ShowDialog(); 
        }

        private void btnGeneric_Click(object sender, RoutedEventArgs e)
        {
            GenericWin win = new GenericWin();
            win.ShowDialog();
        }

        private void btnIEnumerable_Click(object sender, RoutedEventArgs e)
        {
            IEnumerableWin win = new IEnumerableWin();
            win.ShowDialog();
        }

        private void btnIo_Click(object sender, RoutedEventArgs e)
        {
            FileIOWin win = new FileIOWin();
            win.ShowDialog();
        }

        private void btnSerializer_Click(object sender, RoutedEventArgs e)
        {
            SerializerWin win = new SerializerWin();
            win.ShowDialog();
        }

        private void btnVirtualFun_Click(object sender, RoutedEventArgs e)
        {
            VirtualFunWin win = new VirtualFunWin();
            win.ShowDialog();
        }

        private void btnLinq_Click(object sender, RoutedEventArgs e)
        {
            LinqWin win = new LinqWin();
            win.ShowDialog();
        }

        private void btnRegex_Click(object sender, RoutedEventArgs e)
        {
            RegexWin win = new RegexWin();
            win.ShowDialog();
        }

        private void btnThread_Click(object sender, RoutedEventArgs e)
        {
            ThreadWin win = new ThreadWin();
            win.ShowDialog();
        }
    }

    abstract class TestAbs1
    {
    }

    abstract class TestAbs2
    {
        TestAbs1 test1;
    }
}
