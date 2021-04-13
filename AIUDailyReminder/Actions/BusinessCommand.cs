using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AIUDailyReminder.Actions
{
    class BusinessCommand : ICommand
    {
        private Func<bool> func;
        private Action<object> act;

        public BusinessCommand(Func<bool> f, Action<object> a)
        {
            func = f;
            act = a;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            act(parameter);
        }
    }
}
