using BOA.Types.Banking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOA.Process.Banking
{
    public class Customer
    {
        public Customer()
        {

        }

        public CustomerResponse CustomerAll(CustomerRequest request)
        {
            Business.Banking.Customer customerBusiness = new Business.Banking.Customer();
            List<CustomerContract> customers = customerBusiness.CustomerAll();

            if (customers != null)
            {
                return new CustomerResponse()
                {
                    customers = customers,
                    IsSuccess = true
                };
            }
            return new CustomerResponse()
            {
                IsSuccess = false
            };
        }

        public CustomerResponse GetCustomers(CustomerRequest request)
        {
            Business.Banking.Customer customerBusiness = new Business.Banking.Customer();
            List<CustomerContract> customers = customerBusiness.GetCustomers(request.customer);

            if (customers != null)
            {
                return new CustomerResponse()
                {
                    customers = customers,
                    IsSuccess = true
                };
            }
            return new CustomerResponse()
            {
                IsSuccess = false
            };
        }

    }
}
