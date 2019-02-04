using System;
using System.Windows;
using System.Windows.Input;

namespace Player.ViewModels.Commands
{
    class MainMenuCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private readonly Action<Window> _action;

        public MainMenuCommand(Action<Window> action)
        {
            _action = action;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var window = (Window)parameter;
            _action(window);
        }
    }
}
