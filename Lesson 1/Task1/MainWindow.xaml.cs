using System.IO;
using System.Windows;

namespace Task1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string PATH = "D:\\username.txt";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var sw = new StreamWriter(PATH);
            sw.WriteLine(textBox1.Text);
            sw.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var sr = new StreamReader(PATH);
            label1.Content = $"Hello {sr.ReadToEnd()}";
            sr.Close();
        }
    }
}
