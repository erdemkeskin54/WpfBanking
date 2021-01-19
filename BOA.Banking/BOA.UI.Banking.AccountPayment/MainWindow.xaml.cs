using BOA.Types.Banking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace BOA.UI.Banking.AccountPayment
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<AccountContract> _accountContracts;
        int _accountId;
        int _paymentType;
        public MainWindow(int paymentType)
        {
            InitializeComponent();
            _paymentType = paymentType;
            dpPaymentDate.SelectedDate = DateTime.Now;
            cbAccountSuffix.IsEnabled = false;
            comboboxFEC();
            ComboboxCustomer(new CustomerContract());
            
        }
        private void cbAccountCustomer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbAccountCustomer.SelectedIndex == -1)
            { MessageBox.Show("Lütfen işlem yapılacak hesabı seçiniz", "Message", MessageBoxButton.OK, MessageBoxImage.Error); return; }

            GetSuffix(new AccountContract() { AccountOwnerId = (int)cbAccountCustomer.SelectedValue });
        }
        private void cbAccountSuffix_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbAccountCustomer.SelectedIndex == -1)
            { MessageBox.Show("Lütfen işlem yapılacak hesabı seçiniz", "Message", MessageBoxButton.OK, MessageBoxImage.Error); return; }
            GetAccount(new AccountContract() { AccountOwnerId = (int)cbAccountCustomer.SelectedValue,Suffix=(int)cbAccountSuffix.SelectedValue });
        }

        private void btnAddPayment_Click(object sender, RoutedEventArgs e)
        {
            if (cbAccountCustomer.SelectedIndex == -1)
            {
                MessageBox.Show("Müşteri boş geçilemez", "Message", MessageBoxButton.OK, MessageBoxImage.Error);
                cbAccountCustomer.Focus();
                return;
            }
            if (cbAccountSuffix.SelectedIndex == -1)
            {
                MessageBox.Show("Ek no seçimi yapılmadı", "Message", MessageBoxButton.OK, MessageBoxImage.Error);
                cbAccountSuffix.Focus();
                return;
            }

            if (txtAmount.Text == "")
            {
                MessageBox.Show("Tutar boş geçilemez", "Message", MessageBoxButton.OK, MessageBoxImage.Error);
                txtAmount.Focus();
                return;
            }
            else if (_paymentType==2 && Convert.ToDecimal(txtAmount.Text) > Convert.ToDecimal(txtBalance.Text))
            {
                //para çekimi
                MessageBox.Show("Hesabınızda yeterli bakiye yok.", "Message", MessageBoxButton.OK, MessageBoxImage.Error);
                txtAmount.Focus();
                return;
            }

            
            PaymentContract paymentContract = new PaymentContract();
            paymentContract.AccountId = _accountId;
            paymentContract.AccountOwnerId = (int)cbAccountCustomer.SelectedValue;
            paymentContract.Suffix = (int)cbAccountSuffix.SelectedValue;
            paymentContract.TransactionDate = dpPaymentDate.SelectedDate.Value;
            paymentContract.Description = txtAccountDesc.Text;
            paymentContract.Amount = Convert.ToDecimal(txtAmount.Text);
            paymentContract.Type = _paymentType;
            AddPayment(paymentContract);
        }

        private void AddPayment(PaymentContract paymentContract)
        {
            var connect = new Connector.Banking.GenericConnect<PaymentResponse>();
            var request = new Types.Banking.PaymentRequest();

            request.paymentContract = paymentContract;
            request.MethodName = "AddPayment";

            var response = connect.Execute(request);

            if (response.IsSuccess == true)
            {
                if (_paymentType==1)
                {
                    MessageBox.Show("Para hesaba eklendi.", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                else if (_paymentType == 2)
                {
                    MessageBox.Show("Hesaptan para çekildi.", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
            }
            else
            {
                if (_paymentType == 1)
                {
                    MessageBox.Show("Para hesaba eklenmedi.", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                else if (_paymentType == 2)
                {
                    MessageBox.Show("Hesaptan para çekilmedi.", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
            }
        }
        public event RoutedEventHandler CustomCloseTab;

        private void btnClosePaymentAdd_Click(object sender, RoutedEventArgs e)
        {
            if (CustomCloseTab != null)
            {
                CustomCloseTab(this, new RoutedEventArgs());
            }
            this.Close();
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
                cbAccountCustomer.ItemsSource = response.customers;
                cbAccountCustomer.DisplayMemberPath = "Name";
                cbAccountCustomer.SelectedValuePath = "Id";
                cbAccountCustomer.Items.Refresh();
            }
            else
            {
                MessageBox.Show("Veriler getirilirken hata oluştu!", "Message", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return false;
        }
        private void comboboxFEC()
        {
            var connect = new Connector.Banking.GenericConnect<FECResponse>();
            var request = new Types.Banking.FECRequest();

            request.MethodName = "GetFECs";

            var response = connect.Execute(request);

            if (response.IsSuccess == true)
            {

                cbCurrencyCode.ItemsSource = response.FECContracts;
                
                cbCurrencyCode.DisplayMemberPath = "Name";
                cbCurrencyCode.SelectedValuePath = "Id";
                cbCurrencyCode.Items.Refresh();
                cbCurrencyCode.SelectedValue = cbAccountSuffix.SelectedIndex;
                return;
            }
            else
            {
                return;
            }
        }
        private void GetSuffix(AccountContract accountContract)
        {
            //tüm hesaplar
            var connect = new Connector.Banking.GenericConnect<AccountResponse>();
            var request = new Types.Banking.AccountRequest();

            request.accountContract = accountContract;
            request.MethodName = "GetAccounts";

            var response = connect.Execute(request);

            if (response.IsSuccess == true)
            {
                _accountContracts = response.accountContracts;

                cbAccountSuffix.ItemsSource = response.accountContracts;
                cbAccountSuffix.Items.Refresh();

                cbAccountSuffix.DisplayMemberPath = "Suffix";
                cbAccountSuffix.SelectedValuePath = "Suffix";
                cbAccountSuffix.IsEnabled = true;

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
                _accountId = response.accountContracts[0].Id;
                txtIban.Text = response.accountContracts[0].IBAN;
                cbCurrencyCode.SelectedValue = response.accountContracts[0].FECId;
                txtBalance.Text = response.accountContracts[0].Balance.ToString();
                return;
            }
            else
            {
                MessageBox.Show("Hesap getirilirken hata oluştu!");
            }
            return;
        }



        //Validation
        public static bool isValidMoney(string inputNumber)
        {
            string strRegex = @"^(\d{0,6})(\.\d{1,2})?$";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(inputNumber))
                return true;
            else
                return false;
        }
        //-----------------------------------------------------------------------------------

    }
}
