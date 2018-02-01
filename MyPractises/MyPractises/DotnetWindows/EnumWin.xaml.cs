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
    /// Interaction logic for EnumWin.xaml
    /// </summary>
    public partial class EnumWin : Window
    {
        public EnumWin()
        {
            InitializeComponent();
        }
        Phone phoneType = Phone.HuaWei;
        GFBF state = GFBF.富 | GFBF.帅 | GFBF.高;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(((int)phoneType).ToString());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(phoneType.ToString());
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            string phoneString = "Mi";
            phoneType = (Phone)Enum.Parse(typeof(Phone), phoneString);
            MessageBox.Show(phoneType.ToString());
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(state.ToString());
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            GFBF mystate = GFBF.帅 | GFBF.富;
            if ((mystate & GFBF.富) == GFBF.富)
            {
                MessageBox.Show("有");
            }
            else
            {
                MessageBox.Show("没有");
            }
        }
    }

    public enum Phone
    {
        IPhone,
        Mi,
        HuaWei,
        MeiZu
    }

    [Flags]
    public enum GFBF
    {
        高 = 1,

        富 = 2,

        帅 = 4,

        白 = 8,

        美 = 16


    }
}
