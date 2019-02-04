using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using Designer.ViewModels.Commands;
using DTO.Entities;
using Service.Interfaces;
using Unity;

namespace Designer.ViewModels
{
    public class DialogueWindowViewModel : INotifyPropertyChanged
    {
        private readonly IRepositoryService repositoryService = Initializer.UnityContainer.Resolve<IRepositoryService>();
        private Dialogue dialogue;
        private Dialogue selectedReply;
        private ICollection<Dialogue> dialogueList;

        private Character selectedCharacter;
        private ICollection<Character> characterList;

        private readonly DialogueWindowCommand dialogueWindowCommand;
        public ICommand DialogueWindowButtonClick => dialogueWindowCommand;

        public event PropertyChangedEventHandler PropertyChanged;

        #region Properties

        public ICollection<Dialogue> DialogueReplyList { get; set; }

        public Dialogue ComboBoxDialogue { get; set; }

        public Dialogue SelectedReply { get; set; }

        public ICollection<Dialogue> DialogueCollectionList
        {
            get => dialogueList;
            set
            {
                dialogueList = value;
                OnPropertyChanged("DialogueCollectionList");
            }
        }

        public ICollection<Character> CharacterList => repositoryService.FindAllCharacters();

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
                OnPropertyChanged("SelectedDialogue");
            }
        }

        public Character SelectedCharacter
        {
            get => selectedCharacter;
            set
            {
                selectedCharacter = value;
                OnPropertyChanged("SelectedCharacter");
            }
        }

        public Dialogue NextDialogueViewModel
        {
            get => dialogue.NextDialogue;
            set
            {
                dialogue.NextDialogue = value;
                dialogue.NextDialogueId = value.Id;
                OnPropertyChanged("NextDialogueViewModel");
            }
        }

        #endregion

        public DialogueWindowViewModel()
        {
            dialogue = new Dialogue() {DialogueReplies = new List<Dialogue>()};
            dialogueWindowCommand = new DialogueWindowCommand(this);
            DialogueCollectionList = repositoryService.FindAllDialogues().ToList();
        }

        public void CreateDialogue()
        {
            dialogue = new Dialogue()
            {
                NextDialogueId = 69,
                DialogueCharacterId = 69,
                DialogueReplyId = 69,
                DialogueReplies = new List<Dialogue>()
            };
            repositoryService.AddDialogue(dialogue);
            repositoryService.Commit();
            DialogueCollectionList = repositoryService.FindAllDialogues().ToList();
        }

        public void SaveDialogue()
        {
            repositoryService.UpdateDialogue(dialogue);
            repositoryService.Commit();
            DialogueCollectionList = repositoryService.FindAllDialogues().ToList();
        }

        public void AddReplyToList()
        {
            if (ComboBoxDialogue == null)
            {
                return;
            }

            if (dialogue.DialogueReplies == null)
            {
                dialogue.DialogueReplies = new List<Dialogue>();
            }

            dialogue.DialogueReplies.Add(ComboBoxDialogue);
            repositoryService.UpdateDialogue(dialogue);
            repositoryService.Commit();
        }

        public void RemoveReplyFromList()
        {
            if (dialogue.DialogueReplies == null || SelectedReply == null)
            {
                return;
            }

            dialogue.DialogueReplies.Remove(SelectedReply);
            SelectedReply.DialogueReply = repositoryService.FindDialogue(69);
            repositoryService.UpdateDialogue(dialogue);
            repositoryService.UpdateDialogue(SelectedReply);
            repositoryService.Commit();
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
