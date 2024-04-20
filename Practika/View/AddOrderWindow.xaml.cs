using Practika.Model.Model;
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
    /// Логика взаимодействия для AddOrderWindow.xaml
    /// </summary>
    public partial class AddOrderWindow : Window
    {
        private readonly DataManager _dataManager = new DataManager();
        public AddOrderWindow()
        {
            InitializeComponent();
        }
        private void AddOrder_Click(object sender, RoutedEventArgs e)
        {
            // Create a new OrderModel from input fields
            OrderModel newOrder = new OrderModel
            {
                ID_YSLUGE = Convert.ToInt32(txtServiceId.Text),
                id_sotrudnika = Convert.ToInt32(txtsotrudnikId.Text),
                id_clients = Convert.ToInt32(txtClientId.Text),
                id_car = Convert.ToInt32(txtCarId.Text),
                nomer_car = Convert.ToInt32(txtCarNumber.Text),
                date = dpDate.SelectedDate ?? DateTime.Now, 
                sum = Convert.ToDecimal(txtSum.Text),
                status = txtStatus.Text
            };

            _dataManager.AddOrder(newOrder);

            this.Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

