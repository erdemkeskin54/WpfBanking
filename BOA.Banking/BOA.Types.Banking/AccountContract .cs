using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOA.Types.Banking
{
    public class AccountContract
    {
        public int Id { get; set; }
        public int AccountOwnerId { get; set; }
        public int Suffix { get; set; }
        public int FECId { get; set; }
        public int BranchId { get; set; }
        public decimal? Balance { get; set; }
        public DateTime OpenDate { get; set; }
        public DateTime? CloseDate { get; set; }
        public string ReasonForClosing { get; set; }
        public string IBAN { get; set; }
        public string AccountName { get; set; }
        public string AccountDescription { get; set; }
        public int Username { get; set; }
        public DateTime? SystemDate { get; set; }
        
    }
}
