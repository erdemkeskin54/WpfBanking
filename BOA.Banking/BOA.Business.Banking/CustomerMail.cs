using BOA.Types.Banking;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOA.Business.Banking
{
    public class CustomerMail
    {
        DbOperation dbOperation;
        public CustomerMail()
        {
            if (dbOperation == null) dbOperation = new DbOperation();
        }

        public List<CustomerMailContract> GetCustomerMail(int Id)
        {
            SqlDataReader dr;
            dr = dbOperation.SpGetData("cus.sel_customermails", new SqlParameter[]{
                            new SqlParameter("@Id", Id)
            });

            List<CustomerMailContract> customerMails = new List<CustomerMailContract>();
            CustomerMailContract customerMail;
            while (dr.Read())
            {
                customerMail = new CustomerMailContract();
                customerMail.Id = (int)dr[0];
                customerMail.MailAddress = dr[1].ToString();
                customerMail.CustomerId = (int)dr[2];
                customerMails.Add(customerMail);
            }

            return customerMails;
        }
        public List<CustomerMailContract> AddCustomerMail(CustomerMailContract customerMail)
        {
            SqlDataReader dr;
            dr = dbOperation.SpGetData("cus.ins_customermail", new SqlParameter[]{

                            new SqlParameter("@MailAddress", customerMail.MailAddress),
                            new SqlParameter("@CustomerId", customerMail.CustomerId)
            });

            List<CustomerMailContract> customerMails = new List<CustomerMailContract>();
            CustomerMailContract customerMailTemp;
            while (dr.Read())
            {
                customerMailTemp = new CustomerMailContract();
                customerMailTemp.Id = (int)dr[0];
                customerMailTemp.MailAddress = dr[1].ToString();
                customerMailTemp.CustomerId = (int)dr[2];


                customerMails.Add(customerMailTemp);
            }

            return customerMails;
        }
        public List<CustomerMailContract> UpdCustomerMail(CustomerMailContract customerMail)
        {
            SqlDataReader dr;
            dr = dbOperation.SpGetData("cus.upd_customermail", new SqlParameter[]{
                            new SqlParameter("@Id", customerMail.Id),
                            new SqlParameter("@MailAddress", customerMail.MailAddress),
                            new SqlParameter("@CustomerId", customerMail.CustomerId)
            });

            List<CustomerMailContract> customerMails = new List<CustomerMailContract>();
            CustomerMailContract customerAddressTemp;
            while (dr.Read())
            {
                customerAddressTemp = new CustomerMailContract();
                customerAddressTemp.Id = (int)dr[0];
                customerAddressTemp.MailAddress = dr[1].ToString();
                customerAddressTemp.CustomerId = (int)dr[2];


                customerMails.Add(customerAddressTemp);
            }

            return customerMails;
        }
        public List<CustomerMailContract> DelCustomerMail(CustomerMailContract customerMail)
        {
            SqlDataReader dr;
            dr = dbOperation.SpGetData("cus.del_customermail", new SqlParameter[]{
                            new SqlParameter("@Id", customerMail.Id),
                            new SqlParameter("@CustomerId", customerMail.CustomerId)
            });

            List<CustomerMailContract> customerMails = new List<CustomerMailContract>();
            CustomerMailContract customerAddressTemp;
            while (dr.Read())
            {
                customerAddressTemp = new CustomerMailContract();
                customerAddressTemp.Id = (int)dr[0];
                customerAddressTemp.MailAddress = dr[1].ToString();
                customerAddressTemp.CustomerId = (int)dr[2];

                customerMails.Add(customerAddressTemp);
            }

            return customerMails;
        }
    }
}
