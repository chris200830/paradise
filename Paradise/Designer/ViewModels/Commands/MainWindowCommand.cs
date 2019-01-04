using System;
using System.Windows.Input;

namespace Designer.ViewModels.Commands
{
    public class MainWindowCommand : ICommand
    {
        private readonly MainWindowViewModel _mainWindowViewModel;
        public event EventHandler CanExecuteChanged;

        public MainWindowCommand(MainWindowViewModel mainWindowViewModel)
        {
            _mainWindowViewModel = mainWindowViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var windowType = (string) parameter;

            switch (windowType)
            {
                case "Rooms":
                    _mainWindowViewModel.CreateRoomWindow();
                    break;
                case "Items":
                    _mainWindowViewModel.CreateItemWindow();
                    break;
                case "Characters":
                    _mainWindowViewModel.CreateCharacterWindow();
                    break;
                default:
                    break;
            }
        }
    }
}