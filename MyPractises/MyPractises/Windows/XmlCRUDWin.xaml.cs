using MyPractises.Models;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Xml.Serialization;

namespace MyPractises.Windows
{
    /// <summary>
    /// Interaction logic for XmlCRUDWin.xaml
    /// </summary>
    public partial class XmlCRUDWin : Window
    {
        public XmlCRUDWin()
        {
            InitializeComponent();
        }

        Detects detects = new Detects();



        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                XmlSerializer xml = new XmlSerializer(typeof(Detects));
                using (FileStream fs = File.Open("test.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite))
                {
                    detects = (Detects)xml.Deserialize(fs);
                }

            }
            catch 
            {
                //LogWriter.Instance.ActionLogger.Error(ex.Message);
            }
            dgDetectPos.ItemsSource = detects.DetectPos;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            XmlSerializer xml = new XmlSerializer(typeof(Detects));
            using (FileStream fs = File.Open("test.xml", FileMode.Create, FileAccess.ReadWrite))//一定要使用 FileMode.Create 否则只覆盖了一部分xml内容  造成反序列化失败
            {

                xml.Serialize(fs, detects);
            }
        }
    }

    public class Detects
    {
        public List<DetectPositionInfo> DetectPos = new List<DetectPositionInfo>();
    }
}
