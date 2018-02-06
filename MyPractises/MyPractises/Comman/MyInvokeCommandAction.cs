using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interactivity;

namespace MyPractises.Comman
{
    class MyInvokeCommandAction : TriggerAction<DependencyObject>
    {


        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Command.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.Register("Command", typeof(ICommand), typeof(MyInvokeCommandAction), new PropertyMetadata(null));



        public object CommandParmeter
        {
            get { return (object)GetValue(CommandParmeterProperty); }
            set { SetValue(CommandParmeterProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CommandParmeter.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CommandParmeterProperty =
            DependencyProperty.Register("CommandParmeter", typeof(object), typeof(MyInvokeCommandAction), new PropertyMetadata(null));



        protected override void Invoke(object parameter)
        {
            if (null != CommandParmeter)
                parameter = CommandParmeter;
            if (null != Command)
                Command.Execute(parameter);
        }
    }
}
