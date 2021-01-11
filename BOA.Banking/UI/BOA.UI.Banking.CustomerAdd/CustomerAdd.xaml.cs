using BOA.Types.Banking;
using BOA.Types.Banking.Base;
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

namespace BOA.UI.Banking.CustomerAdd
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class CustomerAdd : Window
    {
        CustomerContract customer;
        CustomerDetailContract customerDetail;
        List<EducationContract> educations = new List<EducationContract>();
        List<JobContract> jobs = new List<JobContract>();

        List<CustomerAddressContract> customerAddresses;
        List<CustomerMailContract> customerMails;
        List<CustomerPhoneContract> customerPhones;


        public CustomerAdd(CustomerContract customer)
        {
            InitializeComponent();
            if (customer==null)
            {
                comboboxEducations();
                comboboxJobs();
                gbContact.IsEnabled = false;
            }
            else
            {
                gbContact.IsEnabled = true;
                customerDetail = new CustomerDetailContract();
                customerMails = new List<CustomerMailContract>();
                customerPhones = new List<CustomerPhoneContract>();
                this.customer = new CustomerContract();
                this.customer=customer;
                comboboxEducations();
                comboboxJobs();
                customerDetail.Id = (int)customer.Id;
                GetCustomerDetail(customerDetail);

                GetCustomerAddress(new CustomerAddressContract() {  Id = customerDetail.Id });

                GetCustomerMail(new CustomerMailContract() { CustomerId = customerDetail.Id });

                GetCustomerPhone(new CustomerPhoneContract() { CustomerId = customerDetail.Id });
            }
            
        }

        private void comboboxEducations()
        {
            var connect = new Connector.Banking.Connect();
            var request = new Types.Banking.EducationRequest();

            request.MethodName = "GetEducations";

            var response = connect.ExecuteGetEducations(request);

            if (response.IsSuccess == true)
            {
                foreach (var item in response.educations)
                {
                    cbCustomerAddEducation.Items.Add(item.Name);
                }
                educations = response.educations;
                cbCustomerAddEducation.Items.Refresh();
                return;
            }
            else
            {
                return ;
            }
        }
        private void comboboxJobs()
        {
            var connect = new Connector.Banking.Connect();
            var request = new Types.Banking.JobRequest();

            request.MethodName = "GetJobs";

            var response = connect.ExecuteGetJobs(request);

            if (response.IsSuccess == true)
            {
                foreach (var item in response.jobs)
                {
                    cbCustomerAddJob.Items.Add(item.Name);
                }
                jobs = response.jobs;
                cbCustomerAddJob.Items.Refresh();
                return;
            }
            else
            {
                return;
            }
        }

        private void GetCustomerAddress(Types.Banking.CustomerAddressContract customerAddress)
        {
            customerAddresses = new List<Types.Banking.CustomerAddressContract>();
            var connect = new Connector.Banking.Connect();
            var request = new Types.Banking.CustomerAddressRequest();

            request.customerAddress =customerAddress;
            request.MethodName = "GetCustomerAddress";

            var response = connect.ExecuteGetCustomerAddress(request);

            if (response.IsSuccess == true)
            {
                foreach (var item in response.customerAddresses)
                {
                    customerAddresses.Add(item);
                }
                dgCustomerAddress.ItemsSource = response.customerAddresses;
                dgCustomerAddress.Items.Refresh();
                return;
            }
            else
            {
                return;
            }
        }

        private void GetCustomerPhone(CustomerPhoneContract customerPhone)
        {
            customerPhones = new List<CustomerPhoneContract>();
            var connect = new Connector.Banking.Connect();
            var request = new Types.Banking.CustomerPhoneRequest();

            request.customerPhone= customerPhone;
            request.MethodName = "GetCustomerPhone";

            var response = connect.ExecuteGetCustomerPhone(request);

            if (response.IsSuccess == true)
            {
                foreach (var item in response.customerPhones)
                {
                    customerPhones.Add(item);
                }
                dgCustomerPhone.ItemsSource = response.customerPhones;
                dgCustomerPhone.Items.Refresh();
                return;
            }
            else
            {
                return;
            }
        }

        private void GetCustomerMail(CustomerMailContract customerMail)
        {
            customerMails = new List<CustomerMailContract>();
            var connect = new Connector.Banking.Connect();
            var request = new Types.Banking.CustomerMailRequest();

            request.customerMail = customerMail;
            request.MethodName = "GetCustomerMail";

            var response = connect.ExecuteGetCustomerMail(request);

            if (response.IsSuccess == true)
            {
                foreach (var item in response.customerMails)
                {
                    customerMails.Add(item);
                }
               dgCustomerMail.ItemsSource = response.customerMails;
               dgCustomerMail.Items.Refresh();
                return;
            }
            else
            {
                return;
            }
        }





        //Customer CRUD 
        public bool GetCustomerDetail(CustomerDetailContract customerDetail)
        {
            var connect = new Connector.Banking.Connect();
            var request = new Types.Banking.CustomerDetailRequest();

            request.customerDetail = customerDetail;
            request.MethodName = "GetCustomerDetail";

            var response = connect.ExecuteCustomerDetail(request);

            if (response.IsSuccess == true)
            {
                customerDetail = response.customerDetail;
                cbCustomerAddEducation.SelectedIndex = (int)response.customerDetail.EducationId - 1;
                cbCustomerAddJob.SelectedIndex = (int)response.customerDetail.JobId - 1;
                txtCustomerAddNo.Text = customerDetail.Id.ToString();
                txtCustomerAddName.Text = customerDetail.Name;
                txtCustomerAddSurName.Text = customerDetail.SurName;
                txtCustomerAddTaxNumber.Text = customerDetail.TaxNumber;
                txtCustomerAddBirthPlace.Text = customerDetail.BirthPlace;
                dpBirthDate.SelectedDate = customerDetail.BirthDate;
                txtCustomerAddMomName.Text = customerDetail.MomName;
                txtCustomerAddFatherName.Text = customerDetail.FatherName;


                return true;
            }
            else
            {
                return false;
            }

        }
        private CustomerDetailContract UpdateCustomerDetail(CustomerDetailContract customerDetail)
        {
            var connect = new Connector.Banking.Connect();
            var request = new Types.Banking.CustomerDetailRequest();

            request.customerDetail = customerDetail;
            request.MethodName = "UpdateCustomerDetail";

            var response = connect.ExecuteCustomerDetail(request);

            if (response.IsSuccess == true)
            {
                return response.customerDetail;
                 
            }
            else
            {
                return null;
            }
        }
        private CustomerDetailContract AddCustomerDetail(CustomerDetailContract customerDetail)
        {
            var connect = new Connector.Banking.Connect();
            var request = new Types.Banking.CustomerDetailRequest();

            request.customerDetail = customerDetail;
            request.MethodName = "AddCustomerDetail";

            var response = connect.ExecuteCustomerDetail(request);

            if (response.IsSuccess == true)
            {
                return response.customerDetail;

            }
            else
            {
                return null;
            }
        }
        private CustomerDetailContract DeleteCustomerDetail(CustomerDetailContract customerDetail)
        {
            var connect = new Connector.Banking.Connect();
            var request = new Types.Banking.CustomerDetailRequest();

            request.customerDetail = customerDetail;
            request.MethodName = "DeleteCustomerDetail";

            var response = connect.ExecuteCustomerDetail(request);

            if (response.IsSuccess == true)
            {
                return response.customerDetail;
            }
            else
            {
                return null;
            }
        }
        
        
        //CustomerAdd Butonlar
        private void btnCustomerAdd_Click(object sender, RoutedEventArgs e)
        {
            if (customer == null && txtCustomerAddNo.Text != "")
            {
                //kayıt güncelleme
                if (txtCustomerAddTaxNumber.Text == "")
                {
                    MessageBox.Show("TC numarası boş geçilemez", "Message", MessageBoxButton.OK, MessageBoxImage.Error);
                    txtCustomerAddTaxNumber.Focus();
                    return;
                }
                else if (!isValidNumber(txtCustomerAddTaxNumber.Text))
                {
                    MessageBox.Show("TC numarası sadece rakamlardan oluşabilir", "Message", MessageBoxButton.OK, MessageBoxImage.Error);
                    txtCustomerAddTaxNumber.Focus();
                    return;
                }

                if (txtCustomerAddName.Text == "")
                {
                    MessageBox.Show("Ad alanı boş geçilemez", "Message", MessageBoxButton.OK, MessageBoxImage.Error);
                    txtCustomerAddName.Focus();
                    return;
                }
                else if (!isValidText(txtCustomerAddName.Text))
                {
                    MessageBox.Show("Ad yanlış karakterler içeriyor", "Message", MessageBoxButton.OK, MessageBoxImage.Error);
                    txtCustomerAddName.Focus();
                    return;
                }

                if (txtCustomerAddSurName.Text == "")
                {
                    MessageBox.Show("Soyad alanı boş geçilemez", "Message", MessageBoxButton.OK, MessageBoxImage.Error);
                    txtCustomerAddSurName.Focus();
                    return;
                }
                else if (!isValidText(txtCustomerAddSurName.Text))
                {
                    MessageBox.Show("Soyad yanlış karakterler içeriyor", "Message", MessageBoxButton.OK, MessageBoxImage.Error);
                    txtCustomerAddSurName.Focus();
                    return;
                }

                if (txtCustomerAddMomName.Text == "")
                {
                    MessageBox.Show("Anne adı boş geçilemez", "Message", MessageBoxButton.OK, MessageBoxImage.Error);
                    txtCustomerAddMomName.Focus();
                    return;
                }
                else if (!isValidText(txtCustomerAddMomName.Text))
                {
                    MessageBox.Show("Anne adı yanlış karakterler içeriyor", "Message", MessageBoxButton.OK, MessageBoxImage.Error);
                    txtCustomerAddMomName.Focus();
                    return;
                }

                if (txtCustomerAddFatherName.Text == "")
                {
                    MessageBox.Show("Baba adı boş geçilemez", "Message", MessageBoxButton.OK, MessageBoxImage.Error);
                    txtCustomerAddFatherName.Focus();
                    return;
                }
                else if (!isValidText(txtCustomerAddFatherName.Text))
                {
                    MessageBox.Show("Baba adı yanlış karakterler içeriyor", "Message", MessageBoxButton.OK, MessageBoxImage.Error);
                    txtCustomerAddFatherName.Focus();
                    return;
                }


                if (txtCustomerAddBirthPlace.Text == "")
                {
                    MessageBox.Show("Doğum yeri boş geçilemez", "Message", MessageBoxButton.OK, MessageBoxImage.Error);
                    txtCustomerAddBirthPlace.Focus();
                    return;
                }
                else if (!isValidText(txtCustomerAddBirthPlace.Text))
                {
                    MessageBox.Show("Doğum yeri yanlış karakterler içeriyor", "Message", MessageBoxButton.OK, MessageBoxImage.Error);
                    txtCustomerAddBirthPlace.Focus();
                    return;
                }

                if (dpBirthDate.SelectedDate == null)
                {
                    MessageBox.Show("Doğum tarihi bilgisi boş geçilemez", "Message", MessageBoxButton.OK, MessageBoxImage.Error);
                    txtCustomerAddFatherName.Focus();
                    return;
                }

                if (cbCustomerAddEducation.SelectedIndex == -1)
                {
                    MessageBox.Show("Eğitim bilgisi boş geçilemez", "Message", MessageBoxButton.OK, MessageBoxImage.Error);
                    cbCustomerAddEducation.Focus();
                    return;
                }

                if (cbCustomerAddJob.SelectedIndex == -1)
                {
                    MessageBox.Show("İş bilgisi boş geçilemez", "Message", MessageBoxButton.OK, MessageBoxImage.Error);
                    cbCustomerAddJob.Focus();
                    return;
                }

                customerDetail.Id = Convert.ToInt32(txtCustomerAddNo.Text);
                customerDetail.Name = txtCustomerAddName.Text;
                customerDetail.SurName = txtCustomerAddSurName.Text;
                customerDetail.TaxNumber = txtCustomerAddTaxNumber.Text;
                customerDetail.BirthPlace = txtCustomerAddBirthPlace.Text;
                customerDetail.BirthDate = dpBirthDate.SelectedDate.Value;
                customerDetail.MomName = txtCustomerAddMomName.Text;
                customerDetail.FatherName = txtCustomerAddFatherName.Text;
                customerDetail.EducationId = cbCustomerAddEducation.SelectedIndex + 1;
                customerDetail.JobId = cbCustomerAddJob.SelectedIndex + 1;

                customerDetail = UpdateCustomerDetail(customerDetail);
                MessageBox.Show("Id:" + customerDetail.Id + " kullanıcı güncellendi.", "Message", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            else
            {
                //yeni kayıt
                if (txtCustomerAddTaxNumber.Text == "")
                {
                    MessageBox.Show("TC numarası boş geçilemez", "Message", MessageBoxButton.OK, MessageBoxImage.Error);
                    txtCustomerAddTaxNumber.Focus();
                    return;
                }
                else if (!isValidNumber(txtCustomerAddTaxNumber.Text))
                {
                    MessageBox.Show("TC numarası sadece rakamlardan oluşabilir", "Message", MessageBoxButton.OK, MessageBoxImage.Error);
                    txtCustomerAddTaxNumber.Focus();
                    return;
                }

                if (txtCustomerAddName.Text == "")
                {
                    MessageBox.Show("Ad alanı boş geçilemez", "Message", MessageBoxButton.OK, MessageBoxImage.Error);
                    txtCustomerAddName.Focus();
                    return;
                }
                else if (!isValidText(txtCustomerAddName.Text))
                {
                    MessageBox.Show("Ad yanlış karakterler içeriyor", "Message", MessageBoxButton.OK, MessageBoxImage.Error);
                    txtCustomerAddName.Focus();
                    return;
                }

                if (txtCustomerAddSurName.Text == "")
                {
                    MessageBox.Show("Soyad alanı boş geçilemez", "Message", MessageBoxButton.OK, MessageBoxImage.Error);
                    txtCustomerAddSurName.Focus();
                    return;
                }
                else if (!isValidText(txtCustomerAddSurName.Text))
                {
                    MessageBox.Show("Soyad yanlış karakterler içeriyor", "Message", MessageBoxButton.OK, MessageBoxImage.Error);
                    txtCustomerAddSurName.Focus();
                    return;
                }

                if (txtCustomerAddMomName.Text == "")
                {
                    MessageBox.Show("Anne adı boş geçilemez", "Message", MessageBoxButton.OK, MessageBoxImage.Error);
                    txtCustomerAddMomName.Focus();
                    return;
                }
                else if (!isValidText(txtCustomerAddMomName.Text))
                {
                    MessageBox.Show("Anne adı yanlış karakterler içeriyor", "Message", MessageBoxButton.OK, MessageBoxImage.Error);
                    txtCustomerAddMomName.Focus();
                    return;
                }

                if (txtCustomerAddFatherName.Text == "")
                {
                    MessageBox.Show("Baba adı boş geçilemez", "Message", MessageBoxButton.OK, MessageBoxImage.Error);
                    txtCustomerAddFatherName.Focus();
                    return;
                }
                else if (!isValidText(txtCustomerAddFatherName.Text))
                {
                    MessageBox.Show("Baba adı yanlış karakterler içeriyor", "Message", MessageBoxButton.OK, MessageBoxImage.Error);
                    txtCustomerAddFatherName.Focus();
                    return;
                }


                if (txtCustomerAddBirthPlace.Text == "")
                {
                    MessageBox.Show("Doğum yeri boş geçilemez", "Message", MessageBoxButton.OK, MessageBoxImage.Error);
                    txtCustomerAddBirthPlace.Focus();
                    return;
                }
                else if (!isValidText(txtCustomerAddBirthPlace.Text))
                {
                    MessageBox.Show("Doğum yeri yanlış karakterler içeriyor", "Message", MessageBoxButton.OK, MessageBoxImage.Error);
                    txtCustomerAddBirthPlace.Focus();
                    return;
                }

                if (dpBirthDate.SelectedDate==null)
                {
                    MessageBox.Show("Doğum tarihi bilgisi boş geçilemez", "Message", MessageBoxButton.OK, MessageBoxImage.Error);
                    txtCustomerAddFatherName.Focus();
                    return;
                }

                if (cbCustomerAddEducation.SelectedIndex == -1)
                {
                    MessageBox.Show("Eğitim bilgisi boş geçilemez", "Message", MessageBoxButton.OK, MessageBoxImage.Error);
                    cbCustomerAddEducation.Focus();
                    return;
                }

                if (cbCustomerAddJob.SelectedIndex == -1)
                {
                    MessageBox.Show("İş bilgisi boş geçilemez", "Message", MessageBoxButton.OK, MessageBoxImage.Error);
                    cbCustomerAddJob.Focus();
                    return;
                }


                customerDetail = new CustomerDetailContract();
                customerDetail.Name = txtCustomerAddName.Text;
                customerDetail.SurName = txtCustomerAddSurName.Text;
                customerDetail.TaxNumber = txtCustomerAddTaxNumber.Text;
                customerDetail.BirthPlace = txtCustomerAddBirthPlace.Text;
                customerDetail.BirthDate = dpBirthDate.SelectedDate.Value;
                customerDetail.MomName = txtCustomerAddMomName.Text;
                customerDetail.FatherName = txtCustomerAddFatherName.Text;
                customerDetail.EducationId = cbCustomerAddEducation.SelectedIndex + 1;
                customerDetail.JobId = cbCustomerAddJob.SelectedIndex + 1;

                customerDetail = AddCustomerDetail(customerDetail);
                MessageBox.Show("Yeni Eklenen Müşteri ID = " + customerDetail.Id, "Message", MessageBoxButton.OK, MessageBoxImage.Information);
                GetCustomerDetail(customerDetail);
            }
        }
        private void btnCustomerDelete_Click(object sender, RoutedEventArgs e)
        {
            if (customer != null && txtCustomerAddNo.Text != "")
            {
                //var olan kaydı silme
                customerDetail.Id = Convert.ToInt32(txtCustomerAddNo.Text);
                customerDetail.Name = txtCustomerAddName.Text;
                customerDetail.SurName = txtCustomerAddSurName.Text;
                customerDetail.TaxNumber = txtCustomerAddTaxNumber.Text;
                customerDetail.BirthPlace = txtCustomerAddBirthPlace.Text;
                customerDetail.BirthDate = dpBirthDate.SelectedDate.Value;
                customerDetail.MomName = txtCustomerAddMomName.Text;
                customerDetail.FatherName = txtCustomerAddFatherName.Text;
                customerDetail.EducationId = cbCustomerAddEducation.SelectedIndex + 1;
                customerDetail.JobId = cbCustomerAddJob.SelectedIndex + 1;

                customerDetail = DeleteCustomerDetail(customerDetail);
                MessageBox.Show("Id:" + customerDetail.Id + " kullanıcı başarıyla silindi.", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();

            }
            else
            {
                MessageBox.Show("Kayıt silinemedi");
            }
        }
        private void btnCloseCustomerAdd_Click(object sender, RoutedEventArgs e)
        {
            customerDetail = null;
            customerAddresses = null;
            customerMails = null;
            customerPhones = null;
            this.Close();
        }


        //Validation
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

        public static bool isValidPhone(string inputPhone)
        {
            string strRegex = @"^(05(\d{9}))$";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(inputPhone))
                return true;    
            else
                return false;
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

        public static bool isValidNumber(string inputNumber)
        {
            string strRegex = @"^[0-9]*$";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(inputNumber))
                return true;
            else
                return false;
        }


        /*Bu şekildede yapılabilir 
        private void txtCustomerAddName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtCustomerAddName.Text, "^[a-zA-Z ]*$") && txtCustomerAddName.Text != "")
            {
                MessageBox.Show("Sadece karakterler kabul edilmektedir.","Mesaj", MessageBoxButton.OK, MessageBoxImage.Error);
                txtCustomerAddName.Text = txtCustomerAddName.Text.Remove(txtCustomerAddName.Text.Length - 1);
            }
        }
        */

        //-----------------------------------------------------------------------------------



        //Column Name
        private void dgCustomerAddress_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.Column.Header.ToString() == "Id")
            {
                e.Column.Visibility = Visibility.Hidden;
            }
            if (e.Column.Header.ToString() == "Title")
            {
                e.Column.Header = "Başlık";
            }
            if (e.Column.Header.ToString() == "Address")
            {
                e.Column.Header = "Adres";
            }
            if (e.Column.Header.ToString() == "CustomerId")
            {
                e.Column.Visibility = Visibility.Hidden;
            }
        }
        private void dgCustomerPhone_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.Column.Header.ToString() == "Id")
            {
                e.Column.Visibility = Visibility.Hidden;
            }
            if (e.Column.Header.ToString() == "Phone")
            {
                e.Column.Header = "Telefon Numarası";
            }
            if (e.Column.Header.ToString() == "CustomerId")
            {
                e.Column.Visibility = Visibility.Hidden;
            }
        }
        private void dgCustomerMail_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.Column.Header.ToString() == "Id")
            {
                e.Column.Visibility = Visibility.Hidden;
            }
            if (e.Column.Header.ToString() == "MailAddress")
            {
                e.Column.Header = "Mail Adresi";
            }
            if (e.Column.Header.ToString() == "CustomerId")
            {
                e.Column.Visibility = Visibility.Hidden;
            }
        }
        //------------------------------------------------------------------------------------------------------------




        //Adres CRUD butonları
        private void btnAddAddress_Click(object sender, RoutedEventArgs e)
        {
           
            Types.Banking.CustomerAddressContract customerAddress = new Types.Banking.CustomerAddressContract();
            customerAddress.CustomerId = customerDetail.Id;
            CustomerAddressWindow.MainWindow addAddressWindow = new CustomerAddressWindow.MainWindow(customerAddress);
            addAddressWindow.Show();

        }
        private void btnUpdateAddress_Click(object sender, RoutedEventArgs e)
        {
            
            Types.Banking.CustomerAddressContract customerAddress = new Types.Banking.CustomerAddressContract();
            customerAddress.CustomerId = customerDetail.Id;
            if (dgCustomerAddress.SelectedItem == null) { MessageBox.Show("Lütfen Gridden güncellenecek adresi seçiniz."); return; }
            customerAddress = dgCustomerAddress.SelectedItem as Types.Banking.CustomerAddressContract;
            CustomerAddressWindow.MainWindow addAddressWindow = new CustomerAddressWindow.MainWindow(customerAddress);
            addAddressWindow.Show();
        }
        private void btnDeleteAddress_Click(object sender, RoutedEventArgs e)
        {
            
            if (dgCustomerAddress.SelectedItem == null) { MessageBox.Show("Lütfen Gridden silinecek adresi seçiniz."); return; }
            
            Types.Banking.CustomerAddressContract customerAddress = new Types.Banking.CustomerAddressContract();
            customerAddress = dgCustomerAddress.SelectedItem as Types.Banking.CustomerAddressContract;
            
            var connect = new Connector.Banking.Connect();
            var request = new Types.Banking.CustomerAddressRequest();

            request.customerAddress = customerAddress;
            request.MethodName = "DelCustomerAddress";

            var response = connect.ExecuteGetCustomerAddress(request);

            if (response.IsSuccess == true)
            {
                MessageBox.Show("Adres silme işlemi başarı ile gerçekleştirildi.");
                this.Close();
                return;
            }
            else
            {
                MessageBox.Show("Adres ekleme işlemi başarısız oldu.");
                return;
            }
        }
        //----------------------------------------------------------------------
        




        //Mail CRUD butonları
        private void btnAddMail_Click(object sender, RoutedEventArgs e)
        {
           
            CustomerMailContract customerMail = new CustomerMailContract();
            customerMail.CustomerId = customerDetail.Id;
            CustomerMailWindow.MainWindow addMailWindow = new CustomerMailWindow.MainWindow(customerMail);
            addMailWindow.Show();
        }

        private void btnUpdateMail_Click(object sender, RoutedEventArgs e)
        {
            
            CustomerMailContract customerMail = new CustomerMailContract();
            customerMail.CustomerId = customerDetail.Id;
            if (dgCustomerMail.SelectedItem == null) { MessageBox.Show("Lütfen Gridden güncellenecek Mail adresini seçiniz."); return; }
            customerMail = dgCustomerMail.SelectedItem as CustomerMailContract;
            CustomerMailWindow.MainWindow addMailWindow = new CustomerMailWindow.MainWindow(customerMail);
            addMailWindow.Show();
        }

        private void btnDeleteMail_Click(object sender, RoutedEventArgs e)
        {
           
            if (dgCustomerMail.SelectedItem == null) { MessageBox.Show("Lütfen Gridden silinecek Mail adresini seçiniz."); return; }

            CustomerMailContract customerMail = new CustomerMailContract();
            customerMail = dgCustomerMail.SelectedItem as CustomerMailContract;

            var connect = new Connector.Banking.Connect();
            var request = new Types.Banking.CustomerMailRequest();

            request.customerMail = customerMail;
            request.MethodName = "DelCustomerMail";

            var response = connect.ExecuteGetCustomerMail(request);

            if (response.IsSuccess == true)
            {
                MessageBox.Show("Mail adres silme işlemi başarı ile gerçekleştirildi.");
                this.Close();
                return;
            }
            else
            {
                MessageBox.Show("Mail adres silme işlemi başarısız oldu.");
                return;
            }
        }
        //-------------------------------------------------------------------


        //Phone CRUD butonları
        private void btnAddPhone_Click(object sender, RoutedEventArgs e)
        {
            
            CustomerPhoneContract customerPhone = new CustomerPhoneContract();
            customerPhone.CustomerId = customerDetail.Id;
            CustomerPhoneWindow.MainWindow addPhoneWindow = new CustomerPhoneWindow.MainWindow(customerPhone);
            addPhoneWindow.Show();
        }

        private void btnUpdatePhone_Click(object sender, RoutedEventArgs e)
        {
            
            CustomerPhoneContract customerPhone = new CustomerPhoneContract();
            customerPhone.CustomerId = customerDetail.Id;
            if (dgCustomerPhone.SelectedItem == null) { MessageBox.Show("Lütfen Gridden güncellenecek Telefon adresini seçiniz."); return; }
            customerPhone = dgCustomerPhone.SelectedItem as CustomerPhoneContract;
            customerPhone.CustomerId = customerDetail.Id;
            CustomerPhoneWindow.MainWindow addPhoneWindow = new CustomerPhoneWindow.MainWindow(customerPhone);
            addPhoneWindow.Show();
        }

        private void btnDeletePhone_Click(object sender, RoutedEventArgs e)
        {
            
            if (dgCustomerPhone.SelectedItem == null) { MessageBox.Show("Lütfen Gridden silinecek Telefon adresini seçiniz."); return; }

            CustomerPhoneContract customerPhone = new CustomerPhoneContract();
            customerPhone = dgCustomerPhone.SelectedItem as CustomerPhoneContract;

            var connect = new Connector.Banking.Connect();
            var request = new Types.Banking.CustomerPhoneRequest();

            request.customerPhone = customerPhone;
            request.MethodName = "DelCustomerPhone";

            var response = connect.ExecuteGetCustomerPhone(request);

            if (response.IsSuccess == true)
            {
                MessageBox.Show("Telefon numarası silme işlemi başarı ile gerçekleştirildi.");
                this.Close();
                return;
            }
            else
            {
                MessageBox.Show("Telefon numarası silme işlemi başarısız oldu.");
                return;
            }
        }
        //--------------------------------------------------------------------



    }
}
