using MyPractises.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
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
using System.Xml.Serialization;

namespace MyPractises.DotnetWindows
{
    /// <summary>
    /// Interaction logic for SerializerWin.xaml
    /// </summary>
    public partial class SerializerWin : Window
    {
        public SerializerWin()
        {
            InitializeComponent();
        }

        Student stu = new Student() { Id = 1, Name = "smx", Score = 20};
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            BinaryFormatter bin = new BinaryFormatter();
            using (FileStream fs = File.Open("bin.txt", FileMode.Create, FileAccess.Write))
            {
                bin.Serialize(fs, stu);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //Additional information: 要使 XML 可序列化，从 IEnumerable 继承的类型必须在继承层次结构的所有级别上实现 Add(System.Object)。
            //MyPractises.Models.Student 不支持实现 Add(System.Object)。
            //      XmlSerializer xml = new XmlSerializer(typeof(Student));

            DetectPositionInfo detect = new DetectPositionInfo() { Ip = "192.168.1.111", Name = "江宁"};

            XmlSerializer xml = new XmlSerializer(typeof(DetectPositionInfo));

            using (FileStream fs = File.Open("detect.xml", FileMode.Create, FileAccess.Write))
            {
                xml.Serialize(fs, detect);
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            SoapFormatter soap = new SoapFormatter();
            using (FileStream fs = File.Open("soap.txt", FileMode.Create, FileAccess.Write))
            {
                soap.Serialize(fs, stu);
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            //在这里json序列化Student失败
            Person p = new Person() { Id = 1, Name = "smx"};
            string str = JsonConvert.SerializeObject(p);
            tbShowMsg.Text = str;

            Person stu1 = (Person)JsonConvert.DeserializeObject(str, typeof(Person));
            MessageBox.Show(stu1.Name);
        }
    }
}
