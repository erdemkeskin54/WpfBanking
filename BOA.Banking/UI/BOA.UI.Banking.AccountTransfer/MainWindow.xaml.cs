using BOA.Types.Banking;
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

namespace BOA.UI.Banking.AccountTransfer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            dpTransferDate.SelectedDate = DateTime.Now;

        }

        public event RoutedEventHandler CustomCloseTab;
        private void btnCloseVirmanAdd_Click(object sender, RoutedEventArgs e)
        {
            if (CustomCloseTab != null)
            {
                CustomCloseTab(this, new RoutedEventArgs());
            }
        }

        private void btnAddHavale_Click(object sender, RoutedEventArgs e)
        {
            if (ucAccountFirst.selectedAccountContract.AccountOwnerId < 0)
            {
                MessageBox.Show("Havale yapılacak hesabı seçiniz.", "Message", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (ucAccountSecond.selectedAccountContract.AccountOwnerId < 0)
            {
                MessageBox.Show("Havale yapılacak hesabı seçiniz.", "Message", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (ucAccountFirst.selectedAccountContract.AccountOwnerId == ucAccountSecond.selectedAccountContract.AccountOwnerId)
            {
                MessageBox.Show("İki hesapta aynı kişiye ait. Virman ekranına geçiniz.", "Message", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (ucAccountFirst.selectedAccountContract.FECId != ucAccountSecond.selectedAccountContract.FECId)
            {
                MessageBox.Show("Seçilen hesapların dövizleri aynı değil.", "Message", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (txtTransferAmount.Text == "")
            {
                MessageBox.Show("Tutar girilmedi", "Message", MessageBoxButton.OK, MessageBoxImage.Error);
                txtTransferAmount.Focus();
                return;
            }
            else if (Convert.ToDecimal(txtTransferAmount.Text) > ucAccountFirst.selectedAccountContract.Balance)
            {
                MessageBox.Show("Hesapta yeterli bakiye yok.", "Message", MessageBoxButton.OK, MessageBoxImage.Error);
                txtTransferAmount.Focus();
                return;
            }
            TransferContract transferContract = new TransferContract();
            transferContract.AccountFirstId = ucAccountFirst.selectedAccountContract.Id;
            transferContract.AccountSecondId = ucAccountSecond.selectedAccountContract.Id;
            transferContract.Date = dpTransferDate.SelectedDate.Value;
            transferContract.Amount = Convert.ToDecimal(txtTransferAmount.Text);
            transferContract.Description = txtTransferDesc.Text;
            AddTransfer(transferContract);
        }

        private bool AddTransfer(TransferContract transferContract)
        {
            var connect = new Connector.Banking.GenericConnect<TransferResponse>();
            var request = new Types.Banking.TransferRequest();

            request.transferContract = transferContract;
            request.MethodName = "AddTransfer";

            var response = connect.Execute(request);

            if (response.IsSuccess == true)
            {
                MessageBox.Show("Havale işlemi başarılı", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
                return true;
            }
            else
            {
                MessageBox.Show("Havale işlemi hatalı", "Message", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }

        private void ucAccountFirst_AccountSelected(object sender, EventArgs e)
        {
            if (ucAccountFirst.selectedAccountContract!=null)
            {
                if (ucAccountFirst.selectedAccountContract.AccountOwnerId > 0)
                {
                    lblDovizTuru.Content = ucAccountFirst.selectedAccountContract.fecContract.Name;
                }
            }
            
        }
    }
}
