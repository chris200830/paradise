using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using Designer.ViewModels.Commands;
using DTO.Entities;
using Service.Implementations;

namespace Designer.ViewModels
{
    public class DialogueWindowViewModel : INotifyPropertyChanged
    {
        private Dialogue dialogue;
        private DialogueOption dialogueOption;
        private ICollection<Dialogue> dialogueList;
        private ICollection<DialogueOption> dialogueOptionList;

        private readonly DialogueWindowCommand dialogueWindowCommand;
        public ICommand DialogueWindowButtonClick => dialogueWindowCommand;

        public event PropertyChangedEventHandler PropertyChanged;

        #region Properties

        public ICollection<Dialogue> DialogueCollectionList
        {
            get => dialogueList;
            set
            {
                dialogueList = value;
                OnPropertyChanged("DialogueCollectionList");
            }
        }

        public ICollection<DialogueOption> DialogueOptionCollectionList
        {
            get => dialogueOptionList;
            set
            {
                dialogueOptionList = value;
                OnPropertyChanged("DialogueOptionCollectionList");
            }
        }

        public string DialogueText
        {
            get => dialogue.DialogueText;
            set
            {
                dialogue.DialogueText = value;
                OnPropertyChanged("DialogueText");
            }
        }

        public Dialogue SelectedDialogue
        {
            get => dialogue;
            set
            {
                dialogue = value;
                DialogueOptions = dialogue.DialogueOptions;
                OnPropertyChanged("SelectedDialogue");
            }
        }

        public DialogueOption SelectedDialogueOption
        {
            get => dialogueOption;
            set
            {
                dialogueOption = value;
                OnPropertyChanged("SelectedDialogueOption");
            }
        }

        public ICollection<DialogueOption> DialogueOptions {
            get => dialogue.DialogueOptions;
            set
            {
                dialogue.DialogueOptions = value;
                OnPropertyChanged("DialogueOptions");
            }
        }

        public Character DialogueCharacter
        {
            get => dialogue.DialogueCharacter;
            set
            {
                dialogue.DialogueCharacter = value;
                OnPropertyChanged("DialogueCharacter");
            }
        }

        #endregion

        public DialogueWindowViewModel()
        {
            dialogueWindowCommand = new DialogueWindowCommand(this);
            dialogue = new Dialogue() { DialogueOptions = new List<DialogueOption>() };

            var dialogueService = new DialogueService();
            DialogueCollectionList = dialogueService.GetDialogues().ToList();
        }

        public void CreateDialogue()
        {
            var dialogueService = new DialogueService();
            var characterService = new CharacterService();
            dialogue = new Dialogue
            {
               DialogueOptions = new List<DialogueOption>(),
               DialogueCharacter = characterService.GetCharacters().FirstOrDefault()
            };
            dialogueService.AddDialogue(dialogue);
            DialogueCollectionList = dialogueService.GetDialogues().ToList();
            dialogueService.Dispose();
        }

        public void SaveDialogue()
        {
            var dialogueService = new DialogueService();
            dialogueService.UpdateDialogue(dialogue);
            DialogueCollectionList = dialogueService.GetDialogues().ToList();
            dialogueService.Dispose();
        }

        public void CreateDialogueOption()
        {
            var dialogueOptionService = new DialogueOptionService();
            dialogueOption = new DialogueOption()
            {
                Dialogue = SelectedDialogue
            };
            dialogueOptionService.AddDialogueOption(dialogueOption);

            if (dialogue.DialogueOptions == null)
            {
                dialogue.DialogueOptions = new List<DialogueOption>();
            }

            dialogue.DialogueOptions.Add(dialogueOption);
            var dialogueService = new DialogueService();
            dialogueService.UpdateDialogue(dialogue);
            var d = dialogueService.GetDialogues().ToList();
            DialogueOptionCollectionList = dialogue.DialogueOptions;

            dialogueOptionService.Dispose();
            dialogueService.Dispose();
        }

        public void SaveDialogueOption()
        {
            var dialogueOptionService = new DialogueOptionService();
            dialogueOptionService.UpdateDialogueOption(dialogueOption);

            DialogueOptionCollectionList = dialogue.DialogueOptions;
            dialogueOptionService.Dispose();
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
