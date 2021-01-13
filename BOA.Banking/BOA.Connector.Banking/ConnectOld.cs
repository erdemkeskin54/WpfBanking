using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOA.Types.Banking;
using BOA.Process.Banking;
using System.Reflection;

namespace BOA.Connector.Banking
{
    public class ConnectOld
    {
        //Login
        public ResponseBase Execute(RequestBase request)
        {
            var response = new ResponseBase();
            Type type = request.GetType();
            if (type.FullName == "BOA.Types.Banking.LoginRequest")
            {
                var pr = new BOA.Process.Banking.Login();
                if (request.MethodName == "GetLogin")
                {response = pr.GetLogin((LoginRequest)request);}
            }
            return response;
        }


        //Customer, CustomerDetail
        public CustomerResponse ExecuteCustomer(RequestBase request)
        {
            var response = new CustomerResponse();
            Type type = request.GetType();
            if (type.FullName == "BOA.Types.Banking.CustomerRequest")
            {
                var pr = new BOA.Process.Banking.Customer();
                if (request.MethodName == "CustomerAll")
                {response = pr.CustomerAll((CustomerRequest)request);}
                else if (request.MethodName == "GetCustomers")
                { response = pr.GetCustomers((CustomerRequest)request); }
                
            }
            return response;
        }
        public CustomerDetailResponse ExecuteCustomerDetail(RequestBase request)
        {
            var response = new CustomerDetailResponse();

            Type type = request.GetType();

            if (type.FullName == "BOA.Types.Banking.CustomerDetailRequest")
            {

                var pr = new BOA.Process.Banking.CustomerDetail();

                if (request.MethodName == "GetCustomerDetail")
                {
                    response = pr.GetCustomerDetail((CustomerDetailRequest)request);
                }
                else if (request.MethodName == "UpdateCustomerDetail")
                {
                    response = pr.UpdateCustomerDetail((CustomerDetailRequest)request);
                }
                else if (request.MethodName == "AddCustomerDetail")
                {
                    response = pr.AddCustomerDetail((CustomerDetailRequest)request);
                }
                else if (request.MethodName == "DeleteCustomerDetail")
                {
                    response = pr.DeleteCustomerDetail((CustomerDetailRequest)request);
                }

            }
            return response;
        }
        public CustomerAddressResponse ExecuteGetCustomerAddress(CustomerAddressRequest request)
        {
            var response = new CustomerAddressResponse();

            Type type = request.GetType();

            if (type.FullName == "BOA.Types.Banking.CustomerAddressRequest")
            {
                var pr = new BOA.Process.Banking.CustomerAddress();

                if (request.MethodName == "GetCustomerAddress")
                {
                    response = pr.GetCustomerAddress((CustomerAddressRequest)request);
                }
                else if (request.MethodName == "AddCustomerAddress")
                {
                    response = pr.AddCustomerAddress((CustomerAddressRequest)request);
                }
                else if (request.MethodName == "UpdCustomerAddress")
                {
                    response = pr.UpdCustomerAddress((CustomerAddressRequest)request);
                }
                else if (request.MethodName == "DelCustomerAddress")
                {
                    response = pr.DelCustomerAddress((CustomerAddressRequest)request);
                }
            }
            return response;
        }
        public CustomerPhoneResponse ExecuteGetCustomerPhone(CustomerPhoneRequest request)
        {
            var response = new CustomerPhoneResponse();

            Type type = request.GetType();

            if (type.FullName == "BOA.Types.Banking.CustomerPhoneRequest")
            {
                var pr = new BOA.Process.Banking.CustomerPhone();

                if (request.MethodName == "GetCustomerPhone")
                {
                    response = pr.GetCustomerPhone((CustomerPhoneRequest)request);
                }
                else if (request.MethodName == "AddCustomerPhone")
                {
                    response = pr.AddCustomerPhone((CustomerPhoneRequest)request);
                }
                else if (request.MethodName == "UpdCustomerPhone")
                {
                    response = pr.UpdCustomerPhone((CustomerPhoneRequest)request);
                }
                else if (request.MethodName == "DelCustomerPhone")
                {
                    response = pr.DelCustomerPhone((CustomerPhoneRequest)request);
                }
            }
            return response;
        }
        public CustomerMailResponse ExecuteGetCustomerMail(CustomerMailRequest request)
        {
            var response = new CustomerMailResponse();

            Type type = request.GetType();

            if (type.FullName == "BOA.Types.Banking.CustomerMailRequest")
            {
                var pr = new BOA.Process.Banking.CustomerMail();

                if (request.MethodName == "GetCustomerMail")
                {
                    response = pr.GetCustomerMail((CustomerMailRequest)request);
                }
                else if (request.MethodName == "DelCustomerMail")
                {
                    response = pr.DelCustomerMail((CustomerMailRequest)request);
                }
                else if (request.MethodName == "UpdCustomerMail")
                {
                    response = pr.UpdCustomerMail((CustomerMailRequest)request);
                }
                else if (request.MethodName == "AddCustomerMail")
                {
                    response = pr.AddCustomerMail((CustomerMailRequest)request);
                }
            }
            return response;
        }


        //Education
        public EducationResponse ExecuteGetEducations(RequestBase request)
        {
            var response = new EducationResponse();

            Type type = request.GetType();

            if (type.FullName == "BOA.Types.Banking.EducationRequest")
            {
                var pr = new BOA.Process.Banking.Education();

                if (request.MethodName == "GetEducations")
                {
                    response = pr.GetEducations((EducationRequest)request);
                }
            }
            return response;
        }


        //Job
        public JobResponse ExecuteGetJobs(JobRequest request)
        {
            var response = new JobResponse();

            Type type = request.GetType();

            if (type.FullName == "BOA.Types.Banking.JobRequest")
            {
                var pr = new BOA.Process.Banking.Job();

                if (request.MethodName == "GetJobs")
                {
                    response = pr.GetJobs((JobRequest)request);
                }
            }
            return response;
        }


        //Branch
        public BranchResponse ExecuteBranch(BranchRequest request)
        {
            var response = new BranchResponse();

            Type type = request.GetType();

            if (type.FullName == "BOA.Types.Banking.BranchRequest")
            {
                var pr = new BOA.Process.Banking.Branch();

                if (request.MethodName == "GetBranches")
                {
                    response = pr.GetBranches((BranchRequest)request);
                }
            }
            return response;
        }


        //FEC
        public FECResponse ExecuteFEC(FECRequest request)
        {
            var response = new FECResponse();

            Type type = request.GetType();

            if (type.FullName == "BOA.Types.Banking.FECRequest")
            {
                var pr = new BOA.Process.Banking.FEC();

                if (request.MethodName == "GetFECs")
                {
                    response = pr.GetFECs((FECRequest)request);
                }
            }
            return response;
        }
        
        
        //PaymentTypes
        public PaymentTypesResponse ExecutePaymentTypes(PaymentTypesRequest request)
        {
            var response = new PaymentTypesResponse();

            Type type = request.GetType();

            if (type.FullName == "BOA.Types.Banking.PaymentTypesRequest")
            {
                var pr = new BOA.Process.Banking.PaymentTypes();

                if (request.MethodName == "GetPaymentTypes")
                {
                    response = pr.GetPaymentTypes((PaymentTypesRequest)request);
                }
            }
            return response;
        }


        //Account
        public AccountResponse ExecuteAccount(AccountRequest request)
        {
            var response = new AccountResponse();

            Type type = request.GetType();

            if (type.FullName == "BOA.Types.Banking.AccountRequest")
            {
                var pr = new BOA.Process.Banking.Account();
                if (request.MethodName == "AccountAll")
                {
                    response = pr.AccountAll((AccountRequest)request);
                }
                else if (request.MethodName == "GetAccounts")
                {
                    response = pr.GetAccounts((AccountRequest)request);
                }
                else if (request.MethodName == "AddAccount")
                {
                    response = pr.AddAccount((AccountRequest)request);
                }
                else if (request.MethodName == "UpdateAccount")
                {
                    response = pr.UpdateAccount((AccountRequest)request);
                }
                else if (request.MethodName == "DeleteAccount")
                {
                    response = pr.DeleteAccount((AccountRequest)request);
                }
                else if (request.MethodName == "GetAccountLastSuffixNumber")
                {
                    response = pr.GetAccountLastSuffixNumber((AccountRequest)request);
                }
                else if (request.MethodName == "GetAccount")
                {
                    response = pr.GetAccount((AccountRequest)request);
                }
            }
            return response;
        }


        //Payment
        public PaymentResponse ExecutePayment(PaymentRequest request)
        {
            var response = new PaymentResponse();

            Type type = request.GetType();

            if (type.FullName == "BOA.Types.Banking.PaymentRequest")
            {
                var pr = new BOA.Process.Banking.Payment();
                if (request.MethodName == "AddPayment")
                {
                    response = pr.AddPayment((PaymentRequest)request);
                }
                else if (request.MethodName == "GetPayment")
                {
                    response = pr.GetPayment((PaymentRequest)request);
                }
            }
            return response;
        }


        //Virman
        public VirmanResponse ExecuteVirman(VirmanRequest request)
        {
            var response = new VirmanResponse();

            Type type = request.GetType();

            if (type.FullName == "BOA.Types.Banking.VirmanRequest")
            {
                var pr = new BOA.Process.Banking.Virman();
                if (request.MethodName == "AddVirman")
                {
                    response = pr.AddVirman((VirmanRequest)request);
                }
            }
            return response;
        }


    }
}
