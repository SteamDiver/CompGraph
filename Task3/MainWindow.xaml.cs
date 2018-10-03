using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Task3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private PointCollection Points { get; set; } = new PointCollection();
        private PointCollection NewPoints { get; set; } = new PointCollection();

        private Path path;
        private bool newLine = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
                newLine = !newLine;
                DrawLine(Points);
            
        }

        private void Canvas_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (Points.Count - NewPoints.Count == 0 && Points.Count != 0)
                return;

            if (newLine)
            {
                NewPoints.Add(e.GetPosition(Canvas));

                if (Points.Count - NewPoints.Count == 0)
                    DoneBtn.IsEnabled = true;

                CounterLbl.Content = Points.Count - NewPoints.Count;
            }
            else
            {
                Points.Add(e.GetPosition(Canvas));
                CounterLbl.Content = Points.Count;
            }

            var thickness = newLine
                ? new Thickness(NewPoints.Last().X, NewPoints.Last().Y, 0, 0)
                : new Thickness(Points.Last().X, Points.Last().Y, 0, 0);
            var visiblePoint = new Ellipse()
            {
                Width = 4, 
                Height = 4,
                Margin = thickness,
                Fill = newLine ? Brushes.Red : Brushes.Blue
            };
            Canvas.Children.Add(visiblePoint);
        }

        private void DrawLine(PointCollection points)
        {
            var line = new PolyBezierSegment()
            {
                Points = points,
                IsSmoothJoin = true
            };

            var pathFigure = new PathFigure()
            {
                Segments = new PathSegmentCollection() { line },
                StartPoint = points[0]
            };

            var gObj = new PathGeometry(new List<PathFigure>() { pathFigure });
            path = new Path()
            {
                Data = gObj,
                Stroke = Brushes.Blue,
                StrokeThickness = 4
            };
            Canvas.Children.Add(path);
        }

        private void ClearBtn_Click(object sender, RoutedEventArgs e)
        {
            Canvas.Children.Clear();
            Points.Clear();
            NewPoints.Clear();
            newLine = false;
            DoneBtn.IsEnabled = false;
        }

        private void DoneBtn_Click(object sender, RoutedEventArgs e)
        {
            MoveLine();
        }

        private void ClearCanvas()
        {
            Canvas.Children.Clear();
        }

        private void MoveLine()
        {
            if (Points.Count == NewPoints.Count)
            {
                var delta = 0.1;

                Timer T = new Timer(1);
                T.Elapsed += (sender, args) =>
                {
                    Dispatcher.Invoke(new Action(() =>
                    {
                        for (int i = 0; i < Points.Count; i++)
                        {
                            var point = Points[i];
                            point.X += (NewPoints[i].X - Points[i].X) * delta;
                            point.Y += (NewPoints[i].Y - Points[i].Y) * delta;
                           
                            Points[i] = point;
                        }
                        ClearCanvas();
                        DrawLine(Points);

                        if (Math.Abs(NewPoints[0].X - Points[0].X) < delta)
                            T.Stop();
                    }));
                };
                T.Start();
            }
        }
    }
}
