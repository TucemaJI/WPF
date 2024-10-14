using System.ComponentModel;
using System.Windows;
using System.Windows.Data;
using Lesson_1.NwindDataSetTableAdapters;
using Lesson_1.Properties;

namespace Lesson_1
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

            ICollectionView aView = CollectionViewSource.GetDefaultView(aset.Customers);
            aView.GroupDescriptions.Add(new PropertyGroupDescription(Settings.Default.Country, new CountryGrouper()));
            aView.SortDescriptions.Add(new SortDescription(Settings.Default.Country, ListSortDirection.Ascending));

            custAdap.Fill(aset.Customers);
            ordAdap.Fill(aset.Orders);
            ord_det_extAdap.Fill(aset.Order_Details_Extended);

            Grid1.DataContext = aset.Customers;
        }
    }
}
