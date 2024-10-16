using System.ComponentModel;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Lesson_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Names myNames;
        private readonly ICollectionView aView;

        public MainWindow()
        {
            InitializeComponent();
            myNames = (Names)Resources["myNames"];
            aView = CollectionViewSource.GetDefaultView(myNames);
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            if (aView.CurrentPosition is not byte.MinValue) { aView.MoveCurrentToPrevious(); }
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            if (aView.CurrentPosition != myNames.Count - 1) { aView.MoveCurrentToNext(); }
        }

        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            StringValidator validator = new();
            var validationResult1 = validator.Validate(TextBox1.Text, CultureInfo.CurrentCulture);
            var validationResult2 = validator.Validate(TextBox2.Text, CultureInfo.CurrentCulture);

            if (!validationResult1.IsValid || !validationResult2.IsValid)
            {
                MessageBox.Show(validationResult1.ErrorContent is not null
                    ? validationResult1.ErrorContent.ToString() : validationResult2.ErrorContent.ToString());
                return;
            }

            myNames.Add(new(fName: string.Empty, lName: string.Empty));
            aView.MoveCurrentToNext();
        }

        private void Grid_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action is ValidationErrorEventAction.Added) { MessageBox.Show(e.Error.ErrorContent.ToString()); }
        }
    }
}