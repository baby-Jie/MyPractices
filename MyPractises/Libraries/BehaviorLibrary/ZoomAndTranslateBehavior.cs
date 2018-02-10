using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interactivity;
using System.Windows.Media;

namespace BehaviorLibrary
{
  public   class ZoomAndTranslateBehavior: Behavior<UIElement>
    {
        TransformGroup transformGroup = new TransformGroup();
        ScaleTransform scale = new ScaleTransform(1.0, 1.0);
        TranslateTransform translate = new TranslateTransform(0, 0);
        protected override void OnAttached()
        {
            base.OnAttached();

           
            transformGroup.Children.Add(scale);
            transformGroup.Children.Add(translate);

            AssociatedObject.RenderTransform = transformGroup;

            AssociatedObject.MouseLeftButtonDown += imgTest_MouseLeftButtonDown;
            AssociatedObject.MouseLeftButtonUp += imgTest_MouseLeftButtonUp;
            AssociatedObject.MouseWheel += imgTest_MouseWheel;
            AssociatedObject.MouseMove += imgTest_MouseMove;

        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
        }

        Point oldPt;

        private void imgTest_MouseMove(object sender, MouseEventArgs e)
        {


            FrameworkElement element = sender as FrameworkElement;
            FrameworkElement parent = element.Parent as FrameworkElement;
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                Point pt = e.GetPosition(parent as UIElement);
                translate.X += pt.X - oldPt.X;
                translate.Y += pt.Y - oldPt.Y;
                oldPt = pt;
            }
        }

        private void imgTest_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            FrameworkElement element = sender as FrameworkElement;
            UIElement parent = element.Parent as UIElement;
            oldPt = e.GetPosition(parent);
        }

        private void imgTest_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            FrameworkElement element = sender as FrameworkElement;
            UIElement parent = element.Parent as UIElement;
            oldPt = e.GetPosition(parent);
        }

        private void imgTest_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            FrameworkElement element = sender as FrameworkElement;
          
            if (e.Delta < 0 && scale.ScaleX < 0.2) return;

            Point zoomCenter = e.GetPosition(element as UIElement);
            Point point = element.RenderTransform.Inverse.Transform(zoomCenter);


            this.translate.X = (zoomCenter.X - point.X) * this.scale.ScaleX;
            this.translate.Y = (zoomCenter.Y - point.Y) * scale.ScaleY;

            this.scale.CenterX = zoomCenter.X;
            this.scale.CenterY = zoomCenter.Y;

            this.scale.ScaleX += e.Delta / 1000.0;
            this.scale.ScaleY += e.Delta / 1000.0;
        }
    }
}
