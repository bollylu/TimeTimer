using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLTools;
using BLTools.MVVM;

namespace TimeTimer {
  public class ControlsVM : MVVMBase {

    public static int MAX_MINUTES => 480;

    public bool btnStartEnabled {
      get {
        return _btnStartEnabled;
      }
      set {
        _btnStartEnabled = value;
        NotifyPropertyChanged(nameof(btnStartEnabled));
      }
    }
    private bool _btnStartEnabled;

    public bool btnStopEnabled {
      get {
        return _btnStopEnabled;
      }
      set {
        _btnStopEnabled = value;
        NotifyPropertyChanged(nameof(btnStopEnabled));
      }
    }
    private bool _btnStopEnabled;

    public bool ChangeDurationEnabled {
      get {
        return _ChangeDurationEnabled;
      }
      set {
        _ChangeDurationEnabled = value;
        NotifyPropertyChanged(nameof(ChangeDurationEnabled));
      }
    }
    private bool _ChangeDurationEnabled;

    public int DurationSliderValue {
      get {
        return _DurationSliderValue;
      }
      set {
        _DurationSliderValue = value;
        NotifyPropertyChanged(nameof(DurationSliderValue));
        _DurationTextValue = value.ToString();
        NotifyPropertyChanged(nameof(DurationTextValue));
      }
    }
    private int _DurationSliderValue;

    public string DurationTextValue {
      get {
        return _DurationTextValue;
      }
      set {
        if ( value.IsNumeric() && !( value.Contains(".") || value.Contains(",") ) ) {
          int NewValue = int.Parse(value);
          if ( NewValue >= 0 && NewValue < MAX_MINUTES ) {
            _DurationTextValue = value;
            NotifyPropertyChanged(nameof(DurationTextValue));
            _DurationSliderValue = int.Parse(value);
            NotifyPropertyChanged(nameof(DurationSliderValue));
          }
        }
      }
    }
    private string _DurationTextValue;

    public bool IsRunning {
      get {
        return _IsRunning;
      }
      protected set {
        _IsRunning = value;
        btnStartEnabled = !_IsRunning;
        btnStopEnabled = _IsRunning;
        ChangeDurationEnabled = !_IsRunning;
        NotifyPropertyChanged(nameof(IsRunning));
      }
    }
    private bool _IsRunning;

    public TRelayCommand StartCommand { get; set; }
    public TRelayCommand StopCommand { get; set; }

    public TRelayCommand<int> SetDurationCommand { get; set; }

    public ControlsVM() : base() {
      StartCommand = new TRelayCommand(() => StartCmd(), _ => !IsRunning);
      StopCommand = new TRelayCommand(() => StopCmd(), _ => IsRunning);
      SetDurationCommand = new TRelayCommand<int>((x) => SetDurationCmd(x), _ => !IsRunning);
      IsRunning = false;
    }

    private void SetDurationCmd(int minutes) {
      DurationSliderValue = minutes;
    }
    
    private void StartCmd() {
      IsRunning = true;
    }

    private void StopCmd() {
      IsRunning = false;
    }

  }
}
