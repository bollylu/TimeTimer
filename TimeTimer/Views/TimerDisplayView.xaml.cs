using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TimeTimer {
  /// <summary>
  /// Interaction logic for TimerDisplayView.xaml
  /// </summary>
  public partial class TimerDisplayView : UserControl {


    public TimerDisplayView() {
      InitializeComponent();
    }

    private void UserControl_Initialized(object sender, EventArgs e) {
      DrawBigMinutes();
      DrawMinutes();
    }

    private void DrawBigMinutes() {
      Point EllipseCenter = new Point(this.ActualWidth / 2, this.ActualHeight / 2);

      for ( int i = 12; i >= 1; i-- ) {
        double Angle = -i * 30 - 90;

        Point TickPoint = GetPointOnEllipse(EllipseCenter, TimerDrawing.Width / 2 - 10, Angle);
        Point EndPoint = GetPointOnEllipse(EllipseCenter, TimerDrawing.Width / 2 + 10, Angle);
        Point TextPoint = GetPointOnEllipse(EllipseCenter, TimerDrawing.Width / 2 + 25, Angle);
        Line NewLine = new Line();
        NewLine.X1 = TickPoint.X;
        NewLine.Y1 = TickPoint.Y;
        NewLine.X2 = EndPoint.X;
        NewLine.Y2 = EndPoint.Y;
        NewLine.StrokeThickness = 2;
        NewLine.Stroke = Brushes.Blue;
        Dessin.Children.Add(NewLine);
        TextBlock NewTextBlock = new TextBlock();
        NewTextBlock.Text = ( i * 5 ).ToString();
        Dessin.Children.Add(NewTextBlock);
        Canvas.SetLeft(NewTextBlock, TextPoint.X - 5);
        Canvas.SetTop(NewTextBlock, TextPoint.Y - 10);
      }
    }
    private void DrawMinutes() {
      Point EllipseCenter = new Point(this.ActualWidth / 2, this.ActualHeight / 2);
      List<int> SkippedMinutes = new List<int>() { 5, 10, 15, 20, 25, 30, 35, 40, 45, 50, 55, 60 };
      for ( int i = 60; i >= 1; i-- ) {
        if ( !SkippedMinutes.Contains(i) ) {
          double Angle = -i * 6 - 90;
          Point TickPoint = GetPointOnEllipse(EllipseCenter, TimerDrawing.Width / 2 - 10, Angle);
          Point EndPoint = GetPointOnEllipse(EllipseCenter, TimerDrawing.Width / 2, Angle);
          Point TextPoint = GetPointOnEllipse(EllipseCenter, TimerDrawing.Width / 2 + 15, Angle);
          Line NewLine = new Line();
          NewLine.X1 = TickPoint.X;
          NewLine.Y1 = TickPoint.Y;
          NewLine.X2 = EndPoint.X;
          NewLine.Y2 = EndPoint.Y;
          NewLine.StrokeThickness = 1;
          NewLine.Stroke = Brushes.IndianRed;
          Dessin.Children.Add(NewLine);
          TextBlock NewTextBlock = new TextBlock();
          NewTextBlock.Text = i.ToString();
          NewTextBlock.FontSize = 8;
          Dessin.Children.Add(NewTextBlock);
          Canvas.SetLeft(NewTextBlock, TextPoint.X - 5);
          Canvas.SetTop(NewTextBlock, TextPoint.Y - 5);
        }
      }
    }

    private Point GetPointOnEllipse(Point center, double radius, double angle) {
      double AngleAsRadians = Math.PI * angle / 180;
      Point RetVal = new Point(center.X + radius * Math.Cos(AngleAsRadians), center.Y + radius * Math.Sin(AngleAsRadians));
      return RetVal;
    }

    private void DrawTimer(int minutes, int secondes = 0) {
      Point EllipseCenter = new Point(this.ActualWidth / 2, this.ActualHeight / 2);

      switch ( minutes ) {

        case 0:
          RedZone.Data = null;
          break;

        case 60:
          EllipseGeometry NewEllipseGeometry = new EllipseGeometry(EllipseCenter, 200, 200);
          RedZone.Data = NewEllipseGeometry;
          break;

        default:
          PathGeometry NewPathGeometry = new PathGeometry();

          PathFigure PiePart = new PathFigure();
          PiePart.IsClosed = true;
          PiePart.StartPoint = EllipseCenter;

          PiePart.Segments.Add(new LineSegment(new Point(250, 50), true));

          Point EndPoint = GetPointOnEllipse(EllipseCenter, TimerDrawing.Width / 2, ( ( ( minutes * 6 ) + ( secondes * 0.1 ) ) * -1 ) - 90);
          PiePart.Segments.Add(new ArcSegment(EndPoint, new Size(200, 200), 0, minutes >= 30, SweepDirection.Counterclockwise, true));

          NewPathGeometry.Figures.Add(PiePart);
          RedZone.Data = NewPathGeometry;
          break;
      }

    }

  }
}
