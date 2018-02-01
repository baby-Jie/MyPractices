using LogLibrary;
using MyPractises.Models;
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
    /// Interaction logic for IEnumerableWin.xaml
    /// </summary>
    public partial class IEnumerableWin : Window
    {
        public IEnumerableWin()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Student stu = new Student();
            foreach (var item in stu)
            {
                LogHelper.Log(item.ToString());
                Console.WriteLine(item);
            }
        }
    }
}

//1、可以被foreach遍历的要求：

//Ø 具有GetEnumerator()方法的类型；

//Ø 实现Ienumerable接口的类型；

//Ø 实现Ienumerable<T>接口的类型。

//  一个类型只要实现了IEnumerable接口，就说这个类型可以被遍历，因为实现了IEnumerable接口，就会有一个叫做GetEnumerator（）的方法，而该方法就可以返回一个可以用来遍历的“工具”。（该工具是一个自己编写的迭代器的实例，该迭代器实现了Ienumerator接口）

//Ø 可枚举类型（具有GetEnumerator()方法）、枚举器（具有IEnumerator接口中的成员的类）

//Ø IEnumerable实现该接口即为可枚举类型

//Ø IEnumerator实现该接口为枚举器

