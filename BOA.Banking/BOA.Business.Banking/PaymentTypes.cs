using BOA.Types.Banking;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOA.Business.Banking
{
    public class PaymentTypes
    {

        DbOperation dbOperation;

        public PaymentTypes()
        {
            if (dbOperation == null)
                dbOperation = new DbOperation();
        }

        public List<PaymentTypesContract> GetPaymentTypes()
        {
            SqlDataReader dr;
            dr = dbOperation.SpGetData("acc.sel_paymenttypes", new SqlParameter[]{

            });
            List<PaymentTypesContract> paymentTypesContracts = new List<PaymentTypesContract>();
            PaymentTypesContract paymentTypesContract;
            while (dr.Read())
            {
                paymentTypesContract = new PaymentTypesContract();
                paymentTypesContract.Id = (int)dr[0];
                paymentTypesContract.Name = dr[1].ToString();
                paymentTypesContract.Code = dr[2].ToString();

                paymentTypesContracts.Add(paymentTypesContract);
            }
            return paymentTypesContracts;
        }
    }
}
