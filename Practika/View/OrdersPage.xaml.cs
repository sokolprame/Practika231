﻿using System;
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
        }
        private void OrdersDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Ваш код обработки события SelectionChanged
        }


    }
}