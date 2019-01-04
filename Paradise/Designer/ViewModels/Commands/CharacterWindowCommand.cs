using System;
using System.Windows.Input;

namespace Designer.ViewModels.Commands
{
    public class CharacterWindowCommand : ICommand
    {
        private readonly CharacterWindowViewModel _characterWindowViewModel;
        public event EventHandler CanExecuteChanged;

        public CharacterWindowCommand(CharacterWindowViewModel characterWindowViewModel)
        {
            _characterWindowViewModel = characterWindowViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var type = (string)parameter;
            switch (type)
            {
                case "Create":
                    _characterWindowViewModel.CreateCharacter();
                    break;
                case "Save":
                    _characterWindowViewModel.SaveCharacter();
                    break;
                default:
                    break;
            }
        }
    }
}
