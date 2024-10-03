using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
