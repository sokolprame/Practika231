using MvvmHelpers;
using Practika.Model.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Practika.Model.Model.CarModel;
using System.Windows.Input;


namespace Practika.ViewModel
{

        public class CarsViewModel : BaseViewModel // BaseViewModel может содержать реализацию INotifyPropertyChanged
        {
        private readonly DataManager _dataManager = new DataManager();
        public ObservableCollection<CarModel> Cars
        {
            get { return _cars; }
            set
            {
                _cars = value;
                OnPropertyChanged(nameof(Cars));
            }
        }
        private ObservableCollection<CarModel> _cars;
      


        public ICommand AddCarCommand { get; private set; }
            public ICommand EditCarCommand { get; private set; }
            public ICommand DeleteCarCommand { get; private set; }

            public CarsViewModel()
            {
                LoadCars();
                AddCarCommand = new RelayCommand(param => AddCar(), param => CanAddOrEditCar());
                EditCarCommand = new RelayCommand(param => EditCar(), param => CanAddOrEditCar());
                DeleteCarCommand = new RelayCommand(param => DeleteCar(), param => CanDeleteCar());
            }

            private void LoadCars()
            {
                Cars = new DataManager().GetCars();
            }

            private void AddCar()
            {
                // Логика добавления нового автомобиля
                // Обновляем коллекцию после добавления
                LoadCars();
            }

            private void EditCar()
            {
                // Логика редактирования автомобиля
                // Обновляем коллекцию после редактирования
                LoadCars();
            }

            private void DeleteCar()
            {
                // Логика удаления автомобиля
                // Обновляем коллекцию после удаления
                LoadCars();
            }

            private bool CanAddOrEditCar()
            {
                // Проверка условий для добавления или редактирования автомобиля
                return true;
            }

            private bool CanDeleteCar()
            {
                // Проверка условий для удаления автомобиля
                return true;
            }
        }
    }
