using System.Windows.Input;
using Designer.ViewModels.Commands;
using Designer.Views;

namespace Designer.ViewModels
{
    public class MainWindowViewModel
    {
        private readonly MainWindowCommand _mainWindowCommand;
        public ICommand MainWindowButtonClick => _mainWindowCommand;

        public MainWindowViewModel()
        {
            _mainWindowCommand = new MainWindowCommand(this);
        }

        public void CreateRoomWindow()
        {
            var roomWindow = new RoomWindow();
            roomWindow.Show();
        }

        public void CreateItemWindow()
        {
            var itemWindow = new ItemWindow();
            itemWindow.Show();
        }

        public void CreateCharacterWindow()
        {
            var characterWindow = new CharacterWindow();
            characterWindow.Show();
        }

        public void CreateDialogueWindow()
        {
            var dialogueWindow = new DialogueWindow();
            dialogueWindow.Show();
        }
    }
}
