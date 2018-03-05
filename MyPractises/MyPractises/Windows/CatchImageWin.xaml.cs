using MyPractises.Comman;
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

namespace MyPractises.Windows
{
    /// <summary>
    /// Interaction logic for CatchImageWin.xaml
    /// </summary>
    public partial class CatchImageWin : Window
    {
        public CatchImageWin()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            byte[] buffer = ImageHelper.SnapShotToJpeg(this, 1, 96);
            string filepath = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            filepath = System.IO.Path.Combine(filepath, "1.jpg");
            using (FileStream fs = File.Open(filepath, FileMode.Create, FileAccess.Write))
            {
                fs.Write(buffer, 0, buffer.Length);
                fs.Flush();
                fs.Close();
            }
        }
    }
}
