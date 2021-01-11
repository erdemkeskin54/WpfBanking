using BOA.Types.Banking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOA.Process.Banking
{
    public class Branch
    {
        public Branch()
        {

        }

        public BranchResponse GetBranches(BranchRequest request)
        {
            Business.Banking.Branch branchBusiness = new Business.Banking.Branch();
            List<BranchContract> branchContracts = branchBusiness.GetBranches();

            if (branchContracts != null)
            {
                return new BranchResponse()
                {
                    branchContracts = branchContracts,
                    IsSuccess = true
                };
            }
            return new BranchResponse()
            {
                IsSuccess = false
            };
        }

    }
}
