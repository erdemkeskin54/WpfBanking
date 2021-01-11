using BOA.Types.Banking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOA.Process.Banking
{
    public class CustomerPhone
    {
        public CustomerPhoneResponse GetCustomerPhone(CustomerPhoneRequest request)
        {
            Business.Banking.CustomerPhone customerBusiness = new Business.Banking.CustomerPhone();
            List<CustomerPhoneContract> customerPhones = customerBusiness.GetCustomerPhone(request.customerPhone.CustomerId);

            if (customerPhones != null)
            {
                return new CustomerPhoneResponse()
                {
                    customerPhones = customerPhones,
                    IsSuccess = true
                };
            }
            return new CustomerPhoneResponse()
            {
                IsSuccess = false
            };
        }
        public CustomerPhoneResponse AddCustomerPhone(CustomerPhoneRequest request)
        {
            Business.Banking.CustomerPhone customerBusiness = new Business.Banking.CustomerPhone();
            List<CustomerPhoneContract> customerPhones = customerBusiness.AddCustomerPhone(request.customerPhone);

            if (customerPhones != null)
            {
                return new CustomerPhoneResponse()
                {
                    customerPhones = customerPhones,
                    IsSuccess = true
                };
            }
            return new CustomerPhoneResponse()
            {
                IsSuccess = false
            };
        }
        public CustomerPhoneResponse UpdCustomerPhone(CustomerPhoneRequest request)
        {
            Business.Banking.CustomerPhone customerBusiness = new Business.Banking.CustomerPhone();
            List<CustomerPhoneContract> customerPhones = customerBusiness.UpdCustomerPhone(request.customerPhone);

            if (customerPhones != null)
            {
                return new CustomerPhoneResponse()
                {
                    customerPhones = customerPhones,
                    IsSuccess = true
                };
            }
            return new CustomerPhoneResponse()
            {
                IsSuccess = false
            };
        }
        public CustomerPhoneResponse DelCustomerPhone(CustomerPhoneRequest request)
        {
            Business.Banking.CustomerPhone customerBusiness = new Business.Banking.CustomerPhone();
            List<CustomerPhoneContract> customerPhones = customerBusiness.DelCustomerPhone(request.customerPhone);

            if (customerPhones != null)
            {
                return new CustomerPhoneResponse()
                {
                    IsSuccess = true
                };
            }
            return new CustomerPhoneResponse()
            {
                IsSuccess = false
            };
        }
    }
}
