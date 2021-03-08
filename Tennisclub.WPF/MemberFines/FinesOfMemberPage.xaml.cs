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
using Tennisclub.Common.MemberDTO;
using Tennisclub.Common.MemberFineDTO;

namespace Tennisclub.WPF.MemberFines
{
    /// <summary>
    /// Interaction logic for FinesOfMemberPage.xaml
    /// </summary>
    public partial class FinesOfMemberPage : Page
    {
        MemberReadDto SelectedMember { get; set; }
        public FinesOfMemberPage(MemberReadDto selectedMember)
        {
            InitializeComponent();
            SelectedMember = selectedMember;
            LoadTitle();
            LoadFines();
        }
        private void LoadTitle()
        {
            tb_TitleMember.Text = $"{SelectedMember.FirstName} {SelectedMember.LastName}";
        }
        private async void LoadFines()
        {
            IEnumerable<MemberFineReadDto> memberFines = await HelperAPI.Get<IEnumerable<MemberFineReadDto>>($"memberfines/finesofmember/{SelectedMember.Id}");
            finesDataGrid.ItemsSource = memberFines;
        }

        private async void btn_Filter_Click(object sender, RoutedEventArgs e)
        {
            var handoutDate = dp_HandoutDateFilter.SelectedDate;
            var paymentDate = dp_PaymentDateFilter.SelectedDate;
            IEnumerable<MemberFineReadDto> memberFines = await HelperAPI.Get<IEnumerable<MemberFineReadDto>>($"memberfines/filter?handoutDate={handoutDate}&paymentDate={paymentDate}");
            finesDataGrid.ItemsSource = memberFines;
        }

        private async void btn_CompletePayment_Click(object sender, RoutedEventArgs e)
        {
            if (finesDataGrid.SelectedItem != null)
            {
                if (dp_PaymentDate.SelectedDate != null)
                {
                    MemberFineReadDto selectedFine = (MemberFineReadDto)finesDataGrid.SelectedItem;
                    MemberFineUpdateDto completedFine = new MemberFineUpdateDto {
                        Id = selectedFine.Id,
                        PaymentDate = (DateTime)dp_PaymentDate.SelectedDate
                    };
                    var response = await HelperAPI.Update($"memberfines/{completedFine.Id}", completedFine);

                    if (response == null)
                    {
                        btn_CompletePayment.IsEnabled = false;
                        dp_PaymentDate.IsEnabled = false;
                        LoadFines();
                    }
                    else
                    {
                        MessageBox.Show(response.ToString(), "Error");
                    }
                }
                else
                {
                    MessageBox.Show("Please select a payment date", "Error");
                } 
            }
            else
            {
                MessageBox.Show("Please select a fine first", "Error");
            }
            
        }

        private async void btn_AddFine_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(tb_FineNumberAddFine.Text)  && !string.IsNullOrWhiteSpace(tb_AmountAddFine.Text) && dp_HandoutDateAddFine.SelectedDate != null)
            {
                MemberFineCreateDto newFine = new MemberFineCreateDto {
                    MemberId = SelectedMember.Id,
                    FineNumber = int.Parse(tb_FineNumberAddFine.Text),
                    Amount = decimal.Parse(tb_AmountAddFine.Text),
                    HandoutDate = (DateTime)dp_HandoutDateAddFine.SelectedDate,
                    PaymentDate = dp_PaymentDateAddFine.SelectedDate
                };
                var response = await HelperAPI.Post<MemberFineCreateDto>("memberfines/new", newFine);

                if (response == null)
                {
                    LoadFines();
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
        private void btn_ShowCompletePaymentMenu_Click(object sender, RoutedEventArgs e)
        {
            AddFineMenu.Visibility = Visibility.Hidden;
            CompletePaymentMenu.Visibility = Visibility.Visible;
        }
        private void btn_ShowAddFineMenu_Click(object sender, RoutedEventArgs e)
        {
            CompletePaymentMenu.Visibility = Visibility.Hidden;
            AddFineMenu.Visibility = Visibility.Visible;
        }

        private void FinesDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MemberFineReadDto selectedFine = (MemberFineReadDto)finesDataGrid.SelectedItem;
            if (selectedFine == null)
                return;

            if (selectedFine.PaymentDate != null)
            {
                btn_CompletePayment.IsEnabled = false;
                dp_PaymentDate.IsEnabled = false;
            }
            else
            {
                dp_PaymentDate.IsEnabled = true;
                btn_CompletePayment.IsEnabled = true;
            }
        }

        private void btn_ClearFilter_Click(object sender, RoutedEventArgs e)
        {
            dp_HandoutDateFilter.SelectedDate = null;
            dp_PaymentDateFilter.SelectedDate = null;
            LoadFines();
        }

        private void TextBlock_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = Regex.IsMatch(e.Text, "[^0-9]+");
        }
    }
}
