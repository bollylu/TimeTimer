using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLTools.MVVM;

namespace TimeTimer {
  public class MainViewModel : MVVMBase {

    public ControlsVM CurrentControlsVM { get; set; }
    public TimerDisplayVM CurrentTimerDisplayVM { get; set; }

    public MainViewModel() {
      CurrentControlsVM = new ControlsVM();
      CurrentTimerDisplayVM = new TimerDisplayVM();
    }
  }
}
