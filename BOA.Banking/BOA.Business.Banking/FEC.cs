using BOA.Types.Banking;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOA.Business.Banking
{
    public class FEC
    {

        DbOperation dbOperation;

        public FEC()
        {
            if (dbOperation == null)
                dbOperation = new DbOperation();
        }

        public List<FECContract> GetFECs()
        {
            SqlDataReader dr;
            dr = dbOperation.SpGetData("acc.sel_fec", new SqlParameter[]{

            });
            List<FECContract> fECContracts = new List<FECContract>();
            FECContract fECContract;
            while (dr.Read())
            {
                fECContract = new FECContract();
                fECContract.Id = (int)dr[0];
                fECContract.Code = dr[1].ToString();
                fECContract.Name = dr[2].ToString();

                fECContracts.Add(fECContract);
            }
            return fECContracts;
        }
    }
}
