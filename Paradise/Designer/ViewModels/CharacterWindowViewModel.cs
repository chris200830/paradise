using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using DTO.Entities;
using Service.Implementations;
using Designer.ViewModels.Commands;

namespace Designer.ViewModels
{
    public class CharacterWindowViewModel : INotifyPropertyChanged
    {
        private Character character;
        private ICollection<Character> characterList;

        private readonly CharacterWindowCommand characterWindowCommand;
        public ICommand CharacterWindowButtonClick => characterWindowCommand;

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
            characterWindowCommand = new CharacterWindowCommand(this);
        }

        public void CreateCharacter()
        {
            var characterService = new CharacterService();
            var roomService = new RoomService();
            character = new Character
            {
                Name = "Character #" + (characterService.GetCharacters().Count() + 1),
                InteractableObjectRoom = roomService.GetRooms().ElementAt(0),
                InteractableObjectRoomId = roomService.GetRooms().ElementAt(0).RoomId
            };
            characterService.AddCharacter(character);
            CharacterCollectionList = characterService.GetCharacters().ToList();
            characterService.Dispose();
        }

        public void SaveCharacter()
        {
            var characterService = new CharacterService();
            characterService.UpdateCharacter(character);
            CharacterCollectionList = characterService.GetCharacters().ToList();
            characterService.Dispose();
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
