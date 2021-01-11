using BOA.Types.Banking;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOA.Business.Banking
{
    public class Branch
    {
        DbOperation dbOperation;

        public Branch()
        {
            if (dbOperation == null)
                dbOperation = new DbOperation();
        }

        public List<BranchContract> GetBranches()
        {
            SqlDataReader dr;
            dr = dbOperation.SpGetData("acc.sel_branches", new SqlParameter[]{

            });
            List<BranchContract> branchContracts = new List<BranchContract>();
            BranchContract branchContract;
            while (dr.Read())
            {
                branchContract = new BranchContract();
                branchContract.Id = (int)dr[0];
                branchContract.Code = dr[1].ToString();
                branchContract.Name = dr[2].ToString();

                branchContracts.Add(branchContract);
            }
            return branchContracts;
        }
    }
}
