using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOA.Types.Banking
{
    public class PaymentContract
    {
        public int Id { get; set; }
        public int AccountOwnerId { get; set; }
        public int AccountId { get; set; }
        public int Suffix { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public int Type { get; set; }

    }
}
