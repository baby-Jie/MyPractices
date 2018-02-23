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
            XDocument document = XDocument.Load("test.xml");
        }
    }
}
