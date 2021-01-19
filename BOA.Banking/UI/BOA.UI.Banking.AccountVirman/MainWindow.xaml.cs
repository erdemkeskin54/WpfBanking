using BOA.Types.Banking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

namespace BOA.UI.Banking.AccountVirman
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //ComboboxCustomer(new CustomerContract());
            comboboxBranch();
            comboboxFEC();
            dpVirmanDate.SelectedDate = DateTime.Now;
        }
       

        private void btnAddVirman_Click(object sender, RoutedEventArgs e)
        {
            if (ucCustomer.selectedComboboxIndex == -1)
            {
                MessageBox.Show("Müşteri boş geçilemez", "Message", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (cbAccountBranch.SelectedIndex == -1)
            {
                MessageBox.Show("Şube seçimi yapılmadı", "Message", MessageBoxButton.OK, MessageBoxImage.Error);
                cbAccountBranch.Focus();
                return;
            }
            if (dgAccountFirst.SelectedItem == null)
            {
                MessageBox.Show("Lütfen paranın çekileceği hesabı seçiniz.", "Message", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (dgAccountSecond.SelectedItem == null)
            {
                MessageBox.Show("Lütfen paranın yatırılacağı hesabı seçiniz..", "Message", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            AccountContract selectedFirstAccount = dgAccountFirst.SelectedItem as AccountContract;
            AccountContract selectedSecondAccount = dgAccountSecond.SelectedItem as AccountContract;
            if (txtVirmanAmount.Text == "")
            {
                MessageBox.Show("Tutar boş geçilemez", "Message", MessageBoxButton.OK, MessageBoxImage.Error);
                txtVirmanAmount.Focus();
                return;
            }
            else if (Convert.ToDecimal(txtVirmanAmount.Text) > selectedFirstAccount.Balance)
            {
                //para çekimi
                MessageBox.Show("Hesapta yeterli bakiye yok.", "Message", MessageBoxButton.OK, MessageBoxImage.Error);
                txtVirmanAmount.Focus();
                return;
            }

            VirmanContract virmanContract = new VirmanContract();

            virmanContract.AccountFirstId = selectedFirstAccount.Id;
            virmanContract.AccountSecondId = selectedSecondAccount.Id;
            virmanContract.Description = txtVirmanDesc.Text;
            virmanContract.Amount = Convert.ToDecimal(txtVirmanAmount.Text);
            virmanContract.Date = dpVirmanDate.SelectedDate.Value;
            AddVirman(virmanContract);
        }

        public event RoutedEventHandler CustomCloseTab;

        private void btnCloseVirmanAdd_Click(object sender, RoutedEventArgs e)
        {
            if (CustomCloseTab != null)
            {
                CustomCloseTab(this, new RoutedEventArgs());
            }
        }

        //Yardımcı Fonksiyonlar
        private void GetAccountsGridFirst(AccountContract accountContract)
        {
            var connect = new Connector.Banking.GenericConnect<AccountResponse>();
            var request = new Types.Banking.AccountRequest();

            request.accountContract = accountContract;
            request.MethodName = "GetAccounts";

            var response = connect.Execute(request);

            if (response.IsSuccess == true)
            {
                dgAccountFirst.ItemsSource = response.accountContracts;
                dgAccountFirst.Items.Refresh();
                return;
            }
            else
            {
                MessageBox.Show("Hesaplar getirilirken hata oluştu!");
            }
            return;
        }
        private void GetAccountsGridSecond(AccountContract accountContract)
        {
            AccountContract selectedAccount = dgAccountFirst.SelectedItem as AccountContract;

            var connect = new Connector.Banking.GenericConnect<AccountResponse>();
            var request = new Types.Banking.AccountRequest();

            request.accountContract = accountContract;
            request.MethodName = "GetAccounts";

            var response = connect.Execute(request);

            if (response.IsSuccess == true)
            {
                dgAccountSecond.ItemsSource = response.accountContracts.Where(x => x.Suffix != selectedAccount.Suffix);
                dgAccountSecond.Items.Refresh();
                return;
            }
            else
            {
                MessageBox.Show("Hesaplar getirilirken hata oluştu!");
            }
            return;
        }
        private void AddVirman(VirmanContract virmanContract)
        {
            var connect = new Connector.Banking.GenericConnect<VirmanResponse>();
            var request = new Types.Banking.VirmanRequest();

            request.virmanContract = virmanContract;
            request.MethodName = "AddVirman";

            var response = connect.Execute(request);

            if (response.IsSuccess == true)
            {
                MessageBox.Show("Virman işlemi başarılı", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            else
            {
                MessageBox.Show("Virman işlemi hatalı", "Message", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }


        //Combobox
        private bool ComboboxCustomer(CustomerContract customer)
        {
            var connect = new Connector.Banking.GenericConnect<CustomerResponse>();
            var request = new Types.Banking.CustomerRequest();

            request.customer = customer;
            request.MethodName = "CustomerAll";

            var response = connect.Execute(request);

            if (response.IsSuccess == true)
            {
                /*
                cbAccountCustomer.ItemsSource = response.customers;
                cbAccountCustomer.DisplayMemberPath = "Name";
                cbAccountCustomer.SelectedValuePath = "Id";
                cbAccountCustomer.Items.Refresh();
                */
            }
            else
            {
                MessageBox.Show("Veriler getirilirken hata oluştu!", "Message", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return false;
        }
        private void comboboxBranch()
        {
            var connect = new Connector.Banking.GenericConnect<BranchResponse>();
            var request = new Types.Banking.BranchRequest();

            request.MethodName = "GetBranches";

            var response = connect.Execute(request);

            if (response.IsSuccess == true)
            {

                cbAccountBranch.ItemsSource = response.branchContracts;

                cbAccountBranch.DisplayMemberPath = "Name";
                cbAccountBranch.SelectedValuePath = "Id";
                cbAccountBranch.Items.Refresh();
                return;
            }
            else
            {
                return;
            }
        }
        private void comboboxFEC()
        {
            var connect = new Connector.Banking.GenericConnect<FECResponse>();
            var request = new Types.Banking.FECRequest();

            request.MethodName = "GetFECs";

            var response = connect.Execute(request);

            if (response.IsSuccess == true)
            {

                cbFEC.ItemsSource = response.FECContracts;

                cbFEC.DisplayMemberPath = "Name";
                cbFEC.SelectedValuePath = "Id";
                cbFEC.Items.Refresh();
                return;
            }
            else
            {
                return;
            }
        }
        private void cbAccountBranch_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ucCustomer.selectedComboboxIndex == -1)
            {
                MessageBox.Show("Hesabı seçmediniz", "Message", MessageBoxButton.OK, MessageBoxImage.Error);
                ucCustomer.selectedComboboxIndex = -1;
                return;
            }

            GetAccountsGridFirst(new AccountContract()
            {
                AccountOwnerId = (int)ucCustomer.customerContract.Id,
                BranchId = (int)cbAccountBranch.SelectedValue
            });



        }


        //Datagrid
        private void dgAccountFirst_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
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
            if (e.Column.Header.ToString() == "Balance")
            {
                e.Column.Header = "Bakiye";
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
        private void dgAccountSecond_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.Column.Header.ToString() == "Id")
            {
                e.Column.Header = "Hesap NO";
            }
            if (e.Column.Header.ToString() == "Balance")
            {
                e.Column.Header = "Bakiye";
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
        private void dgAccountFirst_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgAccountFirst.SelectedIndex == -1)
            {
                dgAccountSecond.ItemsSource = null;
                return;
            }
            AccountContract selectedAccount = dgAccountFirst.SelectedItem as AccountContract;

            GetAccountsGridSecond(new AccountContract()
            {
                AccountOwnerId = (int)selectedAccount.AccountOwnerId,
                BranchId = (int)selectedAccount.BranchId,
                FECId = (int)selectedAccount.FECId
            });
            cbFEC.SelectedValue = selectedAccount.FECId;
        }
        private void dgAccountSecond_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

    }
}
