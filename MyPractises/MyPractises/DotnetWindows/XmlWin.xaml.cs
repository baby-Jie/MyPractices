using MyPractises.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
using System.Xml;
using System.Xml.Linq;

namespace MyPractises.DotnetWindows
{
    /// <summary>
    /// Interaction logic for XmlWin.xaml
    /// </summary>
    public partial class XmlWin : Window
    {
        public XmlWin()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CreateXmlByXmlDocument();
            
            
        }

        void CreateXmlByXmlDocument()
        {
            XmlDocument document = new XmlDocument();

            XmlDeclaration declaration = document.CreateXmlDeclaration("1.0", "UTF-8", "yes");
            document.AppendChild(declaration);
           


            XmlElement rootElement = document.CreateElement("School");
            document.AppendChild(rootElement);


            XmlElement @class = document.CreateElement("class");
            XmlAttribute attribute = document.CreateAttribute("id");
            attribute.Value = "12";
            @class.Attributes.Append(attribute);

            Student stu1 = new Student() { Name = "smx", Score = 123};
            Student stu2 = new Student { Name = "xyj", Score = 234};
            List<Student> stus = new List<Student>();
            stus.Add(stu1);
            stus.Add(stu2);

            foreach (var item in stus)
            {
                XmlElement element = document.CreateElement("Student");

                XmlElement nameElement = document.CreateElement("Name");
                nameElement.InnerText = item.Name;


                XmlAttribute attribute1 = document.CreateAttribute("score");
                attribute1.Value = item.Score.ToString();

                element.AppendChild(nameElement);
                element.Attributes.Append(attribute1);

                @class.AppendChild(element);

            }
            rootElement.AppendChild(@class);

            document.Save("test.xml");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
        }
        XDocument document = XDocument.Load(@"Data\users.xml");
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadXml();

        }

        private void LoadXml()
        {
            XElement root = document.Root;
            IEnumerable<XElement> users = root.Elements("user");

            lvUsers.ItemsSource = users;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            document.Save(@"Data\users.xml");
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            XElement ele = new XElement("user");
            XAttribute att = new XAttribute("id", int.Parse(tbId.Text));
            ele.Add(att);
            XElement name = new XElement("name");
            name.Value = tbName.Text;
            XElement address = new XElement("address");
            address.Value = tbAddress.Text;

            ele.Add(name);
            ele.Add(address);
            XElement root = document.Root;
            root.Add(ele);
            LoadXml();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            XElement root = document.Root;
            XElement remove = lvUsers.SelectedItem as XElement;
            remove.Remove();
            LoadXml();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            Person p = new Person() { Id = 1, Name = "smx"};
            MySerializeXml(p);
        }

        void MySerializeXml(object obj)
        {
            Type type = obj.GetType();

            XDocument document = new XDocument();
            XDeclaration declaration = new XDeclaration("1.0", "UTF-8", "yes");
            document.Declaration = declaration;

            string className = type.Name;
            string rootName = className.Substring( className.LastIndexOf('.')+1);
            XElement root = new XElement(rootName);
            GetElementByObj(obj, root);
            document.Add(root);
            document.Save("test.xml");

        }

        void GetElementByObj(object obj, XElement root)
        {
            Type type = obj.GetType();
            PropertyInfo[] proInfos = type.GetProperties();
            foreach (var item in proInfos)
            {
                XElement element = new XElement(item.Name);
                element.SetValue(item.GetValue(obj));
                root.Add(element);
            }
        }
    }


    public class  TestXml
    {
        public Person p { get; set; }

        public int Id;

        public string Address { get; set; }
    }
}
