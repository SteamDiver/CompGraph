using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Task1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Draw();
        }

        private void Draw()
        {
            Canvas.Background = Brushes.Aquamarine;
            var ellipse = new Ellipse()
            {
                Height = 100,
                Width = 100,
                Fill = Brushes.Yellow,
                Margin = new Thickness(10, 10, 0, 0)
            };

            var text = new TextBlock()
            {
                Text = "Hello world!",
                Margin = new Thickness(500, 100, 0, 0),
                FontSize = 32,
                FontWeight = FontWeights.DemiBold
            };

            var myPath = new Path
            {
                Stroke = Brushes.GreenYellow,
                StrokeThickness = 4,
                Data = Geometry.Parse(
                    $"M 0,{(int) Canvas.ActualHeight} C 0,{(int) Canvas.ActualHeight} {(int) Canvas.ActualWidth / 2},170, {(int) Canvas.ActualWidth},170")
            };
            Canvas.Children.Add(ellipse);
            Canvas.Children.Add(text);
            Canvas.Children.Add(myPath);
        }
    }
}
