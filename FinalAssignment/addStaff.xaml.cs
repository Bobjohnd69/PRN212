using Repository.Models;
using Repository.Services;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for addStaff.xaml
    /// </summary>
    public partial class addStaff : Window
    {

        StaffMemberService _staffMemberService;

        public addStaff()
        {
            InitializeComponent();
            _staffMemberService = new StaffMemberService();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            var newStaffMember = new StaffMember
            {
                MemberId = int.Parse(MemberID.Text),
                Password = Password.Text,
                FullName = FullName.Text,
                EmailAddress = EmailAddress.Text,
                Role = RoleComboBox.SelectedIndex + 1
            };

            _staffMemberService.AddStaffMember(newStaffMember);
            this.Close();
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
