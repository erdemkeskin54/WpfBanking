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

namespace BOA.UI.Banking.AccountAdd
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int _customerId;
        public AccountContract _accountContract;
        public int suffix;
        public int _accountId;
        public MainWindow(AccountContract accountContract)
        {
            
            _accountContract = accountContract;
            _accountId = accountContract.Id;

            InitializeComponent();

            comboboxFEC();
            comboboxBranch();
            dpOpenDate.SelectedDate = DateTime.Now;

            if (_accountId == 0 || _accountContract == null)
            {
                //yenikayıt
                ucCustomer.cbIsEnable = true;
            }
            else
            {
                //Kayıt güncelleme
                ucCustomer.cbIsEnable = false;
                
            }
            
        }
        private void Window_ContentRendered(object sender, EventArgs e)
        {
            FillAccount(_accountContract);
        }

        private void btnAccountAdd_Click(object sender, RoutedEventArgs e)
        {
            //if ( Convert.ToInt32(txtAccountSuffix.Text) == suffix && txtAccountSuffix.IsEnabled)

            if (_accountId == 0)
            {
                //yeni hesap
                if (ucCustomer.selectedComboboxIndex == -1)
                {
                    MessageBox.Show("Müşteri boş geçilemez", "Message", MessageBoxButton.OK, MessageBoxImage.Error);
                    ucCustomer.Focus();
                    return;
                }
                if (cbCurrencyCode.SelectedIndex == -1)
                {
                    MessageBox.Show("Döviz kodu seçilmedi", "Message", MessageBoxButton.OK, MessageBoxImage.Error);
                    cbCurrencyCode.Focus();
                    return;
                }
                if (txtAccountName.Text != "" && !isValidText(txtAccountName.Text))
                {
                    MessageBox.Show("Hesap adı yanlış karakterler içeriyor", "Message", MessageBoxButton.OK, MessageBoxImage.Error);
                    txtAccountName.Focus();
                    return;
                }
                if (cbAccounBranchCode.SelectedIndex == -1)
                {
                    MessageBox.Show("Şube seçimi yapılmadı", "Message", MessageBoxButton.OK, MessageBoxImage.Error);
                    cbAccounBranchCode.Focus();
                    return;
                }
                if (txtAccountSuffix.Text == "")
                {
                    MessageBox.Show("Ek no boş geçilemez", "Message", MessageBoxButton.OK, MessageBoxImage.Error);
                    txtAccountSuffix.Focus();
                    return;
                }
                else if (!isValidNumber(txtAccountSuffix.Text))
                {
                    MessageBox.Show("Ek no sadece rakamlardan oluşabilir", "Message", MessageBoxButton.OK, MessageBoxImage.Error);
                    txtAccountSuffix.Focus();
                    return;
                }
                if (Convert.ToInt32(txtAccountSuffix.Text) < suffix && Convert.ToInt32(cbCurrencyCode.SelectedValue) == 1)
                {
                    MessageBox.Show("TL hesabı için sıradaki Ek no:" + suffix, "Message", MessageBoxButton.OK, MessageBoxImage.Error);
                    txtAccountSuffix.Focus();
                    return;
                }
                else if (Convert.ToInt32(txtAccountSuffix.Text) < suffix && Convert.ToInt32(cbCurrencyCode.SelectedValue) == 2)
                {
                    MessageBox.Show("Dolar hesabı için sıradaki Ek no:" + suffix, "Message", MessageBoxButton.OK, MessageBoxImage.Error);
                    txtAccountSuffix.Focus();
                    return;
                }
                if (txtAccountIBAN.Text == "")
                {
                    MessageBox.Show("IBAN boş geçilemez", "Message", MessageBoxButton.OK, MessageBoxImage.Error);
                    txtAccountSuffix.Focus();
                    return;
                }
                else if (!isValidNumberAndText(txtAccountIBAN.Text))
                {
                    MessageBox.Show("IBAN özel karakter ve boşluk içeremez.", "Message", MessageBoxButton.OK, MessageBoxImage.Error);
                    txtAccountIBAN.Focus();
                    return;
                }
                if (dpOpenDate.SelectedDate == null)
                {
                    MessageBox.Show("Açılış tarihi boş geçilemez", "Message", MessageBoxButton.OK, MessageBoxImage.Error);
                    dpOpenDate.Focus();
                    return;
                }

                _accountContract = new AccountContract();
                _accountContract.AccountOwnerId = (int)ucCustomer.customerContract.Id;
                _accountContract.Suffix = Convert.ToInt32(txtAccountSuffix.Text);
                _accountContract.FECId = Convert.ToInt32(cbCurrencyCode.SelectedValue);
                _accountContract.BranchId = Convert.ToInt32(cbAccounBranchCode.SelectedValue);
                _accountContract.OpenDate = dpOpenDate.SelectedDate.Value;
                if (dpClosureDate.SelectedDate != null)
                    _accountContract.CloseDate = dpClosureDate.SelectedDate.Value;
                _accountContract.ReasonForClosing = txtAccountReasonForClosing.Text;
                _accountContract.IBAN = txtAccountIBAN.Text;
                _accountContract.AccountName = txtAccountName.Text;
                _accountContract.AccountDescription = txtAccountDesc.Text;
                _accountContract.Username = (int)ucCustomer.customerContract.Id;
                AddAccount(_accountContract);
                this.Close();
            }
            else
            {
                //hesap güncelleme
                if (ucCustomer.selectedComboboxIndex == -1)
                {
                    MessageBox.Show("Müşteri boş geçilemez", "Message", MessageBoxButton.OK, MessageBoxImage.Error);
                    ucCustomer.Focus();
                    return;
                }
                if (cbCurrencyCode.SelectedIndex == -1)
                {
                    MessageBox.Show("Döviz kodu seçilmedi", "Message", MessageBoxButton.OK, MessageBoxImage.Error);
                    cbCurrencyCode.Focus();
                    return;
                }
                if (txtAccountName.Text != "" && !isValidText(txtAccountName.Text))
                {
                    MessageBox.Show("Hesap adı yanlış karakterler içeriyor", "Message", MessageBoxButton.OK, MessageBoxImage.Error);
                    txtAccountName.Focus();
                    return;
                }
                if (cbAccounBranchCode.SelectedIndex == -1)
                {
                    MessageBox.Show("Şube seçimi yapılmadı", "Message", MessageBoxButton.OK, MessageBoxImage.Error);
                    cbAccounBranchCode.Focus();
                    return;
                }
                if (txtAccountSuffix.Text == "")
                {
                    MessageBox.Show("Ek no boş geçilemez", "Message", MessageBoxButton.OK, MessageBoxImage.Error);
                    txtAccountSuffix.Focus();
                    return;
                }
                else if (!isValidNumber(txtAccountSuffix.Text))
                {
                    MessageBox.Show("Ek no sadece rakamlardan oluşabilir", "Message", MessageBoxButton.OK, MessageBoxImage.Error);
                    txtAccountSuffix.Focus();
                    return;
                }
                if (Convert.ToInt32(txtAccountSuffix.Text) < suffix && Convert.ToInt32(cbCurrencyCode.SelectedValue) == 1)
                {
                    MessageBox.Show("TL hesabı için sıradaki Ek no:" + suffix, "Message", MessageBoxButton.OK, MessageBoxImage.Error);
                    txtAccountSuffix.Focus();
                    return;
                }
                else if (Convert.ToInt32(txtAccountSuffix.Text) < suffix && Convert.ToInt32(cbCurrencyCode.SelectedValue) == 2)
                {
                    MessageBox.Show("Dolar hesabı için sıradaki Ek no:" + suffix, "Message", MessageBoxButton.OK, MessageBoxImage.Error);
                    txtAccountSuffix.Focus();
                    return;
                }
                if (txtAccountIBAN.Text == "")
                {
                    MessageBox.Show("IBAN boş geçilemez", "Message", MessageBoxButton.OK, MessageBoxImage.Error);
                    txtAccountSuffix.Focus();
                    return;
                }
                else if (!isValidNumberAndText(txtAccountIBAN.Text))
                {
                    MessageBox.Show("IBAN özel karakter ve boşluk içeremez.", "Message", MessageBoxButton.OK, MessageBoxImage.Error);
                    txtAccountIBAN.Focus();
                    return;
                }
                if (dpOpenDate.SelectedDate == null)
                {
                    MessageBox.Show("Açılış tarihi boş geçilemez", "Message", MessageBoxButton.OK, MessageBoxImage.Error);
                    dpOpenDate.Focus();
                    return;
                }

                _accountContract = new AccountContract();
                _accountContract.Id = _accountId;
                _accountContract.AccountOwnerId = (int)ucCustomer.customerContract.Id;
                _accountContract.Suffix = Convert.ToInt32(txtAccountSuffix.Text);
                _accountContract.FECId = Convert.ToInt32(cbCurrencyCode.SelectedValue);
                _accountContract.BranchId = Convert.ToInt32(cbAccounBranchCode.SelectedValue);
                _accountContract.OpenDate = dpOpenDate.SelectedDate.Value;
                if (dpClosureDate.SelectedDate != null)
                    _accountContract.CloseDate = dpClosureDate.SelectedDate.Value;
                _accountContract.ReasonForClosing = txtAccountReasonForClosing.Text;
                _accountContract.IBAN = txtAccountIBAN.Text;
                _accountContract.AccountName = txtAccountName.Text;
                _accountContract.AccountDescription = txtAccountDesc.Text;
                _accountContract.Username = (int)ucCustomer.customerContract.Id;

                UpdateAccount(_accountContract);
                this.Close();
            }



        }
        private void DeleteAccount(AccountContract accountContract)
        {
            var connect = new Connector.Banking.GenericConnect<AccountResponse>();
            var request = new Types.Banking.AccountRequest();

            request.accountContract = accountContract;
            request.MethodName = "DeleteAccount";

            var response = connect.Execute(request);

            if (response.IsSuccess == true)
            {
                MessageBox.Show("Hesap başarıyla silindi.", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
                return;

            }
            else
            {
                MessageBox.Show("Hesap silinirken hata oluştu!", "Message", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }
        private void UpdateAccount(AccountContract accountContract)
        {
            var connect = new Connector.Banking.GenericConnect<AccountResponse>();
            var request = new Types.Banking.AccountRequest();

            request.accountContract = accountContract;
            request.MethodName = "UpdateAccount";

            var response = connect.Execute(request);

            if (response.IsSuccess == true)
            {
                MessageBox.Show("Hesap başarıyla güncellendi.", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
                return;

            }
            else
            {
                MessageBox.Show("Hesap güncellenirken hata oluştu.", "Message", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }

        private void AddAccount(AccountContract accountContract)
        {
            var connect = new Connector.Banking.GenericConnect<AccountResponse>();
            var request = new Types.Banking.AccountRequest();

            request.accountContract = accountContract;
            request.MethodName = "AddAccount";

            var response = connect.Execute(request);

            if (response.IsSuccess == true)
            {
                MessageBox.Show("Hesap başarıyla oluşturuldu.", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
                return;

            }
            else
            {
                MessageBox.Show("Hesap oluşturulamadı", "Message", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }

        private void GetAccountLastSuffixNumber(AccountContract accountContract)
        {
            var connect = new Connector.Banking.GenericConnect<AccountResponse>();
            var request = new Types.Banking.AccountRequest();

            request.accountContract = accountContract;
            request.MethodName = "GetAccountLastSuffixNumber";

            var response = connect.Execute(request);
            suffix = response.suffix;

            if (accountContract.FECId == 1)
            {
                suffix = suffix + 1;
                return;
            }
            else if (suffix == 0 && accountContract.FECId == 2)
            {
                suffix = 200;
                return;
            }
            else if (accountContract.FECId == 2)
            {
                suffix = response.suffix + 1;
                return;
            }



        }
        public bool GetAccount(AccountContract accountContract)
        {
            var connect = new Connector.Banking.GenericConnect<AccountResponse>();
            var request = new Types.Banking.AccountRequest();

            request.accountContract = accountContract;
            request.MethodName = "GetAccount";

            var response = connect.Execute(request);

            if (response.IsSuccess == true)
            {
                ucCustomer.selectedComboboxValue = accountContract.AccountOwnerId;
                txtAccountSuffix.Text = response.accountContract.Suffix.ToString();
                cbCurrencyCode.SelectedValue = response.accountContract.FECId;
                cbAccounBranchCode.SelectedValue = response.accountContract.BranchId;
                dpOpenDate.SelectedDate = response.accountContract.OpenDate;
                if (response.accountContract.CloseDate != null)
                    dpClosureDate.SelectedDate = response.accountContract.CloseDate;
                txtAccountReasonForClosing.Text = response.accountContract.ReasonForClosing;
                txtAccountIBAN.Text = response.accountContract.IBAN;
                txtAccountName.Text = response.accountContract.AccountName;
                txtAccountDesc.Text = response.accountContract.AccountDescription;
                return true;
            }
            else
            {
                return false;
            }

        }

        public void FillAccount(AccountContract accountContract)
        {
            ucCustomer.selectedComboboxValue = accountContract.AccountOwnerId;
            txtAccountSuffix.Text = accountContract.Suffix.ToString();
            cbCurrencyCode.SelectedValue = accountContract.FECId;
            cbAccounBranchCode.SelectedValue = accountContract.BranchId;
            dpOpenDate.SelectedDate = accountContract.OpenDate;
            if (accountContract.CloseDate != null)
                dpClosureDate.SelectedDate = accountContract.CloseDate;
            txtAccountReasonForClosing.Text = accountContract.ReasonForClosing;
            txtAccountIBAN.Text = accountContract.IBAN;
            txtAccountName.Text = accountContract.AccountName;
            txtAccountDesc.Text = accountContract.AccountDescription;
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
                /* özelleştirmek için böyle yapılabilir
                foreach (var item in response.customers)
                {
                    cbAccountAddCustomer.Items.Add(item.Id + " - " + item.Name + " " + item.SurName);
                    customerContracts.Add(item);
                }
                cbAccountAddCustomer.SelectedValuePath = "Id";
                cbAccountAddCustomer.Items.Refresh();
                return true;
                */

                /*
                cbAccountAddCustomer.ItemsSource = response.customers;
                cbAccountAddCustomer.DisplayMemberPath = "Id";
                cbAccountAddCustomer.SelectedValuePath = "Id";
                cbAccountAddCustomer.Items.Refresh();
                */

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
                return;
            }
            else
            {
                return;
            }
        }
        private void comboboxBranch()
        {
            var connect = new Connector.Banking.GenericConnect<BranchResponse>();
            var request = new Types.Banking.BranchRequest();

            request.MethodName = "GetBranches";

            var response = connect.Execute(request);

            if (response.IsSuccess == true)
            {

                cbAccounBranchCode.ItemsSource = response.branchContracts;

                cbAccounBranchCode.DisplayMemberPath = "Name";
                cbAccounBranchCode.SelectedValuePath = "Id";
                cbAccounBranchCode.Items.Refresh();
                return;
            }
            else
            {
                return;
            }
        }

        private void btnAccountDelete_Click(object sender, RoutedEventArgs e)
        {
            if (_accountId != 0)
            {
                DeleteAccount(new AccountContract() { Id = _accountId });
                this.Close();
            }
        }

        private void btnCloseAccountAdd_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void cbAccountAddCustomer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // customerContracts[cbAccountAddCustomer.SelectedIndex].Id
            // MessageBox.Show("secilenid :" + customerContracts[cbAccountAddCustomer.SelectedIndex].Id, "Message", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        private void cbCurrencyCode_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // MessageBox.Show("secilenid :" + cbCurrencyCode.SelectedValue, "Message", MessageBoxButton.OK, MessageBoxImage.Error);
            if (ucCustomer.selectedComboboxIndex == -1)
            { MessageBox.Show("Lütfen işlem yapılacak hesabı seçiniz", "Message", MessageBoxButton.OK, MessageBoxImage.Error); return; }

            _accountContract = new AccountContract();
            _accountContract.AccountOwnerId = (int)ucCustomer.customerContract.Id;
            _accountContract.FECId = Convert.ToInt32(cbCurrencyCode.SelectedValue);
            GetAccountLastSuffixNumber(_accountContract);
        }

        private void txtAccountSuffix_LostFocus(object sender, RoutedEventArgs e)
        {

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
        public static bool isValidNumberAndText(string inputNumber)
        {
            string strRegex = @"^[a-zA-Z0-9]*$";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(inputNumber))
                return true;
            else
                return false;
        }

      

        

        //-----------------------------------------------------------------------------------
    }
}
