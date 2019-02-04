using System.Windows;
using System.Windows.Input;
using Player.ViewModels.Commands;
using Player.Views;

namespace Player.ViewModels
{
    class MainMenuViewModel
    {
        private MainMenuCommand _mainMenuCommand;
        public ICommand MainMenuCommand => _mainMenuCommand;

        public MainMenuViewModel()
        {
            _mainMenuCommand = new MainMenuCommand(StartNewGame);
        }

        public void StartNewGame(Window mainMenuWindow)
        {
            var storyWindow = new StoryWindow();
            storyWindow.Show();

            StoryViewModel.Instance.AddTextToStory("You are a dirt bag programmer who sits around and does nothing all day.");
            mainMenuWindow.Close();
        }
    }
}
