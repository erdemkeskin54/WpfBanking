using BOA.Types.Banking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOA.Process.Banking
{
    public class FEC
    {
        public FEC()
        {

        }
        public FECResponse GetFECs(FECRequest request)
        {
            Business.Banking.FEC fecBusiness = new Business.Banking.FEC();
            List<FECContract> fECContracts = fecBusiness.GetFECs();

            if (fECContracts != null)
            {
                return new FECResponse()
                {
                    FECContracts = fECContracts,
                    IsSuccess = true
                };
            }
            return new FECResponse()
            {
                IsSuccess = false
            };
        }
    }
}
