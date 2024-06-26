﻿using Practika.View;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Practika
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OrdersButton_Click(object sender, RoutedEventArgs e)
        {
            OrdersPage ordersPage = new OrdersPage();
            MainFrame.Navigate(ordersPage);
        }

        private void MainFrame_Navigated(object sender, NavigationEventArgs e)
        {

        }

        private void OpenOrdersPageButton_Click(object sender, RoutedEventArgs e)
        {
            OrdersPage ordersPage = new OrdersPage();
            ordersPage.Show();
        }
    }
}
