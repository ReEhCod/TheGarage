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

namespace TheGarage
{
    /// <summary>
    /// Interaction logic for AddCarWindow.xaml
    /// </summary>
    public partial class AddCarWindow : Window
    {
        public AddCarWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Saves all the input information about a new car in database and sends user back to GarageWindow. It checks so every input is correct filled. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            string mark = tbMarkToAdd.Text;
            string model = tbModelToAdd.Text;
            
            bool isElectric = chbxIsElectric.IsChecked ?? false;

            if (string.IsNullOrEmpty(mark) || string.IsNullOrEmpty(model) || string.IsNullOrEmpty(tbNumberOfSeats.Text))
            {
                MessageBox.Show("Please fill with more information", "Attention");
                return;
            }
            if(!int.TryParse(tbNumberOfSeats.Text, out int numberOfSeats))
            {
                MessageBox.Show("Please enter a valid number for number of seats", "Attention");
                return;
            }
            try
            {

                CarModel newCar = new CarModel()
                {
                    Mark = mark,
                    Model = model,
                    NumberOfSeats = numberOfSeats,
                    IsElectric = isElectric
                };

                using (AppDbContext context = new AppDbContext())
                {
                    context.Cars.Add(newCar);
                    context.SaveChanges();
                }

                MessageBox.Show("New car added successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                GarageWindow gw = new();
                gw.Show();
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Button sends user back to main page
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            GarageWindow garageWindow = new();
            garageWindow.Show();
            Close();
        }
    }
}
