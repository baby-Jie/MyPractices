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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MyPractises.ShapesWindows
{
    /// <summary>
    /// Interaction logic for Animation1Win.xaml
    /// </summary>
    public partial class Animation1Win : Window
    {
        public Animation1Win()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DoubleAnimation daX = new DoubleAnimation();
            Duration duration = new Duration(TimeSpan.FromMilliseconds(600));

            daX.To = 100;
            daX.Duration = duration;

            tt.BeginAnimation(TranslateTransform.XProperty, daX);
        }
    }
}
