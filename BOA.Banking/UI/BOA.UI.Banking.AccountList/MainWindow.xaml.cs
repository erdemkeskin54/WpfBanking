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
using BOA.Types.Banking;

namespace BOA.UI.Banking.AccountList
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AccountContract _accountContract;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnAccountFilter_Click(object sender, RoutedEventArgs e)
        {
            _accountContract = new AccountContract();

            if (txtAccountCustomerNo.Text == null || txtAccountCustomerNo.Text == "")
            { _accountContract.AccountOwnerId = 0; }
            else { _accountContract.AccountOwnerId = Convert.ToInt32(txtAccountCustomerNo.Text); }

            if (txtAccountSuffix.Text == null || txtAccountSuffix.Text == "")
            { _accountContract.Suffix = 0; }
            else { _accountContract.Suffix = Convert.ToInt32(txtAccountSuffix.Text); }
            if (_accountContract.AccountOwnerId == 0 && _accountContract.Suffix == 0)
            { AccountAll(); return; }

            GetAccounts(_accountContract);
        }

        private void GetAccounts(AccountContract accountContract)
        {
            //tüm hesaplar
            var connect = new Connector.Banking.GenericConnect<AccountResponse>();
            var request = new Types.Banking.AccountRequest();

            request.accountContract = _accountContract;
            request.MethodName = "GetAccounts";

            var response = connect.Execute(request);

            if (response.IsSuccess == true)
            {
                dgAccountListeleme.ItemsSource = response.accountContracts;
                dgAccountListeleme.Items.Refresh();
                return;
            }
            else
            {
                MessageBox.Show("Hesaplar getirilirken hata oluştu!");
            }
            return;
        }

        private void AccountAll()
        {
            //tüm hesaplar
            var connect = new Connector.Banking.GenericConnect<AccountResponse>();
            var request = new Types.Banking.AccountRequest();

            request.MethodName = "AccountAll";

            var response = connect.Execute(request);

            if (response.IsSuccess == true)
            {
                dgAccountListeleme.ItemsSource = response.accountContracts;
                dgAccountListeleme.Items.Refresh();
                return;
            }
            else
            {
                MessageBox.Show("Hesaplar getirilirken hata oluştu!");
            }
            return;
        }

        private void btnClearFilter_Click(object sender, RoutedEventArgs e)
        {
            _accountContract = new AccountContract();
            txtAccountCustomerNo.Text = "";
            txtAccountSuffix.Text = "";
            AccountAll();
        }

        private void btnOpenAccountDetail_Click(object sender, RoutedEventArgs e)
        {

        }

        public event RoutedEventHandler CustomCloseTab;
        private void btnCloseTabAccountList_Click(object sender, RoutedEventArgs e)
        {
            if (CustomCloseTab != null)
            {
                CustomCloseTab(this, new RoutedEventArgs());
            }
            this.Close();
        }




        //Datagrid İşlemler
        private void dgAccountListeleme_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.Column.Header.ToString() == "Id")
            {
                e.Column.Header = "Hesap NO";
            }
            if (e.Column.Header.ToString() == "AccountOwnerId")
            {
                e.Column.Header = "Müşteri No";
            }
            if (e.Column.Header.ToString() == "Suffix")
            {
                e.Column.Header = "Ek No";
            }
            if (e.Column.Header.ToString() == "FECId")
            {
                e.Column.Header = "Döviz Kodu";
            }
            if (e.Column.Header.ToString() == "BranchId")
            {
                e.Column.Header = "Şube Kodu";
            }
            if (e.Column.Header.ToString() == "OpenDate")
            {
                e.Column.Header = "Açılış Tarihi";
            }
            if (e.Column.Header.ToString() == "CloseDate")
            {
                e.Column.Header = "Kapanış Tarihi";
            }
            if (e.Column.Header.ToString() == "ReasonForClosing")
            {
                e.Column.Header = "Kapanış Nedeni";
            }
            if (e.Column.Header.ToString() == "AccountName")
            {
                e.Column.Header = "Hesap Adı";
            }
            if (e.Column.Header.ToString() == "AccountDescription")
            {
                e.Column.Header = "Hesap Açıklaması";
            }
            if (e.Column.Header.ToString() == "SystemDate")
            {
                e.Column.Header = "Sistem Tarihi";
            }
            if (e.Column.Header.ToString() == "Username")
            {
                e.Column.Header = "İşlem Yapan";
            }
            
        }

        private void dgAccountListeleme_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            
            if (dgAccountListeleme.SelectedItem == null) return;
            
            AccountContract selectedAccount = dgAccountListeleme.SelectedItem as AccountContract;
            AccountAdd.MainWindow accountAddWindow = new AccountAdd.MainWindow(selectedAccount);
            accountAddWindow.Show();
            

            // MessageBox.Show(string.Format("The Person you double clicked on is - Id: {0}, Address: {1}, Surname: {2}", selectedPerson.Id, selectedPerson.Name, selectedPerson.SurName));
        }

        private void btnOpenAccountClose_Click(object sender, RoutedEventArgs e)
        {
            if (dgAccountListeleme.SelectedItem == null) 
            {
                MessageBox.Show("Lütfen kapatılacak hesabı seçiniz.","Message",MessageBoxButton.OK,MessageBoxImage.Error);
                return;
            }
            AccountContract selectedAccount = dgAccountListeleme.SelectedItem as AccountContract;

            AccountClose.MainWindow accountAddWindow = new AccountClose.MainWindow(selectedAccount);
            accountAddWindow.Show();
        }
    }
}
