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
    /// Interaction logic for ImageZoomWin.xaml
    /// </summary>
    public partial class ImageZoomWin : Window
    {
        public ImageZoomWin()
        {
            InitializeComponent();
        }

        Point oldPt;

        private void imgTest_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                Point pt = e.GetPosition(gdImage);
                ttImage.X += pt.X - oldPt.X;
                ttImage.Y += pt.Y - oldPt.Y;
                oldPt = pt;
            }
        }

        private void imgTest_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            oldPt = e.GetPosition(gdImage);
        }

        private void imgTest_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            oldPt = e.GetPosition(gdImage);
        }

        private void imgTest_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (e.Delta < 0 && stImage.ScaleX < 0.2) return;

            Point zoomCenter = e.GetPosition(imgTest);
            Point point = imgTest.RenderTransform.Inverse.Transform(zoomCenter);


            this.ttImage.X = (zoomCenter.X - point.X) * this.stImage.ScaleX;
            this.ttImage.Y = (zoomCenter.Y - point.Y) * stImage.ScaleY;

            this.stImage.CenterX = zoomCenter.X;
            this.stImage.CenterY = zoomCenter.Y;

            this.stImage.ScaleX += e.Delta / 1000.0;
            this.stImage.ScaleY += e.Delta / 1000.0;
        }
    }
}
