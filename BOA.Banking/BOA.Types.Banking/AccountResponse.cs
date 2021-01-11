using BOA.Types.Banking;
using BOA.Types.Banking.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOA.Types.Banking
{
    public class AccountResponse : ResponseBase
    {
        public List<AccountContract> accountContracts { get; set; }
        public int suffix { get; set; }
        public List<int> accountSuffixes { get; set; }

        public AccountContract accountContract { get; set; }
    }
}
