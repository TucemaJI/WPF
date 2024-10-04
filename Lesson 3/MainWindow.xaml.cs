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
            foreach (FontFamily f in Fonts.SystemFontFamilies)
            {
                listBox1.Items.Add(new ListBoxItem() { Content = f.ToString(), FontFamily = f });
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            richTextBox1.Selection.ApplyPropertyValue(FontWeightProperty, FontWeights.Bold);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            richTextBox1.Selection.ApplyPropertyValue(FontStyleProperty, FontStyles.Italic);
        }

        private void Slider1_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            richTextBox1?.Selection.ApplyPropertyValue(FontSizeProperty, Slider1.Value.ToString());
        }

        private void listBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            richTextBox1.Selection.ApplyPropertyValue(FontFamilyProperty, (listBox1.SelectedItem as ListBoxItem).FontFamily);
        }
    }
}
