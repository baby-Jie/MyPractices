using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
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
    /// Interaction logic for TimersWin.xaml
    /// </summary>
    public partial class TimersWin : Window
    {
        public TimersWin()
        {
            InitializeComponent();
            timer = new Timer(1000);
            timer.Elapsed += new ElapsedEventHandler((obj, e)=> { MyElasped(obj, e, 10); });
            timer.AutoReset = true;
        }

     

        void MyElasped(object obj, ElapsedEventArgs e, int num)
        {
            i += num;
            tbShowMsg.Dispatcher.BeginInvoke((Action)(()=> 
            {
                tbShowMsg.Text = i.ToString();
            }));
        }

        Timer timer;
        int i = 0;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            timer.Start();
        }
    }
}
