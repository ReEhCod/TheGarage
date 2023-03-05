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

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            string mark = tbMarkToAdd.Text;
            string model = tbModelToAdd.Text;
            int numberOfSeats = int.Parse(tbNumberOfSeats.Text);
            bool isElectric = chbxIsElectric.IsChecked ??  false;

            if(mark == null || numberOfSeats == null || model == null) 
            {
                MessageBox.Show("Please fill with more information", "Attention");
            } else
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
            }
            MessageBox.Show("New car added successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            GarageWindow gw = new();
            gw.Show();
            Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            GarageWindow garageWindow = new();
            garageWindow.Show();
            Close();
        }
    }
}
