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
    /// Interaction logic for GenericWin.xaml
    /// </summary>
    public partial class GenericWin : Window
    {
        public GenericWin()
        {
            InitializeComponent();
        }
    }
}

//l 接口约束：Where T: System.IComparable<T>

//l  基类约束：Where T: Person

//l  struct/class约束：Where T: struct

//l  多个约束：Where T: IComparable<T>,IFormattable

//l  构造器约束：Where: new()

