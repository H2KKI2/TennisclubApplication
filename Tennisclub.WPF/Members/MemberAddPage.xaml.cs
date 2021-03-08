using System;
using System.Collections.Generic;
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
using Tennisclub.Common.GenderDTO;
using Tennisclub.Common.MemberDTO;
using Tennisclub.Common.RoleDTO;

namespace Tennisclub.WPF.Members
{
    /// <summary>
    /// Interaction logic for MemberAddPage.xaml
    /// </summary>
    public partial class MemberAddPage : Page
    {
        public MemberAddPage()
        {
            InitializeComponent();
            _ = LoadGenders();
        }

        private async Task LoadGenders()
        {
            IEnumerable<GenderReadDto> genderList = await HelperAPI.Get<IEnumerable<GenderReadDto>>("genders");
            cb_Gender.ItemsSource = genderList;
        }

        private async void btn_AddMember_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(tb_FederationNr.Text) && !string.IsNullOrWhiteSpace(tb_FirstName.Text) && !string.IsNullOrWhiteSpace(tb_LastName.Text) && !string.IsNullOrWhiteSpace(tb_Adress.Text)
                && !string.IsNullOrWhiteSpace(tb_AdressNr.Text) && !string.IsNullOrWhiteSpace(tb_Zipcode.Text) && !string.IsNullOrWhiteSpace(tb_City.Text) && dp_Birthday.SelectedDate != null && cb_Gender.SelectedItem != null)
            {
                MemberCreateDto newMember = new MemberCreateDto {
                    FederationNr = tb_FederationNr.Text,
                    FirstName = tb_FirstName.Text,
                    LastName = tb_LastName.Text,
                    Birthdate = (DateTime)dp_Birthday.SelectedDate,
                    GenderId = (byte)(cb_Gender.SelectedIndex + 1),
                    Address = tb_Adress.Text,
                    Number = tb_AdressNr.Text,
                    Addition = tb_Addition.Text,
                    Zipcode = tb_Zipcode.Text,
                    City = tb_City.Text,
                    PhoneNr = tb_PhoneNr.Text
                };
                var response = await HelperAPI.Post<MemberCreateDto>("members/new", newMember);
                if (response == null)
                {
                    NavigationService.Navigate(new System.Uri("Members/MemberPage.xaml", UriKind.RelativeOrAbsolute));
                }
                else
                {
                    MessageBox.Show(response.ToString(), "Error");
                }
            }
            else
            {
                MessageBox.Show("Fill in all required fields", "Error");
            }
        }

        private void tb_AdressNr_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = Regex.IsMatch(e.Text, "[^0-9]+");
        }

        private void tb_Zipcode_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = Regex.IsMatch(e.Text, "[^0-9]+");
        }

        private void tb_FederationNr_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = Regex.IsMatch(e.Text, "[^0-9]+");
        }
    }
}
