using BOA.Types.Banking;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
using System.Windows.Shapes;


namespace BOA.UI.Banking.CustomerList
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class CustomerList : Window
    {
        
        CustomerContract customer;
        public CustomerList()
        {
            InitializeComponent();
        }

        private void btnFiltreleme_Click(object sender, RoutedEventArgs e)
        {
            customer = new CustomerContract();
            if (txtCustomerNo.Text == null || txtCustomerNo.Text == "")
            { customer.Id = null; }
            else { customer.Id = Convert.ToInt32(txtCustomerNo.Text); }
            
            if (txtCustomerName.Text == null || txtCustomerName.Text == "")
            { customer.Name = null; }
            else { customer.Name = txtCustomerName.Text; }

            if (txtCustomerSurName.Text == null || txtCustomerSurName.Text == "")
            { customer.SurName = null; }
            else { customer.SurName = txtCustomerSurName.Text; }

            if (txtCustomerTaxNumber.Text == null || txtCustomerTaxNumber.Text == "")
            { customer.TaxNumber = null; }
            else { customer.TaxNumber = txtCustomerTaxNumber.Text; }

            if(customer.Id == null && customer.TaxNumber == null && customer.Name==null && customer.SurName==null)
            { customer = null;CustomerAll(customer);return; }

            verileriGetir(customer);
        }
        public bool verileriGetir(CustomerContract customer)
        {
            var connect = new Connector.Banking.Connect();
            var request = new Types.Banking.CustomerRequest();

            request.customer = customer;
            request.MethodName = "GetCustomers";

            var response = connect.ExecuteCustomer(request);

            if (response.IsSuccess == true)
            {
                dgPortalMusteriListeleme.ItemsSource = response.customers;
                dgPortalMusteriListeleme.Items.Refresh();
                return true;
            }
            else
            {
                MessageBox.Show("Veriler getirilirken hata oluştu!");
            }
            return false;
        }

        public bool CustomerAll(CustomerContract customer)
        {
            var connect = new Connector.Banking.Connect();
            var request = new Types.Banking.CustomerRequest();

            request.customer = customer;
            request.MethodName = "CustomerAll";

            var response = connect.ExecuteCustomer(request);

            if (response.IsSuccess == true)
            {
                dgPortalMusteriListeleme.ItemsSource = response.customers;
                dgPortalMusteriListeleme.Items.Refresh();
                return true;
            }
            else
            {
                MessageBox.Show("Veriler getirilirken hata oluştu!");
            }
            return false;
        }

        private void btnClearFilter_Click(object sender, RoutedEventArgs e)
        {
            customer = new CustomerContract();
            txtCustomerName.Text = "";
            txtCustomerSurName.Text = "";
            txtCustomerNo.Text = "";
            txtCustomerTaxNumber.Text = "";
            CustomerAll(customer);
        }

        private void btnOpenCustomerDetail_Click(object sender, RoutedEventArgs e)
        {

        }

        private void dgPortalMusteriListeleme_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.Column.Header.ToString() == "Id")
            {
                e.Column.Header = "No";
            }
            if (e.Column.Header.ToString() == "Name")
            {
                e.Column.Header = "Ad";
            }
            if (e.Column.Header.ToString() == "SurName")
            {
                e.Column.Header = "Soyad";
            }
            if (e.Column.Header.ToString() == "TaxNumber")
            {
                e.Column.Header = "TCKN";
            }
            if (e.Column.Header.ToString() == "BirthPlace")
            {
                e.Column.Header = "Doğum Yeri";
            }
            if (e.Column.Header.ToString() == "BirthDate")
            {
                e.Column.Header = "Doğum Tarihi";
            }
        }

        private void dgPortalMusteriListeleme_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (dgPortalMusteriListeleme.SelectedItem == null) return;
            CustomerContract selectedCustomer = dgPortalMusteriListeleme.SelectedItem as CustomerContract;

            CustomerAdd.CustomerAdd addCustomerAddWindow = new CustomerAdd.CustomerAdd(selectedCustomer);
            addCustomerAddWindow.Show();

            // MessageBox.Show(string.Format("The Person you double clicked on is - Id: {0}, Address: {1}, Surname: {2}", selectedPerson.Id, selectedPerson.Name, selectedPerson.SurName));
        }

        private void btnCloseTabCustomerList_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnOpenAccount_Click(object sender, RoutedEventArgs e)
        {
            if (dgPortalMusteriListeleme.SelectedItem == null) 
            {
                MessageBox.Show("Lütfen gridden müşteri seçiniz.","Message",MessageBoxButton.OK,MessageBoxImage.Error);
                return; 
            }
            CustomerContract selectedCustomer = dgPortalMusteriListeleme.SelectedItem as CustomerContract;
            AccountAdd.MainWindow addAccountAddWindow = new AccountAdd.MainWindow(new AccountContract() { AccountOwnerId = (int)selectedCustomer.Id });
            addAccountAddWindow.Show();
        }
    }
}
