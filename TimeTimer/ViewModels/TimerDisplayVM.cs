using BLTools.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace TimeTimer {
  public class TimerDisplayVM : MVVMBase {

    private Timer RunningTimer;
    private DateTime StartTime;
    public int MinutesLeft {
      get {
        return _MinutesLeft;
      }
      set {
        _MinutesLeft = value;
        NotifyPropertyChanged(nameof(MinutesLeft));
      }
    }
    private int _MinutesLeft;

    public TimerDisplayVM() {
    }

    public void Start() {
      RunningTimer = new Timer(1000);
      RunningTimer.Elapsed += RunningTimer_Elapsed;
      StartTime = DateTime.Now;
      RunningTimer.Enabled = true;
    }

    public void Stop() {
      RunningTimer.Enabled = false;
      RunningTimer.Elapsed -= RunningTimer_Elapsed;
      RunningTimer.Dispose();
    }

    private void RunningTimer_Elapsed(object sender, ElapsedEventArgs e) {
      int AlreadyConsumed = (DateTime.Now - StartTime).Minutes;

      if ( MinutesLeft <= AlreadyConsumed ) {
        Stop();
      }
      
    }
  }
}
