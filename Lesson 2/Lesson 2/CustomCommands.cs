using System.Windows.Input;

namespace Lesson_2
{
    public class CustomCommands
    {
        private const string NAME = "Launch";

        private static RoutedUICommand launch_command;
        public static RoutedUICommand Launch { get { return launch_command; } }

        static CustomCommands()
        {
            var myInputGestures = new InputGestureCollection { new KeyGesture(Key.L, ModifierKeys.Control) };
            launch_command = new RoutedUICommand(text: NAME, name: NAME, ownerType: typeof(CustomCommands),
                                                inputGestures: myInputGestures);
        }
    }
}
