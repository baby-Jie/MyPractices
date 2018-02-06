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
    /// Interaction logic for StyleAndDatatemplateSelector.xaml
    /// </summary>
    public partial class StyleAndDatatemplateSelectorWin : Window
    {
        List<Person> persons = new List<Person>();
        public StyleAndDatatemplateSelectorWin()
        {
            InitializeComponent();
            LoadPerson();
            lstPersonInSchool.ItemsSource = persons;
        }

        void LoadPerson()
        {
            persons.Add(new Student() { Id = 1, Name = "孙明星", Score = 99.9 });
            persons.Add(new Teacher() { Id = 2, Name = "王一宁", Category = "班主任" });
            persons.Add(new Student() { Id = 3, Name = "徐艳杰", Score = 100 });
            persons.Add(new Teacher() { Id = 4, Name = "刘素芬", Category = "Labview" });
        }
    }
}
