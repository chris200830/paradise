using System;
using System.Windows.Input;

namespace Designer.ViewModels.Commands
{
    public class InteractiveObjectWindowCommand : ICommand
    {
        private readonly InteractiveObjectWindowViewModel interactiveObjectWindowViewModel;
        public event EventHandler CanExecuteChanged;

        public InteractiveObjectWindowCommand(InteractiveObjectWindowViewModel interactiveObjectWindowViewModel)
        {
            this.interactiveObjectWindowViewModel = interactiveObjectWindowViewModel;
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
                case "CreateObject":
                    interactiveObjectWindowViewModel.CreateObject();
                    break;
                case "SaveObject":
                    interactiveObjectWindowViewModel.SaveObject();
                    break;
                default:
                    break;
            }
        }
    }
}
