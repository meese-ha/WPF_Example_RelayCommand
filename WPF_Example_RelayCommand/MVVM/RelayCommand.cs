using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPF_Example_RelayCommand.MVVM
{
    internal class RelayCommand : ICommand
    {
        private Action<object> execute;
        private Func<object, bool> canexecute;

        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }

        }

        public RelayCommand(Action<object> execute, Func<object, bool> canexecute)
        {
            this.execute = execute;
            this.canexecute = canexecute;
        }

        public bool CanExecute(object? parameter)
        {
            return canexecute == null || canexecute(parameter);
        }

        public void Execute(object? parameter)
        {
            execute(parameter);
        }
    }
}
