using Practika.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static Practika.Model.Model.Order_Model;

namespace Practika.View
{
    /// <summary>
    /// Логика взаимодействия для OrdersPage.xaml
    /// </summary>
    public partial class OrdersPage : Window
    {
        public OrdersPage()
        {
            InitializeComponent();
            DataContext = new OrdersViewModel();
        }
        private void OrdersDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is DataGrid dataGrid && dataGrid.SelectedItem is OrderModel selectedOrder)
            {
                var viewModel = (OrdersViewModel)this.DataContext;
                viewModel.SelectedOrder = selectedOrder;
            }
        }
    }
}
