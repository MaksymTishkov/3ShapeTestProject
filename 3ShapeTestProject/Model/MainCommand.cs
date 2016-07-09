using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace _3ShapeTestProject.Model
{
    //Custom implementation of ICommand interface
    public class MainCommand: ICommand
    {
        private Action<object> _action;
        private Func<object, bool> _canExecute;

        public event EventHandler CanExecuteChanged;

        public MainCommand(Action<object> action, Func<object, bool> canExecute)
        {
            this._action = action;
            this._canExecute = canExecute;
        }

        public bool CanExecute(object o)
        {
            return _canExecute(o);
        }

        public void Execute(object parameter)
        {
            _action(parameter);
        }
    }
}
