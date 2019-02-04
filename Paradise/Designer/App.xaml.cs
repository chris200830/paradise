using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Practices.Unity.Configuration;
using Unity;

namespace Designer
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
