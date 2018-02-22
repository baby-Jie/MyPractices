using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Interaction logic for BackgroundWorkerWin.xaml
    /// </summary>
    public partial class BackgroundWorkerWin : Window
    {
        public BackgroundWorkerWin()
        {
            InitializeComponent();
            worker.DoWork += Worker_DoWork;
            worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
        }

        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            var t = e.Result;
            MessageBox.Show(t.ToString());
        }

        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            int sum = 0;
            int num = (int)e.Argument;
            for ( int i = 0; i < num; i++)
            {
                sum += i;
                Thread.Sleep(200);
            }
            e.Result = sum;
        }

        BackgroundWorker worker = new BackgroundWorker();
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            worker.RunWorkerAsync(10);
        }
    }
}
