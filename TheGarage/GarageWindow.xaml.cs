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
using TheGarage.Data;
using TheGarage.Models;
using TheGarage.Services;

namespace TheGarage
{
    /// <summary>
    /// Interaction logic for GarageWindow.xaml
    /// </summary>
    public partial class GarageWindow : Window
    {
        private List<CarModel> cars = new();
        public GarageWindow()
        {
            InitializeComponent();
            btnDelete.IsEnabled= false;
            
            using (AppDbContext context = new())
            {
                CarRepo carRepo = new(context);
                List<int> seatsList = carRepo.GetCars().Select(c => c.NumberOfSeats).Distinct().ToList();
                cbSeats.ItemsSource = seatsList;
            }
            UpdateUi();
        }


        private void UpdateUi()
        {
            using(AppDbContext context = new())
            {
                CarRepo carRepo = new(context);
                this.cars = carRepo.GetCars();
            }

            lvCars.ItemsSource = this.cars;
            btnAllCars.IsEnabled = false;
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            CarModel selectedCar = (CarModel)lvCars.SelectedItem;

            MessageBoxResult msg = MessageBox.Show("Are you sure you want to delete the car?", "~~~~~Warning!~~~~~~",MessageBoxButton.YesNo);
            if (msg == MessageBoxResult.Yes)
            {
                using (AppDbContext context = new())
                {
                    CarRepo carRepo = new(context);
                    carRepo.RemoveTheCar(selectedCar.CarId);

                    context.SaveChanges();
                };

                UpdateUi();
            }
            
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddCarWindow addWindow = new();
            addWindow.Show();
            Close();

        }

        private void lvCars_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lvCars.SelectedItems.Count > 0)
            {
                btnDelete.IsEnabled = true;
            }
            else
            {
                btnDelete.IsEnabled = false;
            }
        }


        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            string mark = tbMark.Text;
            int? seats = cbSeats.SelectedItem as int?;

            if (string.IsNullOrEmpty(mark) && seats == null)
            {
                MessageBox.Show("Please enter a search term or select a number of seats.");
                return;
            }

            using (AppDbContext context = new())
            {
                CarRepo carRepo = new(context);
                List<CarModel> filteredCars = carRepo.GetCars()
                    .Where(c => string.IsNullOrEmpty(mark) || c.Mark.Contains(mark))
                    .Where(c => seats == null || c.NumberOfSeats == seats.Value)
                    .ToList();

                lvCars.ItemsSource = filteredCars;
            }
            tbMark.Clear();
            cbSeats.SelectedItem = default(int?);
            btnAllCars.IsEnabled = true;
        }

        private void btnAllCars_Click(object sender, RoutedEventArgs e)
        {
            UpdateUi();
        }
    }
}
