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
using Tennisclub.Common.MemberFineDTO;

namespace Tennisclub.WPF.MemberFines
{
    /// <summary>
    /// Interaction logic for FinesPage.xaml
    /// </summary>
    public partial class FinesPage : Page
    {
        public FinesPage()
        {
            InitializeComponent();
            LoadFines();
        }
        private async void LoadFines()
        {
            IEnumerable<MemberFineReadDto> memberFines = await HelperAPI.Get<IEnumerable<MemberFineReadDto>>("memberfines");
            finesDataGrid.ItemsSource = memberFines;
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

        private async void btn_CompletePayment_Click(object sender, RoutedEventArgs e)
        {
            if (finesDataGrid.SelectedItem != null)
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
                MessageBox.Show("Please select a fine first", "Error");
            }   
        }

        private async void btn_Filter_Click(object sender, RoutedEventArgs e)
        {
            var handoutDate = dp_HandoutDateFilter.SelectedDate;
            var paymentDate = dp_PaymentDateFilter.SelectedDate;
            IEnumerable<MemberFineReadDto> memberFines = await HelperAPI.Get<IEnumerable<MemberFineReadDto>>($"memberfines/filter?handoutDate={handoutDate}&paymentDate={paymentDate}");
            finesDataGrid.ItemsSource = memberFines;
        }

        private void btn_ClearFilter_Click(object sender, RoutedEventArgs e)
        {
            dp_HandoutDateFilter.SelectedDate = null;
            dp_PaymentDateFilter.SelectedDate = null;
            LoadFines();
        }
    }
}
