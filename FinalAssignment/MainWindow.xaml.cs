﻿using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FinalAssignment
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void StaffButton_Click(object sender, RoutedEventArgs e)
        {
            StaffWindow staffWindow = new StaffWindow();
            staffWindow.Show();
        }

        private void ACButton_Click(object sender, RoutedEventArgs e)
        {
            var AC = new AirConditionerForm();
            AC.Show();
        }

        private void Supplier_Click(object sender, RoutedEventArgs e)
        {
            var Supplier = new SupplierCompanyForm();
            Supplier.Show();
        }
    }
}