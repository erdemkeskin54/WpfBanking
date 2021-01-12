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

namespace UC.CustomerSelect
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
            ComboboxCustomer(new CustomerContract());

        }
        public CustomerContract customerContract
        {
            get
            {
                CustomerContract selected = cbAccountCustomer.SelectedItem as CustomerContract;
                return selected;
            }
        }
        public int selectedComboboxIndex
        {
            get
            {
                return cbAccountCustomer.SelectedIndex;
            }
            set
            {
                cbAccountCustomer.SelectedIndex=value;
            }
        }


        private bool ComboboxCustomer(CustomerContract customer)
        {
            var connect = new BOA.Connector.Banking.GenericConnect<CustomerResponse>();
            var request = new BOA.Types.Banking.CustomerRequest();

            request.customer = customer;
            request.MethodName = "CustomerAll";

            var response = connect.Execute(request);

            if (response.IsSuccess == true)
            {
                cbAccountCustomer.ItemsSource = response.customers;
                //cbAccountCustomer.DisplayMemberPath = "Name";
                //cbAccountCustomer.SelectedValuePath = "Id";
                cbAccountCustomer.Items.Refresh();
            }
            else
            {
                MessageBox.Show("Veriler getirilirken hata oluştu!", "Message", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return false;
        }

    }
}
