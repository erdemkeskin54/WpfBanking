using BOA.Types.Banking;
using BOA.Types.Banking.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOA.Types.Banking
{
    public class CustomerMailResponse : ResponseBase
    {
        public List<CustomerMailContract> customerMails { get; set; }



    }
}
