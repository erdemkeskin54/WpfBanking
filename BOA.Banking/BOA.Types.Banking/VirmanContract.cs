using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOA.Types.Banking
{
    public class VirmanContract
    {
        public int Id { get; set; }
        public int AccountOwnerId { get; set; }
        public int BranchId { get; set; }
        public int AccountFirstId { get; set; }
        public int AccountSecondId { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
    }
}
