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
    /// Interaction logic for PageFunction1.xaml
    /// </summary>
    public partial class PageFunction1 : PageFunction<Object>, IProvideCustomContentState
    {
        public PageFunction1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            var alist = new List<ListBoxItem>();
            var blist = new List<ListBoxItem>();
            foreach (ListBoxItem lll in listBox1.Items) { alist.Add(lll); }
            foreach (ListBoxItem ll in listBox2.Items) { blist.Add(ll); }
            NavigationService.AddBackEntry(new CustomJournalEntry(alist, blist, ReplayCallback));

            ListBoxItem l = (ListBoxItem)listBox1.SelectedItem;
            listBox1.Items.Remove(l);
            listBox2.Items.Add(l);
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            var alist = new List<ListBoxItem>();
            var blist = new List<ListBoxItem>();
            foreach (ListBoxItem lll in listBox1.Items) { alist.Add(lll); }
            foreach (ListBoxItem ll in listBox2.Items) { blist.Add(ll); }
            NavigationService.AddBackEntry(new CustomJournalEntry(alist, blist, ReplayCallback));

            ListBoxItem l = (ListBoxItem)listBox2.SelectedItem;
            listBox2.Items.Remove(l);
            listBox1.Items.Add(l);
        }

        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            List<string> aList = new List<string>();
            foreach (ListBoxItem l in listBox2.Items)
            {
                aList.Add(l.Content.ToString());
            }
            ReturnEventArgs<object> ee = new ReturnEventArgs<object>(aList);
            OnReturn(ee);
        }

        private void ReplayCallback(CustomJournalEntry c)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            foreach (ListBoxItem l in c.AvailableToppings) { listBox1.Items.Add(l); }
            foreach (ListBoxItem ll in c.ChosenToppings) { listBox2.Items.Add(ll); }
        }

        public CustomContentState GetContentState()
        {
            var alist = new List<ListBoxItem>();
            var blist = new List<ListBoxItem>();
            foreach (ListBoxItem l in listBox1.Items) { alist.Add(l); }
            foreach (ListBoxItem ll in listBox2.Items) { blist.Add(ll); }
            return new CustomJournalEntry(alist, blist, ReplayCallback);
        }
    }

    [Serializable()]
    public class CustomJournalEntry : CustomContentState
    {
        private List<ListBoxItem> atops;
        private List<ListBoxItem> ctops;
        public List<ListBoxItem> AvailableToppings { get { return atops; } set { atops = value; } }
        public List<ListBoxItem> ChosenToppings { get { return ctops; } set { ctops = value; } }

        public override string JournalEntryName => "Custom Journal Entry";

        public delegate void ReplayDelegate(CustomJournalEntry c);
        private ReplayDelegate replayDelegate;

        public override void Replay(NavigationService navigationService, NavigationMode mode)
        {
            replayDelegate(this);
        }

        public CustomJournalEntry(List<ListBoxItem> availableToppings, List<ListBoxItem> chosenToppings, ReplayDelegate replayDelegate)
        {
            atops = availableToppings;
            ctops = chosenToppings;
            this.replayDelegate = replayDelegate;
        }
    }
}
