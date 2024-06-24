using Microsoft.IdentityModel.Tokens;
using Repository.Models;
using Repository.Services;
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

namespace FinalAssignment
{
    /// <summary>
    /// Interaction logic for AirConditionerForm.xaml
    /// </summary>
    public partial class AirConditionerForm : Window
    {
        AirConditionerService airConditionerService;
        SupplierCompanyService supplierCompanyService;
        AirConditioner AirConditioner { get; set; }
        public AirConditionerForm()
        {
            InitializeComponent();
            airConditionerService = new AirConditionerService();
            supplierCompanyService = new SupplierCompanyService();
            Load();
        }

        private void Load()
        {
            var list = airConditionerService.GetAll();
            var listSupplier = supplierCompanyService.GetAll();
            AirConditionerDataGrid.ItemsSource = list;
            SupplierComboBox.ItemsSource = listSupplier;
            SupplierComboBox.DisplayMemberPath = "SupplierName";
            SupplierComboBox.SelectedValuePath = "SupplierId";
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var airConditonerId = (int)button.Tag;
            AirConditioner airConditioner = airConditionerService.GetAirConditioner(airConditonerId);
            airConditionerService.UpdateAirConditioner(airConditioner);
            Load();
        }

        private void DelBtn_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var airConditonerId = (int)button.Tag;
            AirConditioner airConditioner = airConditionerService.GetAirConditioner(airConditonerId);
            airConditionerService.DeleteAirConditioner(airConditioner);
            Load();
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            addNewAC();
            clearAdd();
            Load();
        }

        private void addNewAC()
        {
            AirConditioner NewAC = new AirConditioner();
          
            if (string.IsNullOrEmpty(name.Text) || string.IsNullOrEmpty(warrant.Text) ||
               string.IsNullOrEmpty(spf.Text) || string.IsNullOrEmpty(ff.Text) ||
               string.IsNullOrEmpty(quantity.Text) || string.IsNullOrEmpty(dollarPrice.Text) ||
               SupplierComboBox.SelectedValue == null)
            {
                MessageBox.Show("All fields are required.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;

            }
            if (!int.TryParse(quantity.Text, out int quantityValue))
            {
                MessageBox.Show("Number required for Quantity.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (!int.TryParse(dollarPrice.Text, out int dollarPriceValue))
            {
                MessageBox.Show("Number required for Dollar Price.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            Random rng = new Random();
            NewAC.AirConditionerId = rng.Next(1000);
            NewAC.AirConditionerName = name.Text;
            NewAC.Warranty = warrant.Text;
            NewAC.SoundPressureLevel = spf.Text;
            NewAC.FeatureFunction = ff.Text;
            NewAC.Quantity = quantityValue;
            NewAC.DollarPrice = dollarPriceValue;
            NewAC.SupplierId = (string)SupplierComboBox.SelectedValue;
            airConditionerService.Add(NewAC);
        }

        private void clearAdd()
        {
            name.Text = string.Empty;
            warrant.Text = string.Empty;
            spf.Text = string.Empty;
            ff.Text = string.Empty;
            quantity.Text = string.Empty;
            dollarPrice.Text = string.Empty;
            SupplierComboBox.SelectedIndex = 0;
        }
    }
}
