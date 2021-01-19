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

        public void closeTab(object sender, EventArgs e)
        {
            tcPortal.Items.RemoveAt(tcPortal.SelectedIndex);
        }
        private void lblCustomerList(object sender, MouseButtonEventArgs e)
        {
            CustomerList.CustomerList listWindow = new CustomerList.CustomerList();
            listWindow.CustomCloseTab += closeTab;
            TabItem tabMusteriEkle = new TabItem();
            tabMusteriEkle.Content = listWindow.Content;
            tabMusteriEkle.Header = "Müşteri Listeleme";
            tabMusteriEkle.Name = "tcCustomerList";
            tabMusteriEkle.IsSelected=true;
            tcPortal.Items.Add(tabMusteriEkle);
        }

        private void lblCustomerAdd(object sender, MouseButtonEventArgs e)
        {
            BOA.Types.Banking.CustomerContract customer = null;
            CustomerAdd.CustomerAdd addWindow = new CustomerAdd.CustomerAdd(customer);
            addWindow.CustomCloseTab += closeTab;
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
            addWindow.CustomCloseTab += closeTab;
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
            addWindow.CustomCloseTab += closeTab;
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
            addWindow.CustomCloseTab += closeTab;
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
            addWindow.CustomCloseTab += closeTab;
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
            addWindow.CustomCloseTab += closeTab;
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
            addWindow.CustomCloseTab += closeTab;
            TabItem tabVirmanAdd = new TabItem();
            tabVirmanAdd.Content = addWindow.Content;
            tabVirmanAdd.Header = "Virman Tanımlama";
            tabVirmanAdd.Name = "tcVirmanAdd";
            tabVirmanAdd.IsSelected = true;
            tcPortal.Items.Add(tabVirmanAdd);
        }


        

        private void Label_MouseDoubleClick_1(object sender, MouseButtonEventArgs e)
        {
            UC.AccountSelect.UserControl1 addUCAccount = new UC.AccountSelect.UserControl1();
            TabItem tabUCCustomerAdd = new TabItem();
            tabUCCustomerAdd.Content = addUCAccount.Content;
            tabUCCustomerAdd.Header = "UCAccountSelect";
            tabUCCustomerAdd.Name = "tcUC";
            tabUCCustomerAdd.IsSelected = true;
            tcPortal.Items.Add(tabUCCustomerAdd);
        }

        private void lblHavale(object sender, MouseButtonEventArgs e)
        {
            AccountTransfer.MainWindow addWindow = new AccountTransfer.MainWindow();
            addWindow.CustomCloseTab += closeTab;
            TabItem tabAdd = new TabItem();
            tabAdd.Content = addWindow.Content;
            tabAdd.Header = "Havale";
            tabAdd.Name = "tcHavale";
            tabAdd.IsSelected = true;
            tcPortal.Items.Add(tabAdd);
        }



        /* UserControl kullanım örneği
            UserControl1 userControl1 = new UserControl1();
            userControl1.ButtonClick += closeTab;
        */
    }
}
