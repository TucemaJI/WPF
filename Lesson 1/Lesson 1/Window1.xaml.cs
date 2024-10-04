using Lesson_1.Properties;
using System.IO;
using System.Windows;

namespace Lesson_1
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            var sw = new StreamWriter(Settings.Default.Path);
            sw.WriteLine(textBox1.Text);
            sw.Close();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            var sr = new StreamReader(Settings.Default.Path);
            label1.Content = $"Hello {sr.ReadToEnd()}";
            sr.Close();
        }
    }
}

