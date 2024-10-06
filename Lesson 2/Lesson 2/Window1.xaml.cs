using System;
using System.Windows;
using System.Windows.Forms;

namespace Lesson_2
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        OpenFileDialog aDialog = new OpenFileDialog();
        public Window1()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            aDialog.ShowDialog();
            MediaElement1.Source = new Uri(aDialog.FileName);
            MediaElement1.Play();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MediaElement1.Play();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MediaElement1.Pause();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            MediaElement1.Stop();
        }

        private void MediaElement1_MediaFailed(object sender, ExceptionRoutedEventArgs e)
        {
            System.Windows.MessageBox.Show($"Media loading unsuccessful. {e.ErrorException.Message}");
        }
    }
}
