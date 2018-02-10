using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
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
    /// Interaction logic for ThreadWin.xaml
    /// </summary>
    public partial class ThreadWin : Window
    {
        public ThreadWin()
        {
            InitializeComponent();
            SumComplete = new Action<int>(GetSum);
            GetSumDel = new Func<int, int>(GetMySum);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Thread th1 = new Thread(CalculateSum);
            th1.Start(20);
        }


        void CalculateSum(object l)
        {
            int num = (int)l;
            
            int sum = 0;
            for (int i = 0; i < num; i++)
            {
                sum++;
                Thread.Sleep(100);
            }
            
        //    SumComplete(sum);
           
        }

        Action<int> SumComplete;
        Func<int, int> GetSumDel;


        void GetSum(int sum)
        {
            this.Dispatcher.BeginInvoke((Action)(()=>
            {
                tbSum.Text = sum.ToString();
            }));
            
        }

        int GetMySum(int num)
        {
            int sum = 0;
            for (int i = 0; i < num; i++)
            {
                sum++;
                Thread.Sleep(100);
            }
            return sum;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(CalculateSum), 20);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            GetSumDel.BeginInvoke(20, new AsyncCallback(AsyncCallBack), "test");
        }

        void AsyncCallBack(IAsyncResult iret)
        {
            MessageBox.Show(iret.AsyncState.ToString());
            AsyncResult res = iret as AsyncResult;

            Func<int, int> del = res.AsyncDelegate as Func<int, int>;
            int sum = del.EndInvoke(iret);
            this.Dispatcher.BeginInvoke((Action)(() =>
            {
                tbSum.Text = sum.ToString();
            }));
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            GetSumAsync(20);
        }

        async void GetSumAsync(int num)
        {
            int sum = await Task<int>.Run((Func<int>)(()=> 
            {
                return GetMySum(num);
            }));

            tbSum.Text = sum.ToString();
        }
    }
}
