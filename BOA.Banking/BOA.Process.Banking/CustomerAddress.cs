using BOA.Types.Banking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOA.Process.Banking
{
    public class CustomerAddress
    {

        public CustomerAddressResponse GetCustomerAddress(CustomerAddressRequest request)
        {
            Business.Banking.CustomerAddress customerBusiness = new Business.Banking.CustomerAddress();
            List<CustomerAddressContract> customerAddresses = customerBusiness.GetCustomerAddress(request.customerAddress.Id);

            if (customerAddresses != null)
            {
                return new CustomerAddressResponse()
                {
                    customerAddresses = customerAddresses,
                    IsSuccess = true
                };
            }
            return new CustomerAddressResponse()
            {
                IsSuccess = false
            };
        }
        public CustomerAddressResponse AddCustomerAddress(CustomerAddressRequest request)
        {
            Business.Banking.CustomerAddress customerBusiness = new Business.Banking.CustomerAddress();
            List<CustomerAddressContract> customerAddresses = customerBusiness.AddCustomerAddress(request.customerAddress);

            if (customerAddresses != null)
            {
                return new CustomerAddressResponse()
                {
                    customerAddresses = customerAddresses,
                    IsSuccess = true
                };
            }
            return new CustomerAddressResponse()
            {
                IsSuccess = false
            };
        }
        public CustomerAddressResponse UpdCustomerAddress(CustomerAddressRequest request)
        {
            Business.Banking.CustomerAddress customerBusiness = new Business.Banking.CustomerAddress();
            List<CustomerAddressContract> customerAddresses = customerBusiness.UpdCustomerAddress(request.customerAddress);

            if (customerAddresses != null)
            {
                return new CustomerAddressResponse()
                {
                    customerAddresses = customerAddresses,
                    IsSuccess = true
                };
            }
            return new CustomerAddressResponse()
            {
                IsSuccess = false
            };
        }
        public CustomerAddressResponse DelCustomerAddress(CustomerAddressRequest request)
        {
            Business.Banking.CustomerAddress customerBusiness = new Business.Banking.CustomerAddress();
            List<CustomerAddressContract> customerAddresses = customerBusiness.DelCustomerAddress(request.customerAddress);

            if (customerAddresses != null)
            {
                return new CustomerAddressResponse()
                {
                    IsSuccess = true
                };
            }
            return new CustomerAddressResponse()
            {
                IsSuccess = false
            };
        }
    }
}
