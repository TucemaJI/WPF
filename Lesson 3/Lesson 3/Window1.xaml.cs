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
using System.Windows.Threading;

namespace Lesson_3
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        System.ComponentModel.BackgroundWorker aWorker = new System.ComponentModel.BackgroundWorker();
        public Window1()
        {
            InitializeComponent();
            aWorker.WorkerSupportsCancellation = true;
            aWorker.DoWork += aWorker_DoWork;
            aWorker.RunWorkerCompleted += aWorker_RunWorkerCompleted;
        }
        private void aWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            Label2.Dispatcher.Invoke(DispatcherPriority.Normal, new CleanDelegate(CleanLabel2));
            for(int i = 0; i <= 500; i++)
            {
                for(int j = 1; j <= 10000000; j++)
                { 
                }
                if (aWorker.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }
                var update = new UpdateDelegate(UpdateLabel);
                Label1.Dispatcher.BeginInvoke(DispatcherPriority.Normal, update, i);
            }
        }
        private void aWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            Label2.Content = e.Cancelled ? "Run Cancelled" : "Run Completed";
        }

        private delegate void UpdateDelegate(int i);
        private void UpdateLabel(int i)
        {
            Label1.Content = $"Cycles: {i.ToString()}";
        }

        private delegate void CleanDelegate();
        private void CleanLabel2()
        {
            Label2.Content = string.Empty;
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            if (aWorker.IsBusy)
            {
                Label2.Content = "Already use";
                return;
            }
            aWorker.RunWorkerAsync();
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            aWorker.CancelAsync();
        }
    }
}

