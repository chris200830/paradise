using Microsoft.Practices.Unity.Configuration;
using System.Windows;
using Unity;

namespace Player
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            var unityContainer = new UnityContainer();
            unityContainer.LoadConfiguration();
            Initializer.Initialize(unityContainer);
        }
    }
}
