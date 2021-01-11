using BOA.Types.Banking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOA.Process.Banking
{
    public class CustomerMail
    {

        public CustomerMailResponse GetCustomerMail(CustomerMailRequest request)
        {
            Business.Banking.CustomerMail customerBusiness = new Business.Banking.CustomerMail();
            List<CustomerMailContract> customerMails = customerBusiness.GetCustomerMail(request.customerMail.CustomerId);

            if (customerMails != null)
            {
                return new CustomerMailResponse()
                {
                    customerMails = customerMails,
                    IsSuccess = true
                };
            }
            return new CustomerMailResponse()
            {
                IsSuccess = false
            };
        }
        public CustomerMailResponse AddCustomerMail(CustomerMailRequest request)
        {
            Business.Banking.CustomerMail customerBusiness = new Business.Banking.CustomerMail();
            List<CustomerMailContract> customerMails = customerBusiness.AddCustomerMail(request.customerMail);

            if (customerMails != null)
            {
                return new CustomerMailResponse()
                {
                    customerMails = customerMails,
                    IsSuccess = true
                };
            }
            return new CustomerMailResponse()
            {
                IsSuccess = false
            };
        }
        public CustomerMailResponse UpdCustomerMail(CustomerMailRequest request)
        {
            Business.Banking.CustomerMail customerBusiness = new Business.Banking.CustomerMail();
            List<CustomerMailContract> customerMails = customerBusiness.UpdCustomerMail(request.customerMail);

            if (customerMails != null)
            {
                return new CustomerMailResponse()
                {
                    customerMails = customerMails,
                    IsSuccess = true
                };
            }
            return new CustomerMailResponse()
            {
                IsSuccess = false
            };
        }
        public CustomerMailResponse DelCustomerMail(CustomerMailRequest request)
        {
            Business.Banking.CustomerMail customerBusiness = new Business.Banking.CustomerMail();
            List<CustomerMailContract> customerMails = customerBusiness.DelCustomerMail(request.customerMail);

            if (customerMails != null)
            {
                return new CustomerMailResponse()
                {
                    IsSuccess = true
                };
            }
            return new CustomerMailResponse()
            {
                IsSuccess = false
            };
        }
    }
}
