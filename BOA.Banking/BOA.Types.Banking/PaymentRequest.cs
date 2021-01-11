using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOA.Types.Banking
{
    public class PaymentRequest : RequestBase
    {
        public PaymentContract  paymentContract { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? FinishDate { get; set; }


    }
}
