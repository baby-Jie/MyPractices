using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for RegexWin.xaml
    /// </summary>
    public partial class RegexWin : Window
    {
        public RegexWin()
        {
            InitializeComponent();
        }

        private void btnIsMatch_Click(object sender, RoutedEventArgs e)
        {
            string input = tbText.Text.Trim();
            string pattern = tbPattern.Text.Trim();

            if (string.IsNullOrWhiteSpace(input) || string.IsNullOrWhiteSpace(pattern))
            {
                MessageBox.Show("what you input is empty!");
                return;
            }

            if (Regex.IsMatch(input, pattern))
            {
                MessageBox.Show("Yes!");
            }
            else
            {
                MessageBox.Show("Not Match!");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string ipInfor = tbIp.Text.Trim();
            try
            {
                
            }
            catch (Exception)
            {
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string str = tbUrl.Text;

            Regex regex = new Regex(@"rtsp\:\/\/(?<Address>[\d\.]+)[\w]?");
            Match match = regex.Match(str);

            if (match.Success)
            {
                MessageBox.Show(match.Groups["Address"].Value);
            }

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            string str = tbGroup.Text;

            Regex regex = new Regex(@"(?<test>[\w]+):[\w\:\@\/]+?(?<test2>[\d.]+)");
            Match match = regex.Match(str);
            if (match.Success)
            {
                MessageBox.Show(match.Groups["test2"].Value);
            }
        }
    }
}


//xaml中的特殊符号 <(&lt;)   >(&gt;) &(&amp;)  "(&quot)