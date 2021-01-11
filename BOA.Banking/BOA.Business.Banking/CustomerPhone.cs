using BOA.Types.Banking;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOA.Business.Banking
{
    public class CustomerPhone
    {
        DbOperation dbOperation;
        public CustomerPhone()
        {
            if (dbOperation == null) dbOperation = new DbOperation();
        }

        public List<CustomerPhoneContract> GetCustomerPhone(int Id)
        {
            SqlDataReader dr;
            dr = dbOperation.SpGetData("cus.sel_customerphones", new SqlParameter[]{
                            new SqlParameter("@Id", Id)
            });

            List<CustomerPhoneContract> customerPhones = new List<CustomerPhoneContract>();
            CustomerPhoneContract customerPhone;
            while (dr.Read())
            {
                customerPhone = new CustomerPhoneContract();
                customerPhone.Id = (int)dr[0];
                customerPhone.Phone = dr[1].ToString();

                customerPhones.Add(customerPhone);
            }

            return customerPhones;
        }
        public List<CustomerPhoneContract> AddCustomerPhone(CustomerPhoneContract customerMail)
        {
            SqlDataReader dr;
            dr = dbOperation.SpGetData("cus.ins_customerphone", new SqlParameter[]{

                            new SqlParameter("@Phone", customerMail.Phone),
                            new SqlParameter("@CustomerId", customerMail.CustomerId)
            });

            List<CustomerPhoneContract> customerPhones = new List<CustomerPhoneContract>();
            CustomerPhoneContract customerPhoneTemp;
            while (dr.Read())
            {
                customerPhoneTemp = new CustomerPhoneContract();
                customerPhoneTemp.Id = (int)dr[0];
                customerPhoneTemp.Phone = dr[1].ToString();
                customerPhoneTemp.CustomerId = (int)dr[2];


                customerPhones.Add(customerPhoneTemp);
            }

            return customerPhones;
        }
        public List<CustomerPhoneContract> UpdCustomerPhone(CustomerPhoneContract customerPhone)
        {
            SqlDataReader dr;
            dr = dbOperation.SpGetData("cus.upd_customerphone", new SqlParameter[]{
                            new SqlParameter("@Id", customerPhone.Id),
                            new SqlParameter("@Phone", customerPhone.Phone),
                            new SqlParameter("@CustomerId", customerPhone.CustomerId)
            });

            List<CustomerPhoneContract> customerPhones = new List<CustomerPhoneContract>();
            CustomerPhoneContract customerPhoneTemp;
            while (dr.Read())
            {
                customerPhoneTemp = new CustomerPhoneContract();
                customerPhoneTemp.Id = (int)dr[0];
                customerPhoneTemp.Phone = dr[1].ToString();
                customerPhoneTemp.CustomerId = (int)dr[2];


                customerPhones.Add(customerPhoneTemp);
            }

            return customerPhones;
        }
        public List<CustomerPhoneContract> DelCustomerPhone(CustomerPhoneContract customerPhone)
        {
            SqlDataReader dr;
            dr = dbOperation.SpGetData("cus.del_customerphone", new SqlParameter[]{
                            new SqlParameter("@Id", customerPhone.Id),
                            new SqlParameter("@CustomerId", customerPhone.CustomerId)
            });

            List<CustomerPhoneContract> customerPhones = new List<CustomerPhoneContract>();
            CustomerPhoneContract customerPhoneTemp;
            while (dr.Read())
            {
                customerPhoneTemp = new CustomerPhoneContract();
                customerPhoneTemp.Id = (int)dr[0];
                customerPhoneTemp.Phone = dr[1].ToString();
                customerPhoneTemp.CustomerId = (int)dr[2];

                customerPhones.Add(customerPhoneTemp);
            }

            return customerPhones;
        }
    }
}
