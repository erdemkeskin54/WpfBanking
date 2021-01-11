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
using BOA.UI.Banking.Portal;

namespace BOA.UI.Banking.Login
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Login : Window
    {
        
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            var connect = new Connector.Banking.Connect();
            var request = new Types.Banking.LoginRequest();
            var loginContract = new Types.Banking.LoginContract();

            loginContract.UserName = txtUserName.Text;
            loginContract.Password = txtPassword.Text;

            request.LoginContract = loginContract;
            request.MethodName = "GetLogin";

            var response = connect.Execute(request);

            if (response.IsSuccess == false)
            {
                // Uyarı verip hata mesajını ekrana basarız
                MessageBox.Show("Username or Password WRONG!");
            }
            else
            {
                txtUserName.IsEnabled = false;
                txtPassword.IsEnabled = false;
                MessageBox.Show("Login successful. Redirecting ...", "Process Situation");
                Portal.Portal portalWindow = new Portal.Portal();
                portalWindow.Show();
                this.Close();

            }
        }
    }
}
