using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using BLTools;
using BLTools.Debugging;

namespace TimeTimer {
  /// <summary>
  /// Interaction logic for App.xaml
  /// </summary>
  public partial class App : Application {
    private void Application_Startup(object sender, StartupEventArgs e) {
      TraceFactory.AddTraceDefaultLogFilename();
      ApplicationInfo.ApplicationStart();
    }

    private void Application_Exit(object sender, ExitEventArgs e) {
      ApplicationInfo.ApplicationStop();
    }
  }
}
