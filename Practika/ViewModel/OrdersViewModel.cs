using System.Collections.ObjectModel;
using Practika.Model.Model;
using MvvmHelpers;
using static Practika.Model.Model.Order_Model;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Windows.Input;
using Practika.Model.Model;
using System;
using Practika.View;

namespace Practika.ViewModel
{
    public class OrdersViewModel : INotifyPropertyChanged
    {
        private readonly DataManager _dataManager = new DataManager();

        private ObservableCollection<OrderModel> _orders;
        public ObservableCollection<OrderModel> Orders
        {
            get { return _orders; }
            set
            {
                _orders = value;
                OnPropertyChanged(nameof(Orders));
            }
        }

        private OrderModel _selectedOrder;
        public OrderModel SelectedOrder
        {
            get { return _selectedOrder; }
            set
            {
                _selectedOrder = value;
                OnPropertyChanged(nameof(SelectedOrder));
            }
        }

        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        public OrdersViewModel()
        {
            LoadOrders();

            AddCommand = new RelayCommand(AddOrder);
            EditCommand = new RelayCommand(EditOrder, CanEditDeleteOrder);
            DeleteCommand = new RelayCommand(DeleteOrder, CanEditDeleteOrder);
        }

        private void LoadOrders()
        {
            Orders = _dataManager.GetOrders();
        }

        private void AddOrder(object obj)
        {
            System.Diagnostics.Debug.WriteLine("Opening AddOrderWindow"); // Логирование

            // Create and show AddOrderWindow
            AddOrderWindow addOrderWindow = new AddOrderWindow();
            addOrderWindow.ShowDialog();
        }

        private void EditOrder(object obj)
        {
            if (SelectedOrder != null)
            {
                _dataManager.EditOrder(SelectedOrder);
                LoadOrders();
            }
        }

        private void DeleteOrder(object obj)
        {
            if (SelectedOrder != null)
            {
                _dataManager.DeleteOrder(SelectedOrder.id_ordes);
                LoadOrders();
            }
        }

        private bool CanEditDeleteOrder(object obj)
        {
            return SelectedOrder != null;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    // RelayCommand class for ICommand implementation
    public class RelayCommand : ICommand
    {
        private readonly Action<object> _execute;
        private readonly Predicate<object> _canExecute;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public RelayCommand(Action<object> execute, Predicate<object> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }
    }
}