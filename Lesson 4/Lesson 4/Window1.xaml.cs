using System;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Forms;
using Lesson_4.Properties;

namespace Lesson_4
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

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            aDialog.Filter = Settings.Default.Filter;
            if (aDialog.ShowDialog() is System.Windows.Forms.DialogResult.OK)
            {
                Image1.Source = new BitmapImage(new Uri(aDialog.FileName));
            }
            FillListBox();
        }

        private void FillListBox()
        {
            if (aDialog.FileName is null || aDialog.FileName == string.Empty)
            {
                return;
            }

            var aDecoder = BitmapDecoder.Create(bitmapUri: new Uri(aDialog.FileName),
                createOptions: BitmapCreateOptions.None, cacheOption: BitmapCacheOption.Default);
            var metadata = (BitmapMetadata)aDecoder.Frames[0].Metadata;

            if (metadata is null) { return; }

            if (metadata.Author != null)
            {
                ListBox1.Items.Add($"Author: {metadata.Author[0]}");
            }
            if (metadata.DateTaken != null)
            {
                ListBox1.Items.Add($"Date Taken: {metadata.DateTaken[0]}");
            }
            ListBox1.Items.Add($"Rating: {metadata.Rating}");
            if (metadata.Title != null)
            {
                ListBox1.Items.Add($"Title: {metadata.Title}");
            }
        }
    }
}
