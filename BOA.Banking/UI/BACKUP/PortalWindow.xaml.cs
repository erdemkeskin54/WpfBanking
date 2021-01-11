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


namespace BOA.UI.Banking.Portal
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class PortalWindow : Window
    {
        public PortalWindow()
        {
            InitializeComponent();

            lblStatusBar.Text = "LOG-> "+ DateTime.Now.ToString() + " Admin başarıyla giriş yaptı.";
            try
            {
                String connectionString = @"Server=DARKSPOILER\SQLEXPRESS;Database=BOA;Trusted_Connection=True;";
                SqlConnection con = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand("select CustomerId AS 'Müşteri No',CustomerName AS 'AD SOYAD',TaxNumber AS 'TCKN',BirthPlace AS 'Doğum Yeri',BirthDate AS 'Doğum Tarihi' from cus.Customer", con);
                con.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgPortalMusteriListleme.ItemsSource = dt.DefaultView;
                cmd.Dispose();
                con.Close();
            }
            catch (Exception ex)
            {
            }
            
        }

        private void TreeViewItem_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void LblCustomerAdd(object sender, MouseButtonEventArgs e)
        {
            
        }
    }
}
