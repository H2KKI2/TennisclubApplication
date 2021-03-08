using System;
using System.Collections.Generic;
using System.Text;
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

namespace Tennisclub.WPF.Members
{
    /// <summary>
    /// Interaction logic for MemberUpdatePage.xaml
    /// </summary>
    public partial class MemberUpdatePage : Page
    {
        public MemberReadDto SelectedMember { get; set; }
        public MemberUpdatePage(MemberReadDto member)
        {
            InitializeComponent();
            SelectedMember = member;
            _ = LoadGenders();
            LoadFields(member);
        }
        private async Task LoadGenders()
        {
            IEnumerable<GenderReadDto> genderList = await HelperAPI.Get<IEnumerable<GenderReadDto>>("genders");
            cb_Gender.ItemsSource = genderList;
        }
        private void LoadFields(MemberReadDto member)
        {
            tb_FederationNr.Text = member.FederationNr;
            tb_FirstName.Text = member.FirstName;
            tb_LastName.Text = member.LastName;
            dp_Birthday.SelectedDate = member.Birthdate;
            tb_PhoneNr.Text = member.PhoneNr;
            cb_Gender.SelectedIndex = member.Gender.Id -1;
            tb_Adress.Text = member.Address;
            tb_AdressNr.Text = member.Number;
            tb_Addition.Text = member.Addition;
            tb_Zipcode.Text = member.Zipcode;
            tb_City.Text = member.City;
        }
        private async void btn_UpdateMember_Click(object sender, RoutedEventArgs e)
        {
            MemberUpdateDto newMember = new MemberUpdateDto {
                Id = SelectedMember.Id,
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

            var response = await HelperAPI.Update($"members/{newMember.Id}", newMember);
            if (response != null)
            {
                MessageBox.Show(response.ToString(), "Error");
            }
            else
            {
                NavigationService.Navigate(new System.Uri("Members/MemberPage.xaml", UriKind.RelativeOrAbsolute));
            } 
        }
    }
}
