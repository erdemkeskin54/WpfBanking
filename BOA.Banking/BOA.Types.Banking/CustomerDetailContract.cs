using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOA.Types.Banking
{
    public class CustomerDetailContract
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string SurName { get; set; }

        public string TaxNumber { get; set; }

        public string BirthPlace { get; set; }

        public DateTime BirthDate { get; set; }

        public string MomName { get; set; }
        public string FatherName { get; set; }

        public int? EducationId { get; set; }
        public int? JobId { get; set; }


        // public List<CustomerAddress> CustomerAddresses { get; set; }
        // public List<CustomerMail> CustomerMails { get; set; }
        // public List<CustomerPhone> CustomerPhones { get; set; }


    }
}
