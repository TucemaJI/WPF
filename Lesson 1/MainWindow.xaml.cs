using System.Windows;
using System.Windows.Controls;

namespace Lesson_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string TEXT = "Event raised by ";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            MessageBox.Show(TEXT + sender.ToString());
            e.Handled = (bool)radioButton1.IsChecked;
        }

        private void Grid_TextChanged(object sender, TextChangedEventArgs e)
        {
            MessageBox.Show(TEXT + sender.ToString());
            e.Handled = (bool)radioButton2.IsChecked;
        }

        private void Window_TextChanged(object sender, TextChangedEventArgs e)
        {
            MessageBox.Show(TEXT + sender.ToString());
            e.Handled = (bool)radioButton3.IsChecked;
        }
    }
}
