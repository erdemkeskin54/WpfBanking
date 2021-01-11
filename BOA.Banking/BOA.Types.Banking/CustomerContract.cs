using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOA.Types.Banking
{
    public class CustomerContract
    {
        public int? Id { get; set; }

        public string Name { get; set; }
        public string SurName { get; set; }


        public string TaxNumber { get; set; }

        public string BirthPlace { get; set; }

        public DateTime BirthDate { get; set; }

    }
}
