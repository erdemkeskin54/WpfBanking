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

namespace UC.AccountSelect
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }

        public event EventHandler AccountSelected;

        
        public AccountContract selectedAccountContract
        {
            get
            {
                if (cbEkno.SelectedIndex == -1 && txtCustomerNo.Text=="")
                {
                    return new AccountContract() { };
                }
                return cbEkno.SelectedItem as AccountContract;
            }
        }

        private void GetSuffix(int accountContract)
        {
            var connect = new BOA.Connector.Banking.GenericConnect<AccountResponse>();
            var request = new BOA.Types.Banking.AccountRequest();

            request.accountContract = new AccountContract() {AccountOwnerId=accountContract };
            request.MethodName = "GetAccounts";

            var response = connect.Execute(request);

            if (response.IsSuccess == true)
            {
                cbEkno.ItemsSource = response.accountContracts;
                cbEkno.Items.Refresh();
                cbEkno.SelectedValuePath = "Suffix";
                cbEkno.SelectedIndex = 0;
                return;
            }
            else
            {
                MessageBox.Show("Ek No getirilirken hata oluştu!");
            }
            return;
        }

        private void GetAccount(AccountContract accountContract)
        {
            var connect = new BOA.Connector.Banking.GenericConnect<AccountResponse>();
            var request = new BOA.Types.Banking.AccountRequest();

            request.accountContract = accountContract;
            request.MethodName = "GetAccounts";

            var response = connect.Execute(request);

            if (response.IsSuccess)
            {
                txtBranchName.Text = response.accountContracts[0].branchContract.Name;
                txtCustomerName.Text = response.accountContracts[0].customerDetailContract.Name+" " + response.accountContracts[0].customerDetailContract.SurName;
                txtFECName.Text= response.accountContracts[0].fecContract.Name;
                txtBalance.Text = response.accountContracts[0].Balance.ToString();
                txtAvaibleBalance.Text = response.accountContracts[0].Balance.ToString();
                txtTCNo.Text = response.accountContracts[0].customerDetailContract.TaxNumber;
                txtIBAN.Text = response.accountContracts[0].IBAN;
                GetSuffix(response.accountContracts[0].AccountOwnerId);
                return;
            }
            else
            {
                MessageBox.Show("Müşteri bulunamadı!","Message",MessageBoxButton.OK,MessageBoxImage.Error);
                clearContent();
            }
            return;
        }

        public void clearContent()
        {
            txtCustomerNo.Text = "";
            txtBranchName.Text = "";
            txtCustomerName.Text = "";
            txtFECName.Text = "";
            txtBalance.Text = "";
            txtAvaibleBalance.Text = "";
            txtTCNo.Text = "";
            txtIBAN.Text = "";
            cbEkno.SelectedIndex = -1;
            txtCustomerNo.Focus();
        }

        private void btnSearchCustomer_Click(object sender, RoutedEventArgs e)
        {
            if (txtCustomerNo.Text == "")
            {
                MessageBox.Show("Müşteri no girmediniz.", "Message", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else if (isValidPhone(txtCustomerNo.Text))
            {
                MessageBox.Show("Müşteri sadece rakam içerebilir.", "Message", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            GetAccount(new AccountContract() { AccountOwnerId = Convert.ToInt32(txtCustomerNo.Text) });
        }

        //Validation
        public static bool isValidEmail(string inputEmail)
        {
            string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                  @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                  @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(inputEmail))
                return true;
            else
                return false;
        }
        public static bool isValidPhone(string inputPhone)
        {
            string strRegex = @"^(05(\d{9}))$";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(inputPhone))
                return true;
            else
                return false;
        }
        public static bool isValidText(string inputText)
        {
            string strRegex = @"^\p{L}+$";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(inputText))
                return true;
            else
                return false;
        }
        public static bool isValidNumber(string inputNumber)
        {
            string strRegex = @"^[0-9]*$";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(inputNumber))
                return true;
            else
                return false;
        }

        private void cbEkno_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (AccountSelected != null)
            {
                AccountSelected(this, EventArgs.Empty);
            }
        }
    }
}
