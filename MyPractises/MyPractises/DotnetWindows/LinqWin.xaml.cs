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
    /// Interaction logic for LinqWin.xaml
    /// </summary>
    public partial class LinqWin : Window
    {
        List<Student> lstStudents = new List<Student>();
        public LinqWin()
        {
            InitializeComponent();
            LoadStudents();
        }

        private void btnAny_Click(object sender, RoutedEventArgs e)
        {
            if (lstStudents.Any((stu) => stu.Score < 10))
                MessageBox.Show("the score of someone is below 10!");
            else
                MessageBox.Show("all students are large than ten or equal ten");
        }


        void LoadStudents()
        {
            lstStudents.Add(new Student() { Id = 1, Name = "smx", Address = "lyg", Score = 45 });
            lstStudents.Add(new Student() { Id = 2, Name = "xyj", Address = "yc", Score = 99 });
            lstStudents.Add(new Student() { Id = 3, Name = "wx", Address = "ha", Score = 23 });
            lstStudents.Add(new Student() { Id = 1, Name = "xth", Address = "hm", Score = 11 });
            lstStudents.Add(new Student() { Id = 1, Name = "hhr", Address = "rg", Score = 67 });
            lstStudents.Add(new Student() { Id = 1, Name = "mlw", Address = "yc", Score = 56 });
            lstStudents.Add(new Student() { Id = 1, Name = "lx", Address = "ha", Score = 10 });
        }

        private void btnMax_Click(object sender, RoutedEventArgs e)
        {
           double max = lstStudents.Max(stu => stu.Score);

            MessageBox.Show("the max score is:" + max);
        }

        private void btnAll_Click(object sender, RoutedEventArgs e)
        {
            if (lstStudents.All((stu) => stu.Score > 10))
                MessageBox.Show("all students are large than ten");
            
            else
                MessageBox.Show("the score of someone is below or equal 10!");
        }

        private void btnMinItem_Click(object sender, RoutedEventArgs e)
        {
           var stus = lstStudents.OrderByDescending(stu=>stu.Score).Last();
            string str = string.Format("name:{0}, id:{1}, score:{2}", stus.Name, stus.Id, stus.Score);
            MessageBox.Show(str);
        }

        private void btnLinqExtension_Click(object sender, RoutedEventArgs e)
        {
            bool isFlag = lstStudents.IsAll(obj=>obj.Score>9);
            if (isFlag)
                MessageBox.Show("Yes");
            else
                MessageBox.Show("No");
        }
    }

    public static class LinqExtension
    {
        public static bool IsAll<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            bool isFlag = true;
            foreach (var item in source)
            {
                isFlag &= predicate(item);
            }
            return isFlag;
        }
    }
}
