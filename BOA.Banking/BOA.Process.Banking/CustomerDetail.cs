using BOA.Types.Banking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOA.Process.Banking
{
    public class CustomerDetail
    {
        //CustomerDetail İşlemleri
        public CustomerDetailResponse GetCustomerDetail(CustomerDetailRequest request)
        {
            Business.Banking.CustomerDetail customerBusiness = new Business.Banking.CustomerDetail();
            Types.Banking.CustomerDetailContract customerDetail = customerBusiness.GetCustomerDetail(request.customerDetail.Id);

            if (customerDetail != null)
            {
                return new CustomerDetailResponse()
                {
                    customerDetail = customerDetail,
                    IsSuccess = true
                };
            }
            return new CustomerDetailResponse()
            {
                IsSuccess = false
            };
        }
        public CustomerDetailResponse AddCustomerDetail(CustomerDetailRequest request)
        {
            Business.Banking.CustomerDetail customerBusiness = new Business.Banking.CustomerDetail();
            Types.Banking.CustomerDetailContract customerDetail = customerBusiness.AddCustomerDetail(request.customerDetail);

            if (customerDetail != null)
            {
                return new CustomerDetailResponse()
                {
                    customerDetail = customerDetail,
                    IsSuccess = true
                };
            }
            return new CustomerDetailResponse()
            {
                IsSuccess = false
            };
        }
        public CustomerDetailResponse UpdateCustomerDetail(CustomerDetailRequest request)
        {
            Business.Banking.CustomerDetail customerBusiness = new Business.Banking.CustomerDetail();
            Types.Banking.CustomerDetailContract customerDetail = customerBusiness.UpdateCustomerDetail(request.customerDetail);

            if (customerDetail != null)
            {
                return new CustomerDetailResponse()
                {
                    customerDetail = customerDetail,
                    IsSuccess = true
                };
            }
            return new CustomerDetailResponse()
            {
                IsSuccess = false
            };
        }
        public CustomerDetailResponse DeleteCustomerDetail(CustomerDetailRequest request)
        {
            Business.Banking.CustomerDetail customerBusiness = new Business.Banking.CustomerDetail();
            Types.Banking.CustomerDetailContract customerDetail = customerBusiness.DeleteCustomerDetail(request.customerDetail);

            if (customerDetail != null)
            {
                return new CustomerDetailResponse()
                {
                    customerDetail = customerDetail,
                    IsSuccess = true
                };
            }
            return new CustomerDetailResponse()
            {
                IsSuccess = false
            };
        }
        //----------------------------------------------------------------------------------
    }

}
