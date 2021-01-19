using BOA.Types.Banking;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOA.Business.Banking
{
    
    public class Transfer
    {
        DbOperation dbOperation;
        public Transfer()
        {
            if (dbOperation == null)
                dbOperation = new DbOperation();
        }

        public bool AddTransfer(TransferContract transferContract)
        {
            int index = 0;
            SqlParameter[] sqlParameters = new SqlParameter[5];
            SqlParameter sqlParameter;

            if (transferContract.AccountFirstId == 0)
            {
                sqlParameter = new SqlParameter();
                sqlParameter.ParameterName = "@AccountFirstId";
                sqlParameter.Value = DBNull.Value;
                sqlParameters[index] = sqlParameter;
                index++;
            }
            else if (transferContract.AccountFirstId != 0)
            {
                sqlParameter = new SqlParameter();
                sqlParameter.ParameterName = "@AccountFirstId";
                sqlParameter.Value = transferContract.AccountFirstId;
                sqlParameters[index] = sqlParameter;
                index++;
            }
            if (transferContract.AccountSecondId == 0)
            {
                sqlParameter = new SqlParameter();
                sqlParameter.ParameterName = "@AccountSecondId";
                sqlParameter.Value = DBNull.Value;
                sqlParameters[index] = sqlParameter;
                index++;
            }
            else if (transferContract.AccountSecondId != 0)
            {
                sqlParameter = new SqlParameter();
                sqlParameter.ParameterName = "@AccountSecondId";
                sqlParameter.Value = transferContract.AccountSecondId;
                sqlParameters[index] = sqlParameter;
                index++;
            }
            if (transferContract.Description == "")
            {
                sqlParameter = new SqlParameter();
                sqlParameter.ParameterName = "@Description";
                sqlParameter.Value = "";
                sqlParameters[index] = sqlParameter;
                index++;
            }
            else if (transferContract.Description != "")
            {
                sqlParameter = new SqlParameter();
                sqlParameter.ParameterName = "@Description";
                sqlParameter.Value = transferContract.Description;
                sqlParameters[index] = sqlParameter;
                index++;
            }
            if (transferContract.Amount == 0)
            {
                sqlParameter = new SqlParameter();
                sqlParameter.ParameterName = "@Amount";
                sqlParameter.Value = DBNull.Value;
                sqlParameters[index] = sqlParameter;
                index++;
            }
            else if (transferContract.Amount != 0)
            {
                sqlParameter = new SqlParameter();
                sqlParameter.ParameterName = "@Amount";
                sqlParameter.Value = transferContract.Amount;
                sqlParameters[index] = sqlParameter;
                index++;
            }
            if (transferContract.Date == null)
            {
                sqlParameter = new SqlParameter();
                sqlParameter.ParameterName = "@Date";
                sqlParameter.Value = DBNull.Value;
                sqlParameters[index] = sqlParameter;
                index++;
            }
            else if (transferContract.Date != null)
            {
                sqlParameter = new SqlParameter();
                sqlParameter.ParameterName = "@Date";
                sqlParameter.Value = transferContract.Date;
                sqlParameters[index] = sqlParameter;
                index++;
            }

            SqlDataReader dr;
            dr = dbOperation.SpGetData("acc.ins_transfer",sqlParameters);

            if (dr.RecordsAffected==-1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

    }
}
