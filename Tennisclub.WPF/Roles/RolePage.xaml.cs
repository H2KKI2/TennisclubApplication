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
using Tennisclub.Common.MemberDTO;
using Tennisclub.Common.RoleDTO;
using Tennisclub.WPF.MemberRoles;

namespace Tennisclub.WPF.Roles
{
    /// <summary>
    /// Interaction logic for RolePage.xaml
    /// </summary>
    public partial class RolePage : Page
    {
        public RoleReadDto SelectedRole { get; set; }
        public RolePage()
        {
            InitializeComponent();
            _ = LoadRoles();
        }

        private async Task LoadRoles()
        {
            IEnumerable<RoleReadDto> RoleList = await HelperAPI.Get<IEnumerable<RoleReadDto>>("roles");
            UpdateGrid(RoleList);
        }

        private async void btn_UpdateRole_Click(object sender, RoutedEventArgs e)
        {
            if (RolesDataGrid.SelectedItem != null)
            {
                RoleUpdateDto updatedRole = new RoleUpdateDto {
                    Id = SelectedRole.Id,
                    Name = tb_RoleNameUpdate.Text
                };
                var response = await HelperAPI.Update($"roles/{SelectedRole.Id}", updatedRole);

                if (response == null)
                {
                    await LoadRoles();
                    RoleReadDto selectedRole = new RoleReadDto {
                        Id = updatedRole.Id,
                        Name = updatedRole.Name
                    };
                    SelectedRole = selectedRole;
                }
                else
                {
                    MessageBox.Show(response.ToString(), "Error");
                }
            }
            else
            {
                MessageBox.Show("Please selecte a role first", "Error");
            }
            
        }

        private async void btn_AddRole_Click(object sender, RoutedEventArgs e)
        {
            RoleCreateDto newRole = new RoleCreateDto {
                Name = tb_RoleNameAdd.Text
            };

            var response = await HelperAPI.Post<RoleCreateDto>("roles/new", newRole);
            if (response == null)
            {
                await LoadRoles();
                tb_RoleNameAdd.Text = "";
            }
            else
            {
                MessageBox.Show(response.ToString(), "Error");
            }
        }

        private void UpdateGrid(IEnumerable<RoleReadDto> roleList)
        {
            RolesDataGrid.ItemsSource = roleList;
        }

        private void RolesDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedRole = (RoleReadDto)RolesDataGrid.SelectedItem;
            if(SelectedRole != null)
                tb_RoleNameUpdate.Text = SelectedRole.Name;
        }

        private void btn_MemberWithRoles_Click(object sender, RoutedEventArgs e)
        {
            if (RolesDataGrid.SelectedItem != null)
            {
                List<RoleReadDto> roles = new List<RoleReadDto>();
                            foreach (RoleReadDto role in RolesDataGrid.SelectedItems)
                            {
                                roles.Add(role);
                            }
                            NavigationService.Navigate(new MemberWithRolesPage(roles));
            }
            else
            {
                MessageBox.Show("Please selecte a role first", "Error");
            }
            
        }
    }
}
