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
    /// Interaction logic for EqualWin.xaml
    /// </summary>
    public partial class EqualWin : Window
    {
        public EqualWin()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string str1 = "123";
            string str2 = "123";
            //if (str1 == str2)
            //{
            //    MessageBox.Show("Yes");
            //}  
            if (str1.Equals(str2))
            {
                MessageBox.Show("Yes");
            }
            //以上两种方式对于字符串来说一样，都是判断内容
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            object obj1 = new object();
            object obj2 = obj1;

            //if (obj1.Equals(obj2))
            //{
            //    MessageBox.Show("Yes");
            //}
            //if (obj1 == obj2)
            //{
            //    MessageBox.Show("Yes");
            //}

            if (object.ReferenceEquals(obj1, obj2))
            {
                MessageBox.Show("Yes");
            }
        }
    }
}

// 1、判断是否为同一个对象：判断堆栈中的地址是否一样。

//2、==：（查看String）内部调用Equals实现的

//3、Equals：object判断对象的地址是否相同，String判断的内容是否相同。

//4、String重写了Object中的Equals方法。

//5、当两个变量指向同一块内存的时候，我们就说这两个变量是同一个对象。

//6、其实就是判断两个变量指向堆中的内存地址是否相同。

//7、对于字符串的Equal比较的是字符串的内容，而不是对象的地址。

//8、在字符串中==也是比较字符串内容。

//9、字符串类中将object父类中继承下来的Equals（）方法重写了（又添加了一个方法），因为运算符内部的==（运算符重载）后，内部也是调用Equals来实现的，所以结果一样。

//10、在任何情况比较对象是否为同一个对象，使用ReferenceEquals。

//11、Object.ReferenceEquals（s1,s2）：判断两个对象是否为同同一个对象。


