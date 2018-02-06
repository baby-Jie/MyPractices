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
    /// Interaction logic for VirtualFunWin.xaml
    /// </summary>
    public partial class VirtualFunWin : Window
    {
        public VirtualFunWin()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Base child = new Child();
            tbTest.Text =  child.Fun1();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Base child = new Child();
            tbTest.Text = child.Func2();
        }
    }

    class Base
    {
        public virtual string Fun1()
        {
            return "func1 in Base";
        }

        public virtual string Func2()
        {
            return "func2 in Base";
        }
    }

    class Parent : Base
    {
        public override string Fun1()
        {
            return "func1 in Parent";
        }

        public override string Func2()
        {
            return "func2 in Parent";
        }
    }

    class Child : Parent
    {
        public override string Fun1()
        {
            return "func1 in child";
        }
    }
}
