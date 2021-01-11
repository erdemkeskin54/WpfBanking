using BOA.Types.Banking;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOA.Business.Banking
{
    public class CustomerAddress
    {
        DbOperation dbOperation;
        public CustomerAddress()
        {
            if (dbOperation == null)
                dbOperation = new DbOperation();
        }

        public List<CustomerAddressContract> GetCustomerAddress(int Id)
        {
            SqlDataReader dr;
            dr = dbOperation.SpGetData("cus.sel_customeraddresses", new SqlParameter[]{
                            new SqlParameter("@Id", Id)

            });

            List<CustomerAddressContract> customerAddresses = new List<CustomerAddressContract>();
            CustomerAddressContract customerAddress;
            while (dr.Read())
            {
                customerAddress = new CustomerAddressContract();
                customerAddress.Id = (int)dr[0];
                customerAddress.Title = dr[1].ToString();
                customerAddress.Address = dr[2].ToString();
                customerAddress.CustomerId = (int)dr[3];


                customerAddresses.Add(customerAddress);
            }

            return customerAddresses;
        }
        public List<CustomerAddressContract> AddCustomerAddress(CustomerAddressContract customerAddress)
        {
            SqlDataReader dr;
            dr = dbOperation.SpGetData("cus.ins_customeraddress", new SqlParameter[]{

                            new SqlParameter("@Title", customerAddress.Title),
                            new SqlParameter("@Address", customerAddress.Address),
                            new SqlParameter("@CustomerId", customerAddress.CustomerId)
            });

            List<CustomerAddressContract> customerAddresses = new List<CustomerAddressContract>();
            CustomerAddressContract customerAddressTemp;
            while (dr.Read())
            {
                customerAddressTemp = new CustomerAddressContract();
                customerAddressTemp.Id = (int)dr[0];
                customerAddressTemp.Title = dr[1].ToString();
                customerAddressTemp.Address = dr[2].ToString();
                customerAddressTemp.CustomerId = (int)dr[3];


                customerAddresses.Add(customerAddressTemp);
            }

            return customerAddresses;
        }
        public List<CustomerAddressContract> DelCustomerAddress(CustomerAddressContract customerAddress)
        {
            SqlDataReader dr;
            dr = dbOperation.SpGetData("cus.del_customeraddress", new SqlParameter[]{
                            new SqlParameter("@Id", customerAddress.Id),
                            new SqlParameter("@CustomerId", customerAddress.CustomerId)
            });

            List<CustomerAddressContract> customerAddresses = new List<CustomerAddressContract>();
            CustomerAddressContract customerAddressTemp;
            while (dr.Read())
            {
                customerAddressTemp = new CustomerAddressContract();
                customerAddressTemp.Id = (int)dr[0];
                customerAddressTemp.Title = dr[1].ToString();
                customerAddressTemp.Address = dr[2].ToString();
                customerAddressTemp.CustomerId = (int)dr[3];


                customerAddresses.Add(customerAddressTemp);
            }

            return customerAddresses;
        }
        public List<CustomerAddressContract> UpdCustomerAddress(CustomerAddressContract customerAddress)
        {
            SqlDataReader dr;
            dr = dbOperation.SpGetData("cus.upd_customeraddress", new SqlParameter[]{
                            new SqlParameter("@Id", customerAddress.Id),
                            new SqlParameter("@Title", customerAddress.Title),
                            new SqlParameter("@Address", customerAddress.Address),
                            new SqlParameter("@CustomerId", customerAddress.CustomerId)
            });

            List<CustomerAddressContract> customerAddresses = new List<CustomerAddressContract>();
            CustomerAddressContract customerAddressTemp;
            while (dr.Read())
            {
                customerAddressTemp = new CustomerAddressContract();
                customerAddressTemp.Id = (int)dr[0];
                customerAddressTemp.Title = dr[1].ToString();
                customerAddressTemp.Address = dr[2].ToString();
                customerAddressTemp.CustomerId = (int)dr[3];


                customerAddresses.Add(customerAddressTemp);
            }

            return customerAddresses;
        }


    }
}
