using BOA.UI.Banking.Portal;
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

namespace BOA.UI.Banking.UserPortal
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class UserPortal : Window
    {
        public UserPortal()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnEkle_Click(object sender, RoutedEventArgs e)
        {
            PortalWindow portalWindow = new PortalWindow();
            TabItem musteriEkle = new TabItem();
            musteriEkle.Content = portalWindow.Content;
            musteriEkle.Header = "Müşteri Tanımlama";
            musteriEkle.Name = "tcCustomerAdd";
            this.Width = portalWindow.Width;
            this.Height = portalWindow.Height;
            tcPortal.Items.Add(musteriEkle);
        }

        private void btnListele_Click(object sender, RoutedEventArgs e)
        {
            tcPortal.Items.RemoveAt(tcPortal.SelectedIndex);
        }
    }
}
