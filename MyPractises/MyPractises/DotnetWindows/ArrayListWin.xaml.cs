using LogLibrary;
using MyPractises.Models;
using System;
using System.Collections;
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
    /// Interaction logic for ArrayListWin.xaml
    /// </summary>
    public partial class ArrayListWin : Window
    {
        public ArrayListWin()
        {
            InitializeComponent();
            LoadStudents();
        }

        ArrayList lst = new  ArrayList();
        void LoadStudents()
        {
            lst.Add(new Student() { Id = 1, Name = "smx", Score = 63.3 });
            lst.Add(new Student() { Id = 2, Name = "xyj", Score = 44.3 });
            lst.Add(new Student() { Id = 3, Name = "xpg", Score = 55.3 });
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            lst.Sort();

            string str = string.Empty;
            foreach (var item in lst)
            {
                str = str + item + "\n"; 
            }

            MessageBox.Show(str);
        }

        Hashtable hashtable = new Hashtable();
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            hashtable.Add(1, "123");
            hashtable.Add(2, 23);
            hashtable.Add(3, new Student() { Id = 1, Name = "smx", Score = 33.33});

            var keys = hashtable.Keys;
            var values = hashtable.Values;

            foreach (var item in keys)
            {
                LogHelper.Log(item.ToString());
                Console.WriteLine(item);
            }

            foreach (var item in values)
            {
                LogHelper.Log(item.ToString());
                Console.WriteLine(item);
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Dictionary<int, string> dic = new Dictionary<int, string>();

            dic.Add(1, "111");
            dic.Add(2, "222");
            dic.Add(3, "333");
            dic.Add(4, "444");

            foreach (KeyValuePair<int, string> item in dic)
            {
                LogHelper.Log("key:{0}, value:{1}", item.Key, item.Value);
            }
        }
    }
}
