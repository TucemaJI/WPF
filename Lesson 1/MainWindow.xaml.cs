using Lesson_1.Properties;
using System.IO;
using System.Windows;

namespace Lesson_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<string> phoneNumbers = [];
        private SaveFileDialog aDialog;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            MaskedTextBox aBox = (MaskedTextBox)windowsFormsHost1.Child;
            phoneNumbers.Add(aBox.Text);
            aBox.Clear();
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            aDialog = new() { Filter = Settings.Default.FileFilter };
            aDialog.ShowDialog();
            StreamWriter myWriter = new(aDialog.FileName, true);

            foreach (string phoneNumber in phoneNumbers) { myWriter.WriteLine(phoneNumber); }

            myWriter.Close();
        }
    }
}