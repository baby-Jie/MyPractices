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
    /// Interaction logic for EventWin.xaml
    /// </summary>
    public partial class EventWin : Window
    {
        public EventWin()
        {
            InitializeComponent();
        }

        private delegate void MyDel();

     //   MyDel mydel;
        //public event MyDel MyDelHandler
        //{
        //    add { AddHandler(mydel, value); }
        //    remove { RemoveHandler(mydel, value); }
        //}
    }
}
