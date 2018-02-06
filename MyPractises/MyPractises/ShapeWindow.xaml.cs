using MyPractises.ShapesWindows;
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

namespace MyPractises
{
    /// <summary>
    /// Interaction logic for ShapeWindow.xaml
    /// </summary>
    public partial class ShapeWindow : Window
    {
        public ShapeWindow()
        {
            InitializeComponent();
        }

        private void btnLine_Click(object sender, RoutedEventArgs e)
        {
            LineWin win = new LineWin();
            win.ShowDialog();
        }

        private void btnRectangle_Click(object sender, RoutedEventArgs e)
        {
            RectAngleWin win = new RectAngleWin();
            win.ShowDialog();
        }

        private void btnEllipse_Click(object sender, RoutedEventArgs e)
        {
            EllipseWin win = new EllipseWin();
            win.ShowDialog();
        }

        private void btnPath_Click(object sender, RoutedEventArgs e)
        {
            PathWin win = new PathWin();
            win.ShowDialog();
        }

        private void btnRenderTransform_Click(object sender, RoutedEventArgs e)
        {
            RenderTransformWin win = new RenderTransformWin();
            win.ShowDialog();
        }

        private void btnLayoutTransform_Click(object sender, RoutedEventArgs e)
        {
            LayoutTransformWin win = new LayoutTransformWin();
            win.ShowDialog();
        }

        private void btnAnimation1_Click(object sender, RoutedEventArgs e)
        {
            Animation1Win win = new Animation1Win();
            win.ShowDialog();
        }

        private void btnAnimation2_Click(object sender, RoutedEventArgs e)
        {
            Animation2Win win = new Animation2Win();
            win.ShowDialog();
        }
    }
}
