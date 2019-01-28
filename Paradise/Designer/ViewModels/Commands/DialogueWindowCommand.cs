using System;
using System.Windows.Input;

namespace Designer.ViewModels.Commands
{
    public class DialogueWindowCommand : ICommand
    {
        private readonly DialogueWindowViewModel _dialogueWindowViewModel;
        public event EventHandler CanExecuteChanged;

        public DialogueWindowCommand(DialogueWindowViewModel dialogueWindowViewModel)
        {
            _dialogueWindowViewModel = dialogueWindowViewModel;
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
                    _dialogueWindowViewModel.CreateDialogue();
                    break;
                case "Save":
                    _dialogueWindowViewModel.SaveDialogue();
                    break;
                case "CreateDialogueOption":
                    _dialogueWindowViewModel.CreateDialogueOption();
                    break;
                case "SaveDialogueOption":
                    _dialogueWindowViewModel.SaveDialogueOption();
                    break;
                default:
                    break;
            }
        }
    }
}
