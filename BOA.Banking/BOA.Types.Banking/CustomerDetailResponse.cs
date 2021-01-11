using BOA.Types.Banking;
using BOA.Types.Banking.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOA.Types.Banking
{
    public class CustomerDetailResponse: ResponseBase
    {
        public CustomerDetailContract customerDetail { get; set; }

        // public List<CustomerDetailJob> jobs { get; set; }
        // public List<CustomerDetailEducation> educations { get; set; }



    }
}
