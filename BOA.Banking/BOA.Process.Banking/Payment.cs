using BOA.Types.Banking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOA.Process.Banking
{
    public class Payment
    {
        public PaymentResponse AddPayment(PaymentRequest request)
        {
            Business.Banking.Payment paymentBusiness = new Business.Banking.Payment();
            bool IsSuccess = paymentBusiness.AddPayment(request.paymentContract);

            if (IsSuccess)
            {
                return new PaymentResponse()
                {
                    IsSuccess = true
                };
            }
            return new PaymentResponse()
            {
                IsSuccess = false
            };
        }

        public PaymentResponse GetPayment(PaymentRequest request)
        {
            Business.Banking.Payment paymentBusiness = new Business.Banking.Payment();
            List<PaymentContract> paymentContracts = paymentBusiness.GetPayment(request);

            if (paymentContracts!=null)
            {
                return new PaymentResponse()
                {
                    paymentContracts = paymentContracts,
                    IsSuccess = true
                };
            }
            return new PaymentResponse()
            {
                IsSuccess = false
            };
        }
    }
}
