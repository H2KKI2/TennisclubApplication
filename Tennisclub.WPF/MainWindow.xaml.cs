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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Tennisclub.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_Member_Click(object sender, RoutedEventArgs e)
        {
            FramePage.Navigate(new System.Uri("Members/MemberPage.xaml",
             UriKind.RelativeOrAbsolute));
        }

        private void btn_Role_Click(object sender, RoutedEventArgs e)
        {
            FramePage.Navigate(new System.Uri("Roles/RolePage.xaml",
             UriKind.RelativeOrAbsolute));
        }

        private void btn_Fine_Click(object sender, RoutedEventArgs e)
        {
            FramePage.Navigate(new System.Uri("MemberFines/FinesPage.xaml",
             UriKind.RelativeOrAbsolute));
        }

        private void btn_Game_Click(object sender, RoutedEventArgs e)
        {
            FramePage.Navigate(new System.Uri("Games/GamesPage.xaml",
             UriKind.RelativeOrAbsolute));
        }

        private void btn_GameResult_Click(object sender, RoutedEventArgs e)
        {
            FramePage.Navigate(new System.Uri("GameResults/GameResultsPage.xaml",
             UriKind.RelativeOrAbsolute));
        }
    }
}
