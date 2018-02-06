using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MyPractises.Comman
{
    class MyCommand<T>: ICommand
    {
        private Action<T> _execute;

        private Func<T, bool> _canExecute;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            if (null == _canExecute) return true;
            return _canExecute((T)parameter);
        }

        public void Execute(object parameter)
        {
            if (null != _execute && CanExecute((T)parameter))
                _execute((T)parameter);
        }

        public MyCommand(Action<T> execute, Func<T, bool> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public MyCommand(Action<T> execute):this(execute, null)
        { }
    }
}
