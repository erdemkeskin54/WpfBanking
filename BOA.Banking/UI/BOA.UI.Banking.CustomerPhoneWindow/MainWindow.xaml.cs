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

namespace BOA.UI.Banking.CustomerPhoneWindow
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CustomerPhoneContract _customerPhone;

        public MainWindow(CustomerPhoneContract customerPhone)
        {
            _customerPhone = customerPhone;
            InitializeComponent();

            if (_customerPhone.Id > 0)
            {
                txtPhoneId.Text = _customerPhone.Id.ToString();
                txtPhoneAddress.Text = _customerPhone.Phone;
            }
        }

        private void btnSavePhone_Click(object sender, RoutedEventArgs e)
        {
            if (txtPhoneId.Text != "")
            {//güncelleme
                if (txtPhoneAddress.Text == "")
                {
                    MessageBox.Show("Telefon adresi boş geçilemez", "Message", MessageBoxButton.OK, MessageBoxImage.Error);
                    txtPhoneAddress.Focus();
                    return;
                }
                else if (!isValidPhone(txtPhoneAddress.Text))
                {
                    MessageBox.Show("Telefon formatı yanlış", "Message", MessageBoxButton.OK, MessageBoxImage.Error);
                    txtPhoneAddress.Focus();
                    return;
                }

                _customerPhone.Id = Convert.ToInt32(txtPhoneId.Text);
                _customerPhone.Phone = txtPhoneAddress.Text;

                var connect = new Connector.Banking.Connect();
                var request = new Types.Banking.CustomerPhoneRequest();

                request.customerPhone = _customerPhone;
                request.MethodName = "UpdCustomerPhone";

                var response = connect.ExecuteGetCustomerPhone(request);

                if (response.IsSuccess == true)
                {
                    MessageBox.Show("Telefon güncelleme işlemi başarı ile gerçekleştirildi.");
                    this.Close();
                    return;
                }
                else
                {
                    MessageBox.Show("Telefon güncelleme işlemi başarısız oldu.");
                    return;
                }
            }
            else
            {//yeni
                if (txtPhoneAddress.Text == "")
                {
                    MessageBox.Show("Telefon adresi boş geçilemez", "Message", MessageBoxButton.OK, MessageBoxImage.Error);
                    txtPhoneAddress.Focus();
                    return;
                }
                else if (!isValidPhone(txtPhoneAddress.Text))
                {
                    MessageBox.Show("Telefon formatı yanlış", "Message", MessageBoxButton.OK, MessageBoxImage.Error);
                    txtPhoneAddress.Focus();
                    return;
                }
                _customerPhone.Phone = txtPhoneAddress.Text;
                var connect = new Connector.Banking.Connect();
                var request = new Types.Banking.CustomerPhoneRequest();

                request.customerPhone = _customerPhone;
                request.MethodName = "AddCustomerPhone";

                var response = connect.ExecuteGetCustomerPhone(request);

                if (response.IsSuccess == true)
                {
                    MessageBox.Show("Telefon ekleme işlemi başarı ile gerçekleştirildi.");
                    this.Close();
                    return;
                }
                else
                {
                    MessageBox.Show("Telefon ekleme işlemi başarısız oldu.");
                    return;
                }
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
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
    }
}
