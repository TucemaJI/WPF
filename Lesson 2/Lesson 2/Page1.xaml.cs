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
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        public Page1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            PageFunction1 apage = new PageFunction1();
            apage.Return += new ReturnEventHandler<object>(apage_Return);
            NavigationService.Navigate(apage);
        }

        private void apage_Return(object sender, ReturnEventArgs<object> e)
        {
            List<string> aList = (List<string>)e.Result;
            foreach (string s in aList)
            {
                listBox1.Items.Add(s);
            }
        }
    }
}
