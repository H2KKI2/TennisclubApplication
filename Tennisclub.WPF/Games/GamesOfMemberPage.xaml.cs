using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Tennisclub.Common.GameDTO;
using Tennisclub.Common.LeagueDTO;
using Tennisclub.Common.MemberDTO;
using Tennisclub.WPF.GameResults;

namespace Tennisclub.WPF.Games
{
    /// <summary>
    /// Interaction logic for GamesOfMemberPage.xaml
    /// </summary>
    public partial class GamesOfMemberPage : Page
    {
        public MemberReadDto SelectedMember { get; set; }
        public GamesOfMemberPage(MemberReadDto selectedMember)
        {
            InitializeComponent();
            SelectedMember = selectedMember;
            LoadTitle();
            LoadGames();
            LoadLeagues();
        }
        private void LoadTitle()
        {
            tb_TitleMember.Text = $"{SelectedMember.FirstName} {SelectedMember.LastName}";
        }
        private async void LoadGames()
        {
            IEnumerable<GameReadDto> memberGames = await HelperAPI.Get<IEnumerable<GameReadDto>>($"games/gamesofmember/{SelectedMember.Id}");
            gamesDataGrid.ItemsSource = memberGames;
        }

        private async void LoadLeagues()
        {
            IEnumerable<LeagueReadDto> leagueList = await HelperAPI.Get<IEnumerable<LeagueReadDto>>("leagues");
            cb_LeaguesPlan.ItemsSource = leagueList;
            cb_LeaguesEdit.ItemsSource = leagueList;
            cb_LeaguesPlan.SelectedIndex = 0;    
        }

        private async void btn_Filter_Click(object sender, RoutedEventArgs e)
        {
            var date = dp_DateFilter.SelectedDate;
            IEnumerable<GameReadDto> memberGames = await HelperAPI.Get<IEnumerable<GameReadDto>>($"games/filter?date={date}");
            gamesDataGrid.ItemsSource = memberGames;
        }

        private async void btn_PlanGame_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(tb_GameNrPlan.Text) && dp_DatePlan.SelectedDate != null)
            {
                LeagueReadDto selectedLeague = (LeagueReadDto)cb_LeaguesPlan.SelectedItem;
                GameCreateDto newGame = new GameCreateDto {
                    GameNumber = tb_GameNrPlan.Text,
                    LeagueId = selectedLeague.Id,
                    MemberId = SelectedMember.Id,
                    Date = (DateTime)dp_DatePlan.SelectedDate
                };
                var response = await HelperAPI.Post<GameCreateDto>($"games/new", newGame);

                if (response == null)
                {
                    LoadGames();
                }
                else
                {
                    MessageBox.Show(response.ToString(), "Error");
                }
            }
            else
            {
                MessageBox.Show("Please fill in all fields", "Error");
            }
        }

        private async void btn_EditGame_Click(object sender, RoutedEventArgs e)
        {
            if (gamesDataGrid.SelectedItem != null)
            {
                if (!string.IsNullOrWhiteSpace(tb_GameNrEdit.Text) && dp_DateEdit.SelectedDate != null)
                {
                    var selectedGame = (GameReadDto)gamesDataGrid.SelectedItem;
                    GameUpdateDto updateGame = new GameUpdateDto {
                        Id = selectedGame.Id,
                        GameNumber = tb_GameNrEdit.Text,
                        MemberId = SelectedMember.Id,
                        LeagueId = (byte)(cb_LeaguesEdit.SelectedIndex + 1),
                        Date = (DateTime)dp_DateEdit.SelectedDate
                    };
                    var response = await HelperAPI.Update($"games/{selectedGame.Id}", updateGame);

                    if (response == null)
                    {
                        LoadGames();
                    }
                    else
                    {
                        MessageBox.Show(response.ToString(), "Error");
                    }
                }
                else
                {
                    MessageBox.Show("Please fill in all fields", "Error");
                }
            }
            else
            {
                MessageBox.Show("Please select a game first", "Error");
            }
        }

        private void btn_ShowEditGameMenu_Click(object sender, RoutedEventArgs e)
        {
            EditGameMenu.Visibility = Visibility.Visible;
            PlanGameMenu.Visibility = Visibility.Hidden;
        }

        private void btn_ShowPlanGameMenu_Click(object sender, RoutedEventArgs e)
        {
            PlanGameMenu.Visibility = Visibility.Visible;
            EditGameMenu.Visibility = Visibility.Hidden;
        }

        private async void btn_RemoveGame_Click(object sender, RoutedEventArgs e)
        {
            if (gamesDataGrid.SelectedItem != null)
            {
                var selectedGame = (GameReadDto)gamesDataGrid.SelectedItem;
                await HelperAPI.Delete($"games/{selectedGame.Id}");
                LoadGames();
            }
            else
            {
                MessageBox.Show("Please select a game first", "Error");
            }
        }

        private void gamesDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {            
            var selectedGame = (GameReadDto)gamesDataGrid.SelectedItem;
            if (selectedGame == null)
                return;

            tb_GameNrEdit.Text = selectedGame.GameNumber;
            cb_LeaguesEdit.SelectedIndex = selectedGame.League.Id - 1;
            dp_DateEdit.SelectedDate = selectedGame.Date;
        }

        private void btn_GameResultsOfGame_Click(object sender, RoutedEventArgs e)
        {
            if (gamesDataGrid.SelectedItem != null)
            {
                NavigationService.Navigate(new GameResultsOfGamePage((GameReadDto)gamesDataGrid.SelectedItem));
            }
            else
            {
                MessageBox.Show("Please select a game first", "Error");
            }
        }

        private void btn_ClearFilter_Click(object sender, RoutedEventArgs e)
        {
            dp_DateFilter.SelectedDate = null;
            LoadGames();
        }

        private void tb_GameNrPlan_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = Regex.IsMatch(e.Text, "[^0-9]+");
        }
    }
}
