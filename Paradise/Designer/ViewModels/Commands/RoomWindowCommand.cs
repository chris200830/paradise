using System;
using System.Windows.Input;

namespace Designer.ViewModels.Commands
{
    public class RoomWindowCommand : ICommand
    {
        private readonly RoomWindowViewModel _roomWindowViewModel;

        public event EventHandler CanExecuteChanged;

        public RoomWindowCommand(RoomWindowViewModel roomWindowViewModel)
        {
            _roomWindowViewModel = roomWindowViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var type = (string) parameter;
            switch (type)
            {
                case "Create":
                    _roomWindowViewModel.CreateNewRoom();
                    break;
                case "Save":
                    _roomWindowViewModel.SaveRoom();
                    break;
                default:
                    break;
            }
        }
    }
}
