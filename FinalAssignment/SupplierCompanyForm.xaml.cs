using Repository.Models;
using Repository.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for SupplierCompanyForm.xaml
    /// </summary>
    public partial class SupplierCompanyForm : Window
    {

        SupplierCompanyService supplierCompanyService;
        public SupplierCompanyForm()
        {
            InitializeComponent();
            supplierCompanyService = new SupplierCompanyService();
            Load();
        }

        private void Load()
        {
            var listSupplier = supplierCompanyService.GetAll();
            SupplierCompanyDataGrid.ItemsSource = listSupplier;
        }

        private void DelBtn_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var supplierID = (String)button.Tag;
            SupplierCompany supplierCompany = supplierCompanyService.GetSupplierCompany(supplierID);
            supplierCompanyService.DeleteSupplierCompany(supplierCompany);
            Load();
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            addNewSupplier();
            clearAdd();
            Load();
        }

        private void addNewSupplier()
        {
            SupplierCompany NewSupplier = new SupplierCompany();

            if (string.IsNullOrEmpty(name.Text) || string.IsNullOrEmpty(description.Text) ||
               string.IsNullOrEmpty(poo.Text) || string.IsNullOrEmpty(supplierID.Text))
            {
                MessageBox.Show("All fields are required.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;

            }
            if(!Regex.IsMatch(supplierID.Text, @"^SC\d{4}$"))
            {
                MessageBox.Show("ID does not follow format. Hint(SC0001)", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            NewSupplier.SupplierId = supplierID.Text;
            NewSupplier.SupplierName = name.Text;
            NewSupplier.SupplierDescription = description.Text;
            NewSupplier.PlaceOfOrigin = poo.Text;
            supplierCompanyService.Add(NewSupplier);
        }

        private void clearAdd()
        {
            supplierID.Text = string.Empty;
            name.Text = string.Empty;
            description.Text = string.Empty;
            poo.Text = string.Empty;
        }

        private void SupplierCompanyDataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            if (e.EditAction == System.Windows.Controls.DataGridEditAction.Commit)
            {
                var edittedSupplier = e.Row.Item as SupplierCompany;
                if (edittedSupplier != null)
                {
                    supplierCompanyService.Update(edittedSupplier);
                }
            }
        }
    }
}
