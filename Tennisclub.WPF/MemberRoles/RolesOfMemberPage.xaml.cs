using System;
using System.Collections.Generic;
using System.Text;
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
using Tennisclub.Common.MemberRoleDTO;
using Tennisclub.Common.RoleDTO;

namespace Tennisclub.WPF.MemberRoles
{
    /// <summary>
    /// Interaction logic for RolesOfMemberPage.xaml
    /// </summary>
    public partial class RolesOfMemberPage : Page
    {
        public MemberReadDto SelectedMember { get; set; }
        public RolesOfMemberPage(MemberReadDto selectedMember)
        {
            InitializeComponent();
            SelectedMember = selectedMember;
            LoadRoles();
            LoadTitle();
            LoadRolesComboBox();
        }

        private async void LoadRoles()
        {
            IEnumerable<MemberRoleReadDto> roleList = await HelperAPI.Get<IEnumerable<MemberRoleReadDto>>($"memberroles/rolesofmember/{SelectedMember.Id}");
            MemberRolesDataGrid.ItemsSource = roleList;
        }

        private void LoadTitle()
        {
            tb_TitleMember.Text = $"{SelectedMember.FirstName} {SelectedMember.LastName}";
        }
        private async void LoadRolesComboBox()
        {
            cb_Roles.ItemsSource = await HelperAPI.Get<IEnumerable<RoleReadDto>>("roles");
            cb_Roles.SelectedIndex = 0;
        }

        private async void btn_AssignRoleToMember_Click(object sender, RoutedEventArgs e)
        {
                if (dp_StartDate.SelectedDate != null)
                {
                    RoleReadDto selectedRoleCombobox = (RoleReadDto)cb_Roles.SelectedItem;
                    MemberRoleCreateDto memberRole = new MemberRoleCreateDto {
                        MemberId = SelectedMember.Id,
                        RoleId = selectedRoleCombobox.Id,
                        StartDate = (DateTime)dp_StartDate.SelectedDate
                    };
                    var response = await HelperAPI.Post<MemberRoleCreateDto>("memberroles/Assign", memberRole);

                    if (response == null)
                    {
                        LoadRoles();
                    }
                    else
                    {
                        MessageBox.Show(response.ToString(), "Error");
                    }
                }
                else
                {
                    MessageBox.Show("Please select a start date", "Error");
                }
        }
        private void btn_ShowAddRoleMenu_Click(object sender, RoutedEventArgs e)
        {
            RemoveRoleMenu.Visibility = Visibility.Hidden;
            AddRoleMenu.Visibility = Visibility.Visible;
        }
        private void btn_ShowRemoveRoleMenu_Click(object sender, RoutedEventArgs e)
        {
            AddRoleMenu.Visibility = Visibility.Hidden;
            RemoveRoleMenu.Visibility = Visibility.Visible;
        }

        private async void btn_RemoveRoleOfMember_Click(object sender, RoutedEventArgs e)
        {
            if (MemberRolesDataGrid.SelectedItem != null)
            {
                if (dp_EndtDate.SelectedDate != null)
                {
                    MemberRoleReadDto selectedMemberRole = (MemberRoleReadDto)MemberRolesDataGrid.SelectedItem;
                    MemberRoleUpdateDto memberRole = new MemberRoleUpdateDto {
                        Id = selectedMemberRole.Id,
                        MemberId = SelectedMember.Id,
                        RoleId = selectedMemberRole.Role.Id,
                        StartDate = selectedMemberRole.StartDate,
                        EndDate = (DateTime)dp_EndtDate.SelectedDate
                    };
                    var response = await HelperAPI.Update($"memberroles/remove/{selectedMemberRole.Id}", memberRole);
                    if (response == null)
                    {
                        LoadRoles();
                    }
                    else
                    {
                        MessageBox.Show(response.ToString(), "Error");
                    }
                }
                else
                {
                    MessageBox.Show("Please select an end date", "Error");
                }
            }
            else
            {
                MessageBox.Show("Please select a member first", "Error");
            } 
        }
    }
}
