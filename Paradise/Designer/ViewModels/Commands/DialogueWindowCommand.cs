using System;
using System.Windows.Input;

namespace Designer.ViewModels.Commands
{
    public class DialogueWindowCommand : ICommand
    {
        private readonly DialogueWindowViewModel dialogueWindowViewModel;
        public event EventHandler CanExecuteChanged;

        public DialogueWindowCommand(DialogueWindowViewModel dialogueWindowViewModel)
        {
            this.dialogueWindowViewModel = dialogueWindowViewModel;
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
                    dialogueWindowViewModel.CreateDialogue();
                    break;
                case "Save":
                    dialogueWindowViewModel.SaveDialogue();
                    break;
                case "AddReplyToList":
                    dialogueWindowViewModel.AddReplyToList();
                    break;
                case "RemoveReplyFromList":
                    dialogueWindowViewModel.RemoveReplyFromList();
                    break;
                default:
                    break;
            }
        }
    }
}
