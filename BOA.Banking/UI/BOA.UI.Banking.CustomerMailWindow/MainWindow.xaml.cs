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

namespace BOA.UI.Banking.CustomerMailWindow
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CustomerMailContract _customerMail;
        public MainWindow(CustomerMailContract customerMail)
        {
            _customerMail = customerMail;
            InitializeComponent();

            if (_customerMail.Id > 0)
            {
                txtMailId.Text = _customerMail.Id.ToString();
                txtMailAddress.Text = _customerMail.MailAddress;
            }
        }

        private void btnSaveMail_Click(object sender, RoutedEventArgs e)
        {

            if (txtMailId.Text != "")
            {//güncelleme
                if (txtMailAddress.Text == "")
                {
                    MessageBox.Show("Mail adresi boş geçilemez", "Message", MessageBoxButton.OK, MessageBoxImage.Error);
                    txtMailAddress.Focus();
                    return;
                }
                else if (!isValidEmail(txtMailAddress.Text))
                {
                    MessageBox.Show("Mail formatı yanlış", "Message", MessageBoxButton.OK, MessageBoxImage.Error);
                    txtMailAddress.Focus();
                    return;
                }
                _customerMail.Id = Convert.ToInt32(txtMailId.Text);
                _customerMail.MailAddress = txtMailAddress.Text;
                
                var connect = new Connector.Banking.GenericConnect<CustomerMailResponse>();
                var request = new Types.Banking.CustomerMailRequest();

                request.customerMail = _customerMail;
                request.MethodName = "UpdCustomerMail";

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
            {//yeni
                if (txtMailAddress.Text == "")
                {
                    MessageBox.Show("Mail adresi boş geçilemez", "Message", MessageBoxButton.OK, MessageBoxImage.Error);
                    txtMailAddress.Focus();
                    return;
                }
                else if (!isValidEmail(txtMailAddress.Text))
                {
                    MessageBox.Show("Mail formatı yanlış", "Message", MessageBoxButton.OK, MessageBoxImage.Error);
                    txtMailAddress.Focus();
                    return;
                }
                _customerMail.MailAddress = txtMailAddress.Text;
                var connect = new Connector.Banking.GenericConnect<CustomerMailResponse>();
                var request = new Types.Banking.CustomerMailRequest();

                request.customerMail = _customerMail;
                request.MethodName = "AddCustomerMail";

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
    }
}
