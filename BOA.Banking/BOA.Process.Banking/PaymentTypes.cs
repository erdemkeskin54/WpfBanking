using BOA.Types.Banking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOA.Process.Banking
{
    public class PaymentTypes
    {
        public PaymentTypes()
        {

        }
        public PaymentTypesResponse GetPaymentTypes(PaymentTypesRequest request)
        {
            Business.Banking.PaymentTypes paymentTypesBusiness = new Business.Banking.PaymentTypes();
            List<PaymentTypesContract> paymentTypesContracts = paymentTypesBusiness.GetPaymentTypes();

            if (paymentTypesContracts != null)
            {
                return new PaymentTypesResponse()
                {
                    paymentTypesContracts = paymentTypesContracts,
                    IsSuccess = true
                };
            }
            return new PaymentTypesResponse()
            {
                IsSuccess = false
            };
        }
    }
}
