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
using BOA.Types.Banking;
using BOA.UI.Banking.AccountVirman;

namespace BOA.UI.Banking.Portal
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Portal : Window
    {
        public int _selectedIndex;
        public Portal()
        {
            InitializeComponent();
            
            lblStatusBar.Text = "LOG-> "+ DateTime.Now.ToString() + " Admin başarıyla giriş yaptı.";
        }

        private void TreeViewItem_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void lblCustomerList(object sender, MouseButtonEventArgs e)
        {
            CustomerList.CustomerList listWindow = new CustomerList.CustomerList();
            TabItem tabMusteriEkle = new TabItem();
            tabMusteriEkle.Content = listWindow.Content;
            tabMusteriEkle.Header = "Müşteri Listeleme";
            tabMusteriEkle.Name = "tcCustomerList";
            tabMusteriEkle.IsSelected=true;
            tcPortal.Items.Add(tabMusteriEkle);
        }

        public void closeTabMusteriEkle()
        {
            CustomerList.CustomerList listWindow = new CustomerList.CustomerList();
            TabItem tabMusteriEkle = new TabItem();
            tabMusteriEkle.Content = listWindow.Content;
            tabMusteriEkle.Header = "Müşteri Listeleme";
            tabMusteriEkle.Name = "tcCustomerList";
            tabMusteriEkle.IsSelected = true;
            tcPortal.Items.Remove(tabMusteriEkle);
            return;
        }

        private void lblCustomerAdd(object sender, MouseButtonEventArgs e)
        {
            BOA.Types.Banking.CustomerContract customer = null;
            CustomerAdd.CustomerAdd addWindow = new CustomerAdd.CustomerAdd(customer);
            TabItem tabMusteriEkle = new TabItem();
            tabMusteriEkle.Content = addWindow.Content;
            tabMusteriEkle.Header = "Müşteri Tanımlama";
            tabMusteriEkle.Name = "tcCustomerAdd";
            tabMusteriEkle.IsSelected = true;
            tcPortal.Items.Add(tabMusteriEkle);
        }
        private void lblAccountAdd(object sender, MouseButtonEventArgs e)
        {
            AccountAdd.MainWindow addWindow = new AccountAdd.MainWindow(new AccountContract());
            TabItem tabHesapEkle = new TabItem();
            tabHesapEkle.Content = addWindow.Content;
            tabHesapEkle.Header = "Hesap Tanımlama";
            tabHesapEkle.Name = "tcAccountAdd";
            tabHesapEkle.IsSelected = true;
            tcPortal.Items.Add(tabHesapEkle);
        }
        private void lblAccountList(object sender, MouseButtonEventArgs e)
        {
            AccountList.MainWindow addWindow = new AccountList.MainWindow();
            TabItem tabHesapListeleme = new TabItem();
            tabHesapListeleme.Content = addWindow.Content;
            tabHesapListeleme.Header = "Hesap Listeleme";
            tabHesapListeleme.Name = "tcAccountList";
            tabHesapListeleme.IsSelected = true;
            tcPortal.Items.Add(tabHesapListeleme);
        }
        private void lblAccountWithdrawCash(object sender, MouseButtonEventArgs e)
        {
            AccountPayment.MainWindow addWindow = new AccountPayment.MainWindow(2);
            TabItem tabItem = new TabItem();
            tabItem.Content = addWindow.Content;
            tabItem.Header = "Para Çekme";
            tabItem.Name = "tcAccountWithdrawCash";
            tabItem.IsSelected = true;
            tcPortal.Items.Add(tabItem);
        }
        private void lblAccountDepositCash(object sender, MouseButtonEventArgs e)
        {
            AccountPayment.MainWindow addWindow = new AccountPayment.MainWindow(1);
            TabItem tabParaYatirma = new TabItem();
            tabParaYatirma.Content = addWindow.Content;
            tabParaYatirma.Header = "Para Yatırma";
            tabParaYatirma.Name = "tcAccountDepositCash";
            tabParaYatirma.IsSelected = true;
            tcPortal.Items.Add(tabParaYatirma);
        }
        private void lblAccountPaymentList(object sender, MouseButtonEventArgs e)
        {
            PaymentList.MainWindow addWindow = new PaymentList.MainWindow();
            TabItem tabPaymentListeleme = new TabItem();
            tabPaymentListeleme.Content = addWindow.Content;
            tabPaymentListeleme.Header = "Ödeme Listeleme";
            tabPaymentListeleme.Name = "tcPaymentListeleme";
            tabPaymentListeleme.IsSelected = true;
            tcPortal.Items.Add(tabPaymentListeleme);
        }
        private void lblVirmanAdd(object sender, MouseButtonEventArgs e)
        {
            AccountVirman.MainWindow addWindow = new AccountVirman.MainWindow();

            TabItem tabVirmanAdd = new TabItem();
            tabVirmanAdd.Content = addWindow.Content;
            tabVirmanAdd.Header = "Virman Tanımlama";
            tabVirmanAdd.Name = "tcVirmanAdd";
            tabVirmanAdd.IsSelected = true;
            tcPortal.Items.Add(tabVirmanAdd);
        }


        public void closeTab(object sender, EventArgs e)
        {
            tcPortal.Items.RemoveAt(tcPortal.SelectedIndex);
            //MessageBox.Show("Selected=" + tcPortal.SelectedIndex+"///" +tcPortal.Items.Contains("tcVirmanAdd"), "Message", MessageBoxButton.OK);
        }



        /* UserControl kullanım örneği
            UserControl1 userControl1 = new UserControl1();
            userControl1.ButtonClick += closeTab;
        */
    }
}
