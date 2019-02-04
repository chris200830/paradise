using System.ComponentModel;

namespace Player.ViewModels
{
    class StoryViewModel
    {
        public static StoryViewModel Instance { get; } = new StoryViewModel();

        private string story = "";

        public event PropertyChangedEventHandler PropertyChanged;

        public string TxtStory
        {
            get => story;
            set
            {
                story = value;
                OnPropertyChanged("TxtStory");
            }
        }

        public StoryViewModel()
        {

        }

        public void AddTextToStory(string text)
        {
            TxtStory += text;
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
