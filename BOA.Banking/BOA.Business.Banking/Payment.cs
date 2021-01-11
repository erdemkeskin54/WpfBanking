using BOA.Types.Banking;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOA.Business.Banking
{
    
    public class Payment
    {
        DbOperation dbOperation;
        public Payment()
        {
            if (dbOperation == null)
                dbOperation = new DbOperation();
        }

        public bool AddPayment(PaymentContract paymentContract)
        {
            SqlDataReader dr;
            dr = dbOperation.SpGetData("acc.ins_payment", new SqlParameter[]{

                            new SqlParameter("@AccountId", paymentContract.AccountId),
                            new SqlParameter("@AccountOwnerId", paymentContract.AccountOwnerId),
                            new SqlParameter("@TransactionDate", paymentContract.TransactionDate),
                            new SqlParameter("@Description", paymentContract.Description),
                            new SqlParameter("@Amount", paymentContract.Amount),
                            new SqlParameter("@Type", paymentContract.Type)
            });

            if (dr.HasRows)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public List<PaymentContract> GetPayment(PaymentRequest request)
        {
            int index = 0;
            SqlParameter[] sqlParameters = new SqlParameter[7];
            SqlParameter sqlParameter;

            if (request.paymentContract.Id == 0)
            {
                sqlParameter = new SqlParameter();
                sqlParameter.ParameterName = "@Id";
                sqlParameter.Value = DBNull.Value;
                sqlParameters[index] = sqlParameter;
                index++;
            }
            else if (request.paymentContract.Id != 0)
            {
                sqlParameter = new SqlParameter();
                sqlParameter.ParameterName = "@Id";
                sqlParameter.Value = request.paymentContract.Id;
                sqlParameters[index] = sqlParameter;
                index++;
            }
            if (request.paymentContract.AccountId == 0)
            {
                sqlParameter = new SqlParameter();
                sqlParameter.ParameterName = "@AccountId";
                sqlParameter.Value = DBNull.Value;
                sqlParameters[index] = sqlParameter;
                index++;
            }
            else if (request.paymentContract.AccountId != 0)
            {
                sqlParameter = new SqlParameter();
                sqlParameter.ParameterName = "@AccountId";
                sqlParameter.Value = request.paymentContract.AccountId;
                sqlParameters[index] = sqlParameter;
                index++;
            }
            if (request.paymentContract.Suffix == 0)
            {
                sqlParameter = new SqlParameter();
                sqlParameter.ParameterName = "@Suffix";
                sqlParameter.Value = DBNull.Value;
                sqlParameters[index] = sqlParameter;
                index++;
            }
            else if (request.paymentContract.Suffix != 0)
            {
                sqlParameter = new SqlParameter();
                sqlParameter.ParameterName = "@Suffix";
                sqlParameter.Value = request.paymentContract.Suffix;
                sqlParameters[index] = sqlParameter;
                index++;
            }
            if (request.paymentContract.Type == 0)
            {
                sqlParameter = new SqlParameter();
                sqlParameter.ParameterName = "@Type";
                sqlParameter.Value = DBNull.Value;
                sqlParameters[index] = sqlParameter;
                index++;
            }
            else if (request.paymentContract.Type != 0)
            {
                sqlParameter = new SqlParameter();
                sqlParameter.ParameterName = "@Type";
                sqlParameter.Value = request.paymentContract.Type;
                sqlParameters[index] = sqlParameter;
                index++;
            }
            if (request.paymentContract.AccountOwnerId == 0)
            {
                sqlParameter = new SqlParameter();
                sqlParameter.ParameterName = "@AccountOwnerId";
                sqlParameter.Value = DBNull.Value;
                sqlParameters[index] = sqlParameter;
                index++;
            }
            else if (request.paymentContract.AccountOwnerId != 0)
            {
                sqlParameter = new SqlParameter();
                sqlParameter.ParameterName = "@AccountOwnerId";
                sqlParameter.Value = request.paymentContract.AccountOwnerId;
                sqlParameters[index] = sqlParameter;
                index++;
            }
            if (request.StartDate == null)
            {
                sqlParameter = new SqlParameter();
                sqlParameter.ParameterName = "@StartDate";
                sqlParameter.Value = DBNull.Value;
                sqlParameters[index] = sqlParameter;
                index++;
            }
            else if (request.StartDate != null)
            {
                sqlParameter = new SqlParameter();
                sqlParameter.ParameterName = "@StartDate";
                sqlParameter.Value = request.StartDate;
                sqlParameters[index] = sqlParameter;
                index++;
            }
            if (request.FinishDate == null)
            {
                sqlParameter = new SqlParameter();
                sqlParameter.ParameterName = "@FinishDate";
                sqlParameter.Value = DBNull.Value;
                sqlParameters[index] = sqlParameter;
                index++;
            }
            else if (request.StartDate != null)
            {
                sqlParameter = new SqlParameter();
                sqlParameter.ParameterName = "@FinishDate";
                sqlParameter.Value = request.FinishDate;
                sqlParameters[index] = sqlParameter;
                index++;
            }
            

            SqlDataReader dr;
            dr = dbOperation.SpGetData("acc.sel_payment",sqlParameters);

            List<PaymentContract> paymentContracts = new List<PaymentContract>();
            PaymentContract paymentContract;
            while (dr.Read())
            {
                
                paymentContract = new PaymentContract();
                
                paymentContract.Id = (int)dr[0];
                paymentContract.AccountId = (int)dr[1];
                paymentContract.AccountOwnerId = (int)dr[2];
                paymentContract.Suffix = (int)dr[3];
                paymentContract.TransactionDate = (DateTime)dr[4];
                paymentContract.Description = dr[5].ToString();
                paymentContract.Amount = (decimal)dr[6];
                paymentContract.Type = (int)dr[7];


                paymentContracts.Add(paymentContract);
                
            }

            return paymentContracts;
        }
    }
}
