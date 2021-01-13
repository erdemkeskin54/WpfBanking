using BOA.Types.Banking;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOA.Business.Banking
{
    public class Customer
    {
        DbOperation dbOperation;

        public Customer()
        {
            if (dbOperation == null)
                dbOperation = new DbOperation();
        }


        public List<CustomerContract> CustomerAll()
        {

            SqlDataReader dr;
            
            dr = dbOperation.SpGetData("cus.sel_customer", new SqlParameter[]{
                new SqlParameter("@Id",  DBNull.Value),
                new SqlParameter("@Name", DBNull.Value),
                new SqlParameter("@SurName", DBNull.Value),
                new SqlParameter("@TaxNumber", DBNull.Value)
            });
            
            List<CustomerContract> customers = new List<CustomerContract>();
            CustomerContract customer;
            while (dr.Read())
            {
                //string columname=dr.GetName(0);
                customer = new CustomerContract();
                customer.Id = (int)dr[0];
                customer.Name = dr[1].ToString();
                customer.SurName = dr[2].ToString();
                customer.TaxNumber = dr[3].ToString();
                customer.BirthPlace = dr[4].ToString();
                customer.BirthDate = (DateTime)dr[5];

                customers.Add(customer);
            }

            return customers;

        }


        public List<CustomerContract> GetCustomers(CustomerContract customer)
        {

            SqlDataReader dr;
                dr = dbOperation.SpGetData("cus.sel_customer", new SqlParameter[]{
                new SqlParameter("@Id", customer.Id),
                new SqlParameter("@Name", customer.Name),
                new SqlParameter("@SurName", customer.SurName),
                new SqlParameter("@TaxNumber", customer.TaxNumber)
            });
            

            List<CustomerContract> customers = new List<CustomerContract>();

            while (dr.Read())
            {
                //string columname=dr.GetName(0);
                customer = new CustomerContract();
                customer.Id = (int)dr[0];
                customer.Name = dr[1].ToString();
                customer.SurName = dr[2].ToString();
                customer.TaxNumber = dr[3].ToString();
                customer.BirthPlace = dr[4].ToString();
                customer.BirthDate = (DateTime)dr[5];

                customers.Add(customer);
            }

            return customers;

        }
    }
}
