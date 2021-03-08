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
using Tennisclub.Common.MemberRoleDTO;
using Tennisclub.Common.RoleDTO;

namespace Tennisclub.WPF.MemberRoles
{
    /// <summary>
    /// Interaction logic for MemberWithRolesPage.xaml
    /// </summary>
    public partial class MemberWithRolesPage : Page
    {
        public List<RoleReadDto> SelectedRoles { get; set; }
        public MemberWithRolesPage(List<RoleReadDto> selectedRoles)
        {
            InitializeComponent();
            SelectedRoles = selectedRoles;
            LoadTitle();
            LoadMembers();
        }

        private async void LoadMembers()
        {
            string path = "memberroles/memberswithrole?";
            foreach (RoleReadDto role in SelectedRoles)
            {
                path += $"ids={role.Id}&";
            }
            path = path.Remove(path.LastIndexOf("&", path.Length));
            var response = await HelperAPI.Get<IEnumerable<MemberRoleReadDto>>(path);
            MembersDataGrid.ItemsSource = response;
        }
        private void LoadTitle()
        {
            var title = "";
            const int MAX_TITLE_LENGTH = 5;
            if (SelectedRoles.Count > MAX_TITLE_LENGTH)
            {
                for (int i = 0; i < MAX_TITLE_LENGTH; i++)
                {
                    title += $"{SelectedRoles[i].Name}, ";
                }
                title += "...";
            }
            else
            {
                foreach (RoleReadDto role in SelectedRoles)
                {
                    title += $"{role.Name}, ";
                }
                title = title.Remove(title.LastIndexOf(",", title.Length));
            }
            tb_TitleRoles.Text = title;
        }

        private async void btn_RemoveSelectedRole_Click(object sender, RoutedEventArgs e)
        {
            if (MembersDataGrid.SelectedItem != null )
            {
                if (dp_EndDate.SelectedDate != null)
                {
                    MemberRoleReadDto selectedMemberRole = (MemberRoleReadDto)MembersDataGrid.SelectedItem;
                    MemberRoleUpdateDto memberRole = new MemberRoleUpdateDto {
                        Id = selectedMemberRole.Id,
                        MemberId = selectedMemberRole.Member.Id,
                        RoleId = selectedMemberRole.Role.Id,
                        StartDate = selectedMemberRole.StartDate,
                        EndDate = (DateTime)dp_EndDate.SelectedDate
                    };
                    var response = await HelperAPI.Update($"memberroles/remove/{selectedMemberRole.Id}", memberRole);

                    if (response != null)
                    {
                        MessageBox.Show(response.ToString(), "Error");
                    }
                    else
                    {
                        LoadMembers();
                        MembersDataGrid.SelectedItem = memberRole;
                    }
                }
                else
                {
                    MessageBox.Show("Please select a date", "Error");
                }
            }
            else
            {
                MessageBox.Show("Please select a member first", "Error");
            }
        }
    }
}
