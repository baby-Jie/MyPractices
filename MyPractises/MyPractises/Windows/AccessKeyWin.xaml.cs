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
    /// Interaction logic for AccessKeyWin.xaml
    /// </summary>
    public partial class AccessKeyWin : Window
    {
        public AccessKeyWin()
        {
            InitializeComponent();
        }

        private void Label_AccessKeyPressed(object sender, AccessKeyPressedEventArgs e)
        {
            MessageBox.Show("accesskey is pressed");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("default button is pressed");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("cancel button is pressed");
            
        }
    }
}
