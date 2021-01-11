using BOA.Types.Banking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOA.Process.Banking
{
    public class Virman
    {
        public VirmanResponse AddVirman(VirmanRequest request)
        {
            Business.Banking.Virman virmanBusiness = new Business.Banking.Virman();
            bool IsSuccess = virmanBusiness.AddVirman(request.virmanContract);

            if (IsSuccess)
            {
                return new VirmanResponse()
                {
                    IsSuccess = true
                };
            }
            return new VirmanResponse()
            {
                IsSuccess = false
            };
        }

    }
}
