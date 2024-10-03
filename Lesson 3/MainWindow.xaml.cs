using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Lesson_3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Title = Properties.Settings.Default.ApplicationName;
            Background = new SolidColorBrush(Properties.Settings.Default.BackgroundColor);
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            var aString = (listBox1.SelectedItem as ListBoxItem)?.Content.ToString();

            switch (aString)
            {
                case "Red":
                    Properties.Settings.Default.BackgroundColor = Colors.Red;
                    break;
                case "Blue":
                    Properties.Settings.Default.BackgroundColor = Colors.Blue;
                    break;
                case "Green":
                    Properties.Settings.Default.BackgroundColor = Colors.Green;
                    break;
                case "Tomato":
                    Properties.Settings.Default.BackgroundColor = Colors.Tomato;
                    break;
                default:
                    Properties.Settings.Default.BackgroundColor = Colors.White;
                    break;
            };

            Background = new SolidColorBrush(Properties.Settings.Default.BackgroundColor);
            Properties.Settings.Default.Save();
        }
    }
}
