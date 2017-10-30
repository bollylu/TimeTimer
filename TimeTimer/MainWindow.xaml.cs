using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BLTools.WPF;

namespace TimeTimer {
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window {

    #region Private variables
    //private bool IsCompletedSuccessfully;

    public MainViewModel MainWindowViewModel { get; set; }

    #endregion Private variables

    #region Constructor(s)
    public MainWindow() {
      InitializeComponent();
    }

    private void Window_Initialized(object sender, EventArgs e) {
      MainWindowViewModel = new MainViewModel();
      this.DataContext = MainWindowViewModel;
    }

    private void Window_Loaded(object sender, RoutedEventArgs e) {
      //IsCompletedSuccessfully = false;
    } 
    #endregion Constructor(s)

   

   

    
  }
}
