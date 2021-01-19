using BOA.Types.Banking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOA.Process.Banking
{
    public class Transfer
    {
        public TransferResponse AddTransfer(TransferRequest request)
        {
            Business.Banking.Transfer virmanBusiness = new Business.Banking.Transfer();
            bool IsSuccess = virmanBusiness.AddTransfer(request.transferContract);

            if (IsSuccess)
            {
                return new TransferResponse()
                {
                    IsSuccess = true
                };
            }
            return new TransferResponse()
            {
                IsSuccess = false
            };
        }

    }
}
