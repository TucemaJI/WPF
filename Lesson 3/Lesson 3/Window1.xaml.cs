using Lesson_3.Properties;
using System;
using System.IO;
using System.Windows;
using System.Windows.Resources;

namespace Lesson_3
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
            StreamResourceInfo info = Application.GetResourceStream(new Uri(Settings.Default.TextName, UriKind.Relative));
            var aReader = new StreamReader(info.Stream);
            label1.Content = aReader.ReadToEnd();
            aReader.Close();
        }
    }
}
