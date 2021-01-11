using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOA.Types.Banking
{
    public class CustomerPhoneContract
    {
        public int Id { get; set; }

        public string Phone { get; set; }
        public int CustomerId { get; set; }
    }
}
