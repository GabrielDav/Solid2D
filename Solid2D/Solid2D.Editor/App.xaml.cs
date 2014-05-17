using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

using Solid2D.Editor.Properties;

namespace Solid2D.Editor
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void App_OnExit(object sender, ExitEventArgs e)
        {
            Settings.Default.Save();
        }

        private void App_OnStartup(object sender, StartupEventArgs e)
        {
           
        }
    }
}
