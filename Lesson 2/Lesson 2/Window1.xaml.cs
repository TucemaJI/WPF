using System.Windows;
using Lesson_2.NwindDataSetTableAdapters;

namespace Lesson_2
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        NwindDataSet aset = new NwindDataSet();
        CustomersTableAdapter custAdap = new CustomersTableAdapter();
        OrdersTableAdapter ordAdap = new OrdersTableAdapter();
        Order_Details_ExtendedTableAdapter ord_det_extAdap = new Order_Details_ExtendedTableAdapter();

        public Window1()
        {
            InitializeComponent();

            custAdap.Fill(aset.Customers);
            ordAdap.Fill(aset.Orders);
            ord_det_extAdap.Fill(aset.Order_Details_Extended);

            Grid1.DataContext = aset.Customers;
        }
    }
}
