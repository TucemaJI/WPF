using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

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
            foreach (FontFamily f in Fonts.SystemFontFamilies)
            {
                var l = new ListBoxItem { Content = f.ToString(), FontFamily = f };
                listBox1.Items.Add(l);
            }
        }
    }
}