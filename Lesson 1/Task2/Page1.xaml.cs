using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace Task2
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        private const string PATH = "D:\\username.txt";

        public Page1()
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
