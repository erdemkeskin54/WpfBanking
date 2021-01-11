using BOA.Types.Banking;
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

namespace BOA.UI.Banking.AccountClose
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AccountContract _accountContract;
        public MainWindow(AccountContract accountContract)
        {
            InitializeComponent();
            _accountContract = accountContract;
            dpCloseDate.SelectedDate = DateTime.Now;
        }

        private void btnSaveAccountCloseInfo_Click(object sender, RoutedEventArgs e)
        {
            if (dpCloseDate.SelectedDate == null)
            {
                MessageBox.Show("Kapanış tarihi boş geçilemez", "Message", MessageBoxButton.OK, MessageBoxImage.Error);
                dpCloseDate.Focus();
                return;
            }
            _accountContract.ReasonForClosing = txtReasonForClose.Text;
            _accountContract.CloseDate = dpCloseDate.SelectedDate;
            UpdateAccount(_accountContract);
            this.Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void UpdateAccount(AccountContract accountContract)
        {
            var connect = new Connector.Banking.Connect();
            var request = new Types.Banking.AccountRequest();

            request.accountContract = accountContract;
            request.MethodName = "UpdateAccount";

            var response = connect.ExecuteAccount(request);

            if (response.IsSuccess == true)
            {
                MessageBox.Show("Hesap Kapatıldı.", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
                return;

            }
            else
            {
                MessageBox.Show("Hesap kapatılırken hata oluştu.", "Message", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }
    }
}
