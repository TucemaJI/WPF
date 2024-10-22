using System.Windows;
using System.Timers;
using System.Windows.Controls;
using TimerCustomControlLibrary.Properties;
using System.Windows.Threading;

namespace TimerCustomControlLibrary
{
    /// <summary>
    /// Follow steps 1a or 1b and then 2 to use this custom control in a XAML file.
    ///
    /// Step 1a) Using this custom control in a XAML file that exists in the current project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:TimerCustomControlLibrary"
    ///
    ///
    /// Step 1b) Using this custom control in a XAML file that exists in a different project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:TimerCustomControlLibrary;assembly=TimerCustomControlLibrary"
    ///
    /// You will also need to add a project reference from the project where the XAML file lives
    /// to this project and Rebuild to avoid compilation errors:
    ///
    ///     Right click on the target project in the Solution Explorer and
    ///     "Add Reference"->"Projects"->[Select this project]
    ///
    ///
    /// Step 2)
    /// Go ahead and use your control in the XAML file.
    ///
    ///     <MyNamespace:CustomControl1/>
    ///
    /// </summary>
    public class CustomControl1 : Control
    {
        static CustomControl1()
        {
            FrameworkPropertyMetadata metadata = new();
            TimeProperty = DependencyProperty.Register(Settings.Default.TimeDependencyPropertyName, typeof(string),
                typeof(CustomControl1), metadata);
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CustomControl1), new FrameworkPropertyMetadata(typeof(CustomControl1)));
        }

        public CustomControl1()
        {
            myTimer.Elapsed += timer_elapsed;
            myTimer.Interval = Settings.Default.TimeInterval;
            myTimer.Start();
            DataContext = this;
        }

        private void TimeSetter() => SetValue(TimeProperty, DateTime.Now.ToLongTimeString());

        private void timer_elapsed(object sender, ElapsedEventArgs e)
        {
            Dispatcher.Invoke(DispatcherPriority.Normal, new SetterDelegate(TimeSetter));
        }

        public static readonly DependencyProperty TimeProperty;
        private System.Timers.Timer myTimer = new();
        delegate void SetterDelegate();
    }
}