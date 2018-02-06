using MyPractises.Comman;
using MyPractises.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MyPractises.ViewModel
{
    class EventBindCommandViewModel:NotifyBase
    {

        private MyCommand<object> loadCommand;

        public MyCommand<object> LoadCommand
        {
            get
            {
                if (null == loadCommand)
                    loadCommand = new MyCommand<object>(WinLoad);
                return loadCommand;
            }
        }

        private MyCommand<MouseEventArgs> mouseMoveCommand;

        public MyCommand<MouseEventArgs> MouseMoveCommand
        {
            get
            {
                if (null == mouseMoveCommand)
                    mouseMoveCommand = new MyCommand<MouseEventArgs>(MouseMoveEventHandler, new Func<object, bool>(o => AllowMouseMove));
                return mouseMoveCommand;
            }
        }


        private string tips;
        public string Tips
        {
            get { return tips; }
            set
            {
                tips = value;
                this.RaisePropertyChanged("Tips");
            }
        }


        private bool allowMouseMove;
        public bool AllowMouseMove
        {
            get { return allowMouseMove; }
            set
            {
                allowMouseMove = value;
                this.RaisePropertyChanged("AllowMouseMove");
            }
        }


        void MouseMoveEventHandler(MouseEventArgs e)
        {
            Point p = e.GetPosition(e.Device.Target);
            string left = "左键未按下";
            string middle = "中键未按下";
            string right = "右键未按下";

            if (e.LeftButton == MouseButtonState.Pressed)
                left = "左键按下";
            if (e.MiddleButton == MouseButtonState.Pressed)
                middle = "中键按下";
            if (e.RightButton == MouseButtonState.Pressed)
                right = "右键按下";

            Tips = $"point: X:{p.X} Y:{p.Y} left:{left} middle:{middle} right:{right}";
        }

        void WinLoad(object obj)
        {
            MessageBox.Show("Window loaded");
        }

    }
}
