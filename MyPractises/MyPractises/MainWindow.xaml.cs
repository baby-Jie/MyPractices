using MyPractises.Windows;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MyPractises
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

        private void btnDonet_Click(object sender, RoutedEventArgs e)
        {
            DotNetWin win = new DotNetWin();
            win.ShowDialog();
        }

        private void btnBehavior_Click(object sender, RoutedEventArgs e)
        {
            InteractionsTestWin win = new InteractionsTestWin();
            win.ShowDialog();
        }

        private void btnCrudInXml_Click(object sender, RoutedEventArgs e)
        {
            XmlCRUDWin  win = new XmlCRUDWin();
            win.ShowDialog();
        }

        private void btnSelector_Click(object sender, RoutedEventArgs e)
        {
            StyleAndDatatemplateSelectorWin win = new StyleAndDatatemplateSelectorWin();
            win.ShowDialog();
        }

        private void btnShape_Click(object sender, RoutedEventArgs e)
        {
            ShapeWindow win = new ShapeWindow();
            win.ShowDialog();
        }

        private void btnAccessKey_Click(object sender, RoutedEventArgs e)
        {
            AccessKeyWin win = new AccessKeyWin();
            win.ShowDialog(); 
        }

        private void btnScrollBarTemp_Click(object sender, RoutedEventArgs e)
        {
            ScrollBarTempWin win = new ScrollBarTempWin();
            win.ShowDialog();
        }
    }
}
