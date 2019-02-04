using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using DTO.Entities;
using Designer.ViewModels.Commands;
using Service.Interfaces;
using Unity;

namespace Designer.ViewModels
{
    public class CharacterWindowViewModel : INotifyPropertyChanged
    {
        private readonly IRepositoryService repositoryService = Initializer.UnityContainer.Resolve<IRepositoryService>();
        public ICommand CharacterWindowButtonClick => characterWindowCommand;
        private ICollection<Character> characterList;

        private Character character;
        private readonly CharacterWindowCommand characterWindowCommand;
        public event PropertyChangedEventHandler PropertyChanged;

        #region Properties

        public ICollection<Character> CharacterCollectionList
        {
            get => characterList;
            set
            {
                characterList = value;
                OnPropertyChanged("CharacterCollectionList");
            }
        }

        public ICollection<Dialogue> DialogueCollectionList { get; set; }

        public Dialogue ComboBoxDialogue { get; set; }

        public Dialogue SelectedDialogue { get; set; }

        public string CharacterNameText
        {
            get => character.Name;
            set
            {
                character.Name = value;
                OnPropertyChanged("CharacterNameText");
            }
        }

        public Character SelectedCharacter
        {
            get => character;
            set
            {
                character = value;
                OnPropertyChanged("SelectedCharacter");
            }
        }

        #endregion

        public CharacterWindowViewModel()
        {
            character = new Character() {CharacterDialogues = new List<Dialogue>()};
            characterWindowCommand = new CharacterWindowCommand(this);
            CharacterCollectionList = repositoryService.FindAllCharacters().ToList();
            DialogueCollectionList = repositoryService.FindAllDialogues();
        }

        public void CreateCharacter()
        {
            character = new Character
            {
                Id = 10,
                Name = "Character #" + (repositoryService.FindAllCharacters().Count() + 1),
            };
            repositoryService.AddCharacter(character);
            repositoryService.Commit();
            CharacterCollectionList = repositoryService.FindAllCharacters().ToList();
        }

        public void SaveCharacter()
        {
            repositoryService.UpdateCharacter(character);
            repositoryService.Commit();
            CharacterCollectionList = repositoryService.FindAllCharacters().ToList();
        }

        public void AddDialogueToCharacter()
        {
            if (ComboBoxDialogue == null)
            {
                return;
            }

            if (character.CharacterDialogues == null)
            {
                character.CharacterDialogues = new List<Dialogue>();
            }

            character.CharacterDialogues.Add(ComboBoxDialogue);
            repositoryService.UpdateCharacter(character);
            repositoryService.Commit();
        }

        public void RemoveDialogueFromCharacter()
        {
            if (character.CharacterDialogues == null)
            {
                return;
            }

            character.CharacterDialogues.Remove(SelectedDialogue);
            SelectedDialogue.DialogueCharacter = repositoryService.FindCharacter(69);
            repositoryService.UpdateCharacter(character);
            repositoryService.UpdateDialogue(SelectedDialogue);
            repositoryService.Commit();
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
