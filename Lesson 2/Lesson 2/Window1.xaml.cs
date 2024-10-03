using System.Windows;
using System.Windows.Input;

namespace Lesson_2
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            var aBinding = new CommandBinding();
            aBinding.Command = CustomCommands.Launch;
            aBinding.Executed += new ExecutedRoutedEventHandler(Launch_Handler);
            aBinding.CanExecute += new CanExecuteRoutedEventHandler(LaunchEnabled_Handler);
            CommandBindings.Add(aBinding);
        }

        private void Launch_Handler(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("Launch Invoked");
        }

        private void LaunchEnabled_Handler(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = (bool)checkBox.IsChecked;
        }
    }
}
