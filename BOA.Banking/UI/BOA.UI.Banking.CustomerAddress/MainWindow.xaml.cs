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
using BOA.Types.Banking;

namespace BOA.UI.Banking.CustomerAddressWindow
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Types.Banking.CustomerAddressContract _customerAddress;
        public MainWindow(Types.Banking.CustomerAddressContract customerAddress)
        {
            _customerAddress = customerAddress;
            InitializeComponent();
            if(_customerAddress.Id>0)
            {
                txtAddressId.Text = _customerAddress.Id.ToString();
                txtAddress.Text = _customerAddress.Address;
                txtAddressTitle.Text = _customerAddress.Title;
            }
        }

        private void btnSaveAddress_Click(object sender, RoutedEventArgs e)
        {
            if(txtAddressId.Text!="")
            {
                //güncelleme
                if (txtAddressTitle.Text == "")
                {
                    MessageBox.Show("Adres başlığı boş geçilemez", "Message", MessageBoxButton.OK, MessageBoxImage.Error);
                    txtAddressTitle.Focus();
                    return;
                }
                if (txtAddress.Text == "")
                {
                    MessageBox.Show("Adres boş geçilemez", "Message", MessageBoxButton.OK, MessageBoxImage.Error);
                    txtAddress.Focus();
                    return;
                }

                _customerAddress.Id = Convert.ToInt32(txtAddressId.Text);
                _customerAddress.Title = txtAddressTitle.Text;
                _customerAddress.Address = txtAddress.Text;
                
                var connect = new Connector.Banking.GenericConnect<CustomerAddressResponse>();
                var request = new Types.Banking.CustomerAddressRequest();

                request.customerAddress = _customerAddress;
                request.MethodName = "UpdCustomerAddress";

                var response = connect.Execute(request);

                if (response.IsSuccess == true)
                {
                    MessageBox.Show("Adres güncelleme işlemi başarı ile gerçekleştirildi.");
                    this.Close();
                    return;
                }
                else
                {
                    MessageBox.Show("Adres ekleme işlemi başarısız oldu.");
                    return;
                }
            }
            else
            {
                //yeni adres

                if (txtAddressTitle.Text == "")
                {
                    MessageBox.Show("Adres başlığı boş geçilemez", "Message", MessageBoxButton.OK, MessageBoxImage.Error);
                    txtAddressTitle.Focus();
                    return;
                }
                if (txtAddress.Text == "")
                {
                    MessageBox.Show("Adres boş geçilemez", "Message", MessageBoxButton.OK, MessageBoxImage.Error);
                    txtAddress.Focus();
                    return;
                }

                _customerAddress.Title = txtAddressTitle.Text;
                _customerAddress.Address = txtAddress.Text;

                var connect = new Connector.Banking.GenericConnect<CustomerAddressResponse>();
                var request = new Types.Banking.CustomerAddressRequest();

                request.customerAddress = _customerAddress;
                request.MethodName = "AddCustomerAddress";

                var response = connect.Execute(request);

                if (response.IsSuccess == true)
                {
                    MessageBox.Show("Adres ekleme işlemi başarı ile gerçekleştirildi.");
                    this.Close();
                    return;
                }
                else
                {
                    MessageBox.Show("Adres ekleme işlemi başarısız oldu.");
                    return;
                }
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
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
    }
}
