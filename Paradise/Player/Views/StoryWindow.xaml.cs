using System.Windows;

namespace Player.Views
{
    /// <summary>
    /// Interaction logic for StoryBoardWindow.xaml
    /// </summary>
    public partial class StoryWindow : Window
    {
        public StoryWindow()
        {
            InitializeComponent();
            WindowState = WindowState.Maximized;
            WindowStyle = WindowStyle.SingleBorderWindow;
        }
    }
}
