using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Tennisclub.Common.MemberDTO;
using Tennisclub.WPF.GameResults;
using Tennisclub.WPF.Games;
using Tennisclub.WPF.MemberFines;
using Tennisclub.WPF.MemberRoles;
using Tennisclub.WPF.Members;

namespace Tennisclub.WPF
{
    /// <summary>
    /// Interaction logic for MemberPage.xaml
    /// </summary>
    public partial class MemberPage : Page
    {
        public MemberPage()
        {
            InitializeComponent();
            _ = LoadMembers();
        }

        private async Task LoadMembers()
        {
            IEnumerable<MemberReadDto> MemberList = await HelperAPI.Get<IEnumerable<MemberReadDto>>("members");
            MembersDataGrid.ItemsSource = MemberList;
        }

        private void btn_AddMember_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new System.Uri("Members/MemberAddPage.xaml", UriKind.RelativeOrAbsolute));
        }

        private void btn_UpdateMember_Click(object sender, RoutedEventArgs e)
        {
            if (MembersDataGrid.SelectedItem != null)
            {
                NavigationService.Navigate(new MemberUpdatePage((MemberReadDto)MembersDataGrid.SelectedItem));
            }
            else
            {
                MessageBox.Show("Please select member first", "Error");
            } 
        }

        private async void btn_RemoveMember_Click(object sender, RoutedEventArgs e)
        {
            MemberReadDto selectedMember = (MemberReadDto)MembersDataGrid.SelectedItem;

            if(selectedMember == null)
            {
                MessageBox.Show("Please select member first", "Error");
            }
            else
            {
                if (MessageBox.Show("Are you sure you want to remove this member?", "Remove Member", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    await HelperAPI.SoftDelete($"members/delete/{selectedMember.Id}");
                    await LoadMembers();
                }        
            }         
        }

        private async void btn_Filter_Click(object sender, RoutedEventArgs e)
        {
            var federationNrFilter = tb_FederationNrFilter.Text;
            var firstNameFilter = tb_FirstNameFilter.Text;
            var lastNameFilter = tb_LastNameFilter.Text;
            var cityFilter = tb_CityFilter.Text;
            var zipcodeFilter = tb_ZipcodeFilter.Text;
            IEnumerable<MemberReadDto> filteredMemberList = await HelperAPI.Get<IEnumerable<MemberReadDto>>($"members/filter?federationNr={federationNrFilter}&firstName={firstNameFilter}&lastName={lastNameFilter}&zipcode={zipcodeFilter}&city={cityFilter}");
            MembersDataGrid.ItemsSource = filteredMemberList;
        }

        private void btn_RolesOfMember_Click(object sender, RoutedEventArgs e)
        {
            if (MembersDataGrid.SelectedItem != null)
            {
                NavigationService.Navigate(new RolesOfMemberPage((MemberReadDto)MembersDataGrid.SelectedItem));
            }
            else
            {
                MessageBox.Show("Please select member first", "Error");
            } 
        }

        private void btn_FinesOfMember_Click(object sender, RoutedEventArgs e)
        {
            if (MembersDataGrid.SelectedItem != null)
            {
                NavigationService.Navigate(new FinesOfMemberPage((MemberReadDto)MembersDataGrid.SelectedItem));
            }
            else
            {
                MessageBox.Show("Please select member first", "Error");
            }
        }

        private void btn_GamesOfMember_Click(object sender, RoutedEventArgs e)
        {
            if (MembersDataGrid.SelectedItem != null)
            {
                NavigationService.Navigate(new GamesOfMemberPage((MemberReadDto)MembersDataGrid.SelectedItem));
            }
            else
            {
                MessageBox.Show("Please select member first", "Error");
            }
        }

        private void btn_ClearFilter_Click(object sender, RoutedEventArgs e)
        {
            tb_FederationNrFilter.Text = null;
            tb_FirstNameFilter.Text = null;
            tb_LastNameFilter.Text = null;
            tb_CityFilter.Text = null;
            tb_ZipcodeFilter.Text = null;
            _ = LoadMembers();
        }

        private void tb_ZipcodeFilter_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = Regex.IsMatch(e.Text, "[^0-9]+");
        }

        private void tb_FederationNrFilter_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = Regex.IsMatch(e.Text, "[^0-9]+");
        }
    }
}
