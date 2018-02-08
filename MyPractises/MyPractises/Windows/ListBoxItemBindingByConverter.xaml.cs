using MyPractises.Converters;
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

namespace MyPractises.Windows
{
    /// <summary>
    /// Interaction logic for ListBoxItemBindingByConverter.xaml
    /// </summary>
    public partial class ListBoxItemBindingByConverter : Window
    {
        public ListBoxItemBindingByConverter()
        {
            InitializeComponent();
            LoadStudents();
                lstStus.ItemsSource = students;
          //  lstStus.SetBinding(ListBoxItem.ContentProperty, new Binding(".") { Converter = new WholeObjectConverter() });
        }
        List<Student> students = new List<Student>();

        void LoadStudents()
        {
            students.Add(new Student() { Id = 1, Name = "smx", Score = 99});
            students.Add(new Student() { Id = 2, Name = "xyj", Score = 100 });
        }
    }
}
