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
    /// Interaction logic for Animation2Win.xaml
    /// </summary>
    public partial class Animation2Win : Window
    {
        public Animation2Win()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DoubleAnimation daX = new DoubleAnimation();
            DoubleAnimation daY = new DoubleAnimation();
            Duration duration = new Duration(TimeSpan.FromMilliseconds(600));

            daX.To = 100;
            daY.To = 200;
            daY.Duration = duration;
            daX.Duration = duration;

            BounceEase be = new BounceEase();
            be.Bounces = 3;
            be.Bounciness = 3;

            daY.EasingFunction = be;

            tt.BeginAnimation(TranslateTransform.XProperty, daX);
            tt.BeginAnimation(TranslateTransform.YProperty, daY);
        }
    }
}
