using System.IO;
using System.IO.IsolatedStorage;
using System.Windows;
using System.Windows.Controls;

namespace Task3
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        private const string FILE_NAME = "username.txt";

        public Page1()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var fs = new IsolatedStorageFileStream(FILE_NAME, FileMode.Create);
            var sw = new StreamWriter(fs);
            sw.WriteLine(textBox1.Text);
            sw.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var fs = new IsolatedStorageFileStream(FILE_NAME, FileMode.OpenOrCreate);
            var sr = new StreamReader(fs);
            label1.Content = $"Hello {sr.ReadToEnd()}";
            sr.Close();
        }
    }
}
