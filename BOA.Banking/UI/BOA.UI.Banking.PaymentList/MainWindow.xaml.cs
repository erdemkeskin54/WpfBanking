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

namespace BOA.UI.Banking.PaymentList
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        PaymentContract _paymentContract;
        DateTime? _startDate;
        DateTime? _finishDate;
        public MainWindow()
        {
            InitializeComponent();
            comboboxPaymentTypes();
            ComboboxCustomer(new CustomerContract());
        }
        public bool ComboboxCustomer(CustomerContract customer)
        {
            var connect = new Connector.Banking.GenericConnect<CustomerResponse>();
            var request = new Types.Banking.CustomerRequest();

            request.customer = customer;
            request.MethodName = "CustomerAll";

            var response = connect.Execute(request);

            if (response.IsSuccess == true)
            {
                cbPaymentCustomer.ItemsSource = response.customers;
                cbPaymentCustomer.DisplayMemberPath = "Name";
                cbPaymentCustomer.SelectedValuePath = "Id";
                cbPaymentCustomer.Items.Refresh();
            }
            else
            {
                MessageBox.Show("Müşteriler getirilirken hata oluştu!", "Message", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return false;
        }
        private void comboboxPaymentTypes()
        {
            var connect = new Connector.Banking.GenericConnect<PaymentTypesResponse>();
            var request = new Types.Banking.PaymentTypesRequest();

            request.MethodName = "GetPaymentTypes";

            var response = connect.Execute(request);

            if (response.IsSuccess == true)
            {

                cbPaymentType.ItemsSource = response.paymentTypesContracts;

                cbPaymentType.DisplayMemberPath = "Name";
                cbPaymentType.SelectedValuePath = "Id";
                cbPaymentType.Items.Refresh();
                return;
            }
            else
            {
                return;
            }
        }
        private void GetSuffix(AccountContract accountContract)
        {
            var connect = new Connector.Banking.GenericConnect<AccountResponse>();
            var request = new Types.Banking.AccountRequest();

            request.accountContract = accountContract;
            request.MethodName = "GetAccounts";

            var response = connect.Execute(request);

            if (response.IsSuccess == true)
            {
                
                cbPaymentSuffix.ItemsSource = response.accountContracts;
                cbPaymentSuffix.Items.Refresh();

                cbPaymentSuffix.DisplayMemberPath = "Suffix";
                cbPaymentSuffix.SelectedValuePath = "Suffix";
                
                return;
            }
            else
            {
                MessageBox.Show("Hesaplar getirilirken hata oluştu!");
            }
            return;
        }
        private void GetAccount(AccountContract accountContract)
        {
            var connect = new Connector.Banking.GenericConnect<AccountResponse>();
            var request = new Types.Banking.AccountRequest();

            request.accountContract = accountContract;
            request.MethodName = "GetAccounts";

            var response = connect.Execute(request);

            if (response.IsSuccess == true)
            {
                /*
                _accountId = response.accountContracts[0].Id;
                txtIban.Text = response.accountContracts[0].IBAN;
                cbCurrencyCode.SelectedValue = response.accountContracts[0].FECId;
                txtBalance.Text = response.accountContracts[0].Balance.ToString();
                */
                return;
            }
            else
            {
                MessageBox.Show("Hesap getirilirken hata oluştu!");
            }
            return;
        }

        private void GetPayment(PaymentContract paymentContract,DateTime? startDate,DateTime? finishDate)
        {
            var connect = new Connector.Banking.GenericConnect<PaymentResponse>();
            var request = new Types.Banking.PaymentRequest();

            request.paymentContract = paymentContract;
            request.FinishDate = finishDate;
            request.StartDate = startDate;
            request.MethodName = "GetPayment";

            var response = connect.Execute(request);

            if (response.IsSuccess == true)
            {
                dgPaymentListeleme.ItemsSource = response.paymentContracts;
                dgPaymentListeleme.Items.Refresh();
                return;
                
            }
            else
            {
                MessageBox.Show("Hesap getirilirken hata oluştu.", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
                
            }
        }


        private void btnClearFilter_Click(object sender, RoutedEventArgs e)
        {
            _paymentContract = new PaymentContract();
            _startDate = new DateTime();
            _finishDate = new DateTime();
            cbPaymentCustomer.SelectedIndex = -1;
            cbPaymentSuffix.SelectedIndex = -1;
            cbPaymentType.SelectedIndex = -1;
            dpPaymentFinishDate.SelectedDate = null;
            dpPaymentStartDate.SelectedDate = null;

            GetPayment(_paymentContract, null, null);
        }
        private void btnPaymentFilter_Click(object sender, RoutedEventArgs e)
        {
            _paymentContract = new PaymentContract();
            _startDate = new DateTime();
            _finishDate = new DateTime();
            if (cbPaymentCustomer.SelectedIndex == -1){ _paymentContract.AccountOwnerId = 0;  }
            else { _paymentContract.AccountOwnerId = (int)cbPaymentCustomer.SelectedValue; }

            if (cbPaymentSuffix.SelectedIndex == -1){ _paymentContract.Suffix = 0; }
            else { _paymentContract.Suffix = (int)cbPaymentSuffix.SelectedValue; }

            if (cbPaymentType.SelectedIndex == -1) { _paymentContract.Type = 0; }
            else { _paymentContract.Type = (int)cbPaymentType.SelectedValue; }

            if (dpPaymentStartDate.SelectedDate == null) { _startDate = null; }
            else { _startDate = dpPaymentStartDate.SelectedDate; }

            if (dpPaymentFinishDate.SelectedDate == null) { _finishDate = null; }
            else { _finishDate = dpPaymentFinishDate.SelectedDate; }

            GetPayment(_paymentContract, _startDate, _finishDate);

        }
        public event RoutedEventHandler CustomCloseTab;

        private void btnCloseTabPaymentList_Click(object sender, RoutedEventArgs e)
        {
            if (CustomCloseTab != null)
            {
                CustomCloseTab(this, new RoutedEventArgs());
            }
            this.Close();
        }
        private void dgPaymentListeleme_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.Column.Header.ToString() == "Id")
            {
                e.Column.Header = "Id";
            }
            if (e.Column.Header.ToString() == "AccountOwnerId")
            {
                e.Column.Header = "Müşteri No";
            }
            if (e.Column.Header.ToString() == "AccountId")
            {
                e.Column.Header = "Hesap No";
            }
            if (e.Column.Header.ToString() == "Suffix")
            {
                e.Column.Header = "Ek NO";
            }
            if (e.Column.Header.ToString() == "TransactionDate")
            {
                e.Column.Header = "Tarih";
            }
            if (e.Column.Header.ToString() == "Description")
            {
                e.Column.Header = "Açıklama";
            }
            if (e.Column.Header.ToString() == "Amount")
            {
                e.Column.Header = "Tutar";
            }
            if (e.Column.Header.ToString() == "Type")
            {
                e.Column.Header = "İşlem Tipi";
            }

        }

        private void dgPaymentListeleme_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void cbPaymentCustomer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbPaymentCustomer.SelectedIndex==-1)
            {
                return;
            }
            GetSuffix(new AccountContract() { AccountOwnerId = (int)cbPaymentCustomer.SelectedValue });
        }

        private void cbPaymentSuffix_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
