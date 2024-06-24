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
using Repository.Models;
using Repository.Services;

namespace FinalAssignment
{
    /// <summary>
    /// Interaction logic for StaffWindow.xaml
    /// </summary>
    public partial class StaffWindow : Window
    {
        StaffMemberService _staffMemberService;

        public StaffWindow()
        {
            InitializeComponent();
            _staffMemberService = new StaffMemberService();
            LoadData();
        }

        private void LoadData()
        {
            List<StaffMember> staffMembers = _staffMemberService.GetAllStaffMembers();
            StaffDataGrid.ItemsSource = staffMembers;
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            var addWindow = new addStaff();
            if (addWindow.ShowDialog() == true)
            {
                LoadData();
            }
            LoadData();
        }

        private void myDataGrid_CellEditEnding(object sender, System.Windows.Controls.DataGridCellEditEndingEventArgs e)
        {
            if (e.EditAction == System.Windows.Controls.DataGridEditAction.Commit)
            {
                var staffMember = e.Row.Item as StaffMember;
                if (staffMember != null)
                {
                    _staffMemberService.UpdateStaffMember(staffMember);
                }
            }
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var staffMember = button.DataContext as StaffMember;

            if (staffMember != null)
            {
                _staffMemberService.UpdateStaffMember(staffMember);
                LoadData();
            }
        }

        private void DelBtn_Click(object sender, RoutedEventArgs e)
        {
            if (StaffDataGrid.SelectedItem is StaffMember selectedStaffMember)
            {
                _staffMemberService.DeleteStaffMember(selectedStaffMember);
                LoadData();
            }
        }

        private void ResetBtn_Click(object sender, RoutedEventArgs e)
        {
            LoadData();
        }
    }
}
