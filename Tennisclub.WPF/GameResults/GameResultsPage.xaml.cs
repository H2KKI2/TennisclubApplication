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
using Tennisclub.Common.GameResultDTO;

namespace Tennisclub.WPF.GameResults
{
    /// <summary>
    /// Interaction logic for GameResultsPage.xaml
    /// </summary>
    public partial class GameResultsPage : Page
    {
        public GameResultsPage()
        {
            InitializeComponent();
            LoadGameResults();
        }

        private async void LoadGameResults()
        {
            IEnumerable<GameResultReadDto> gameResults = await HelperAPI.Get<IEnumerable<GameResultReadDto>>($"gameresults");
            resultsDataGrid.ItemsSource = gameResults;
        }

        private async void btn_Filter_Click(object sender, RoutedEventArgs e)
        {
            var date = dp_DateFilter.SelectedDate;
            IEnumerable<GameResultReadDto> filteredGameResults = await HelperAPI.Get<IEnumerable<GameResultReadDto>>($"gameresults/filter?date={date}");
            resultsDataGrid.ItemsSource = filteredGameResults;
        }

        private async void btn_EditGameResult_Click(object sender, RoutedEventArgs e)
        {
            if (resultsDataGrid.SelectedItem != null)
            {
                if (!string.IsNullOrWhiteSpace(tb_SetNrEdit.Text) && !string.IsNullOrWhiteSpace(tb_ScoreTeammateEdit.Text) && !string.IsNullOrWhiteSpace(tb_ScoreOpponentEdit.Text))
                {
                    var selectedGameResult = (GameResultReadDto)resultsDataGrid.SelectedItem;
                    GameResultUpdateDto updateGameResult = new GameResultUpdateDto {
                        Id = selectedGameResult.Id,
                        SetNr = byte.Parse(tb_SetNrEdit.Text),
                        ScoreTeamMember = byte.Parse(tb_ScoreTeammateEdit.Text),
                        ScoreOpponent = byte.Parse(tb_ScoreOpponentEdit.Text)
                    };
                    var response = await HelperAPI.Update($"gameresults/{selectedGameResult.Id}", updateGameResult);

                    if (response == null)
                    {
                        LoadGameResults();
                    }
                    else
                    {
                        MessageBox.Show(response.ToString(), "Error");
                    }
                }
                else
                {
                    MessageBox.Show("Please fill in all the fields", "Error");
                }
            }
            else
            {
                MessageBox.Show("Please select a game result first", "Error");
            }
        }
        private void resultsDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedGameResult = (GameResultReadDto)resultsDataGrid.SelectedItem;
            if (selectedGameResult == null)
                return;
   
            tb_SetNrEdit.Text = selectedGameResult.SetNr.ToString();
            tb_ScoreTeammateEdit.Text = selectedGameResult.ScoreTeamMember.ToString();
            tb_ScoreOpponentEdit.Text = selectedGameResult.ScoreOpponent.ToString();

        }

        private void btn_ClearFilter_Click(object sender, RoutedEventArgs e)
        {
            dp_DateFilter.SelectedDate = null;
            LoadGameResults();
        }

        private void tb_SetNrEdit_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = Regex.IsMatch(e.Text, "[^0-9]+");
        }

        private void tb_ScoreTeammateEdit_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = Regex.IsMatch(e.Text, "[^0-9]+");
        }

        private void tb_ScoreOpponentEdit_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = Regex.IsMatch(e.Text, "[^0-9]+");
        }
    }
}
