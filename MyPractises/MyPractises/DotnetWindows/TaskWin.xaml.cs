using System;
using System.Collections.Generic;
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
    /// Interaction logic for TaskWin.xaml
    /// </summary>
    public partial class TaskWin : Window
    {
        public TaskWin()
        {
            InitializeComponent();
        }

        private void btnTaskRun_Click(object sender, RoutedEventArgs e)
        {
            Task.Run((Action)(()=> 
            {
                int sum = 0;
                for (int i = 0; i < 10; i++)
                {
                    sum += i;
                    Thread.Sleep(200);
                }
                tbShowResult.Dispatcher.BeginInvoke((Action)(() =>
                {
                    tbShowResult.Text = sum.ToString();
                }));
            }));
        }

        private void btnTaskRunWithRes_Click(object sender, RoutedEventArgs e)
        {
            GetRes(10);
        }

        async void GetRes(int num)
        {
            int sum = await Task<int>.Run((Func<int>)(() => 
            {
                int sum1 = 0;
                for (int i = 0; i < num; i++)
                {
                    sum1 += i;
                    Thread.Sleep(200);
                }
                return sum1;
            }));
            tbShowResult.Text = sum.ToString();
        }

        private void btnTaskFactory_Click(object sender, RoutedEventArgs e)
        {
            TaskFactory factory = new TaskFactory();
            
            factory.StartNew((Action)(() =>
            {
                int sum = 0;
                for (int i = 0; i < 10; i++)
                {
                    sum += i;
                    Thread.Sleep(200);
                }
                tbShowResult.Dispatcher.BeginInvoke((Action)(() =>
                {
                    tbShowResult.Text = sum.ToString();
                }));
            }));
        }
    }
}
