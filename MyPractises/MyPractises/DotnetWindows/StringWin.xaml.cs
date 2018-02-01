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

namespace MyPractises.DotnetWindows
{
    /// <summary>
    /// Interaction logic for StringWin.xaml
    /// </summary>
    public partial class StringWin : Window
    {
        public StringWin()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string str = "北京最有名的景点是天安门，1949年10月1日，毛主席在天安门上宣布新中国正式成立";

            int i = -1;
            int index = 0;
            do
            {
                i++;
                str = str.Substring(index + 1);
                index = str.IndexOf("天安门");
            } while (index != -1);

            MessageBox.Show(i.ToString());
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(string.Join("..", "test1", "test2"));
        }
    }
}
