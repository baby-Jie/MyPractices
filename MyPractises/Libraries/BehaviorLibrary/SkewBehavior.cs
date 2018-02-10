using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interactivity;
using System.Windows.Media;

namespace BehaviorLibrary
{
    public class SkewBehavior:Behavior<UIElement>
    {

        SkewTransform _transForm;

        //通过重载OnAttached函数进行Behavior附加上时的初始化操作
        protected override void OnAttached()
        {
            base.OnAttached();
            _transForm = new SkewTransform();

            AssociatedObject.RenderTransform = _transForm;//通过AssociatedObject属性获取附加的对象。
            AssociatedObject.RenderTransformOrigin = new Point(0.5, 0.5);
            _transForm.AngleX = 30;
            
        }

        //通过重载OnDetaching函数进行移除Behavior时候的析构操作
        protected override void OnDetaching()
        {
            _transForm.AngleX = 0;
            base.OnDetaching();
        }
    }
}
