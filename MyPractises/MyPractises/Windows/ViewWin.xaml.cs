using MyPractises.Converters;
using MyPractises.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for ViewWin.xaml
    /// </summary>
    public partial class ViewWin : Window
    {
        public ViewWin()
        {
            InitializeComponent();
            LoadStudents();
            ListCollectionView view = (ListCollectionView)CollectionViewSource.GetDefaultView(lstStudents);
            //     view.SortDescriptions.Add(new SortDescription("Address", ListSortDirection.Ascending));
            //   view.GroupDescriptions.Add(new PropertyGroupDescription("Address"));
            view.SortDescriptions.Add(new SortDescription("Score", ListSortDirection.Descending));
            PropertyGroupDescription p = new PropertyGroupDescription("Score");
            p.Converter = new GroupRangeConverter() { Interval  =10};
            view.GroupDescriptions.Add(p);
            
            lstStus.ItemsSource = lstStudents;
            view.Filter = new Predicate<object>(stu => { return ((Student)stu).Score > 10; });
        }

        List<Student> lstStudents;

        void LoadStudents()
        {
            lstStudents = new List<Student>();

            lstStudents.Add(new Student() { Id = 1, Name = "smx", Address = "lyg", Score = 45 });
            lstStudents.Add(new Student() { Id = 2, Name = "xyj", Address = "lyg", Score = 99 });
            lstStudents.Add(new Student() { Id = 3, Name = "wx", Address = "hm", Score = 23 });
            lstStudents.Add(new Student() { Id = 1, Name = "xth", Address = "hm", Score = 11 });
            lstStudents.Add(new Student() { Id = 1, Name = "hhr", Address = "rg", Score = 67 });
            lstStudents.Add(new Student() { Id = 1, Name = "mlw", Address = "yc", Score = 56 });
            lstStudents.Add(new Student() { Id = 1, Name = "lx", Address = "hm", Score = 10 });
        }
    }
}
