using System;
using System.Windows.Input;

namespace Designer.ViewModels.Commands
{
    public class CharacterWindowCommand : ICommand
    {
        private readonly CharacterWindowViewModel characterWindowViewModel;
        public event EventHandler CanExecuteChanged;

        public CharacterWindowCommand(CharacterWindowViewModel characterWindowViewModel)
        {
            this.characterWindowViewModel = characterWindowViewModel;
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
                    characterWindowViewModel.CreateCharacter();
                    break;
                case "Save":
                    characterWindowViewModel.SaveCharacter();
                    break;
                case "AddDialogueToCharacter":
                    characterWindowViewModel.AddDialogueToCharacter();
                    break;
                case "RemoveDialogueFromCharacter":
                    characterWindowViewModel.RemoveDialogueFromCharacter();
                    break;
                default:
                    break;
            }
        }
    }
}
