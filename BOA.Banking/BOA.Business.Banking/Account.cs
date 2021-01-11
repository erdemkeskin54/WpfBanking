using BOA.Types.Banking;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOA.Business.Banking
{
    
    public class Account
    {
        DbOperation dbOperation;
        public Account()
        {
            if (dbOperation == null)
                dbOperation = new DbOperation();
        }

        public List<AccountContract> AccountAll()
        {
            SqlDataReader dr;

            dr = dbOperation.SpGetData("acc.sel_accounts", new SqlParameter[]{
                //new SqlParameter("@AccountOwnerId",  DBNull.Value),
                //new SqlParameter("@Suffix", DBNull.Value)
            });

            List<AccountContract> accountContracts = new List<AccountContract>();
            AccountContract account;
            while (dr.Read())
            {

                account = new AccountContract();
                account.Id = (int)dr[0];
                account.AccountOwnerId = (int)dr[1];
                account.Suffix = (int)dr[2];
                account.FECId = (int)dr[3];
                account.BranchId = (int)dr[4];
                account.Balance = (decimal)dr[5];
                account.OpenDate = (DateTime)dr[6];
                if (dr[7] != DBNull.Value) { account.CloseDate = (DateTime)dr[7]; }
                account.ReasonForClosing = dr[8].ToString();
                account.IBAN = dr[9].ToString();
                account.AccountName = dr[10].ToString();
                account.AccountDescription = dr[11].ToString();
                account.Username = (int)dr[12];
                account.SystemDate = (DateTime)dr[13];

                accountContracts.Add(account);
            }

            return accountContracts;
        }
        public List<AccountContract> AddAccount(AccountContract accountContract)
        {
            SqlDataReader dr;
            dr = dbOperation.SpGetData("acc.ins_account", new SqlParameter[]{

                            new SqlParameter("@AccountOwnerId", accountContract.AccountOwnerId),
                            new SqlParameter("@Suffix", accountContract.Suffix),
                            new SqlParameter("@FECId", accountContract.FECId),
                            new SqlParameter("@BranchId", accountContract.BranchId),
                            new SqlParameter("@Balance", accountContract.Balance),
                            new SqlParameter("@OpenDate", accountContract.OpenDate),
                            new SqlParameter("@CloseDate", accountContract.CloseDate),
                            new SqlParameter("@ReasonForClosing", accountContract.ReasonForClosing),
                            new SqlParameter("@IBAN", accountContract.IBAN),
                            new SqlParameter("@AccountName", accountContract.AccountName),
                            new SqlParameter("@AccountDescription", accountContract.AccountDescription),
                            new SqlParameter("@Username", accountContract.Username)
            });

            List<AccountContract> accountContracts = new List<AccountContract>();
            AccountContract tempaccountContract;
            while (dr.Read())
            {
                tempaccountContract = new AccountContract();
                tempaccountContract.Id = (int)dr[0];
                tempaccountContract.AccountOwnerId = (int)dr[1];
                tempaccountContract.Suffix = (int)dr[2];
                tempaccountContract.FECId = (int)dr[3];
                tempaccountContract.BranchId = (int)dr[4];
                tempaccountContract.Balance = (decimal)dr[5];
                tempaccountContract.OpenDate = (DateTime)dr[6];

                if(DBNull.Value.Equals(dr[7])) {tempaccountContract.CloseDate = null;}
                else{tempaccountContract.CloseDate = (DateTime)dr[7];}

                tempaccountContract.ReasonForClosing = dr[8].ToString();
                tempaccountContract.IBAN = dr[9].ToString();
                tempaccountContract.AccountName = dr[10].ToString();
                tempaccountContract.AccountDescription = dr[11].ToString();
                tempaccountContract.Username = (int)dr[12];
                tempaccountContract.SystemDate = (DateTime)dr[13];
                accountContracts.Add(tempaccountContract);
            }

            return accountContracts;
        }

        public bool DeleteAccount(AccountContract accountContract)
        {
            SqlDataReader dr;

            dr = dbOperation.SpGetData("acc.del_account", new SqlParameter[]{
                            new SqlParameter("@Id", accountContract.Id),
            });
            return true;


            /*
            while (dr.Read())
            {

                account.Id = (int)dr[0];
                account.AccountOwnerId = (int)dr[1];
                account.Suffix = (int)dr[2];
                account.FECId = (int)dr[3];
                account.BranchId = (int)dr[4];
                account.Balance = (decimal)dr[5];
                account.OpenDate = (DateTime)dr[6];
                if (dr[7] != DBNull.Value) { account.CloseDate = (DateTime)dr[7]; }
                account.ReasonForClosing = dr[8].ToString();
                account.IBAN = dr[9].ToString();
                account.AccountName = dr[10].ToString();
                account.AccountDescription = dr[11].ToString();
                account.Username = (int)dr[12];
                account.SystemDate = (DateTime)dr[13];

            }*/

        }

        public AccountContract UpdateAccount(AccountContract accountContract)
        {
            SqlDataReader dr;
            dr = dbOperation.SpGetData("acc.upd_account", new SqlParameter[]{

                            new SqlParameter("@Id", accountContract.Id),
                            new SqlParameter("@AccountOwnerId", accountContract.AccountOwnerId),
                            new SqlParameter("@Suffix", accountContract.Suffix),
                            new SqlParameter("@FECId", accountContract.FECId),
                            new SqlParameter("@BranchId", accountContract.BranchId),
                            new SqlParameter("@OpenDate", accountContract.OpenDate),
                            new SqlParameter("@CloseDate", accountContract.CloseDate),
                            new SqlParameter("@ReasonForClosing", accountContract.ReasonForClosing),
                            new SqlParameter("@IBAN", accountContract.IBAN),
                            new SqlParameter("@AccountName", accountContract.AccountName),
                            new SqlParameter("@AccountDescription", accountContract.AccountDescription),
                            new SqlParameter("@Username", accountContract.Username)
            });

            AccountContract tempaccountContract = new AccountContract();
            while (dr.Read())
            {
                tempaccountContract.Id = (int)dr[0];
                tempaccountContract.AccountOwnerId = (int)dr[1];
                tempaccountContract.Suffix = (int)dr[2];
                tempaccountContract.FECId = (int)dr[3];
                tempaccountContract.BranchId = (int)dr[4];
                tempaccountContract.Balance = (decimal)dr[5];
                tempaccountContract.OpenDate = (DateTime)dr[6];

                if (DBNull.Value.Equals(dr[7])) { tempaccountContract.CloseDate = null; }
                else { tempaccountContract.CloseDate = (DateTime)dr[7]; }

                tempaccountContract.ReasonForClosing = dr[8].ToString();
                tempaccountContract.IBAN = dr[9].ToString();
                tempaccountContract.AccountName = dr[10].ToString();
                tempaccountContract.AccountDescription = dr[11].ToString();
                tempaccountContract.Username = (int)dr[12];
                tempaccountContract.SystemDate = (DateTime)dr[13];
            }
            return tempaccountContract;
        }
        public AccountContract GetAccount(AccountContract accountContract)
        {
            SqlDataReader dr;

            dr = dbOperation.SpGetData("acc.sel_account", new SqlParameter[]{
                            new SqlParameter("@Id", accountContract.Id),
            });

            AccountContract account=new AccountContract();
            
            while (dr.Read())
            {

                account.Id = (int)dr[0];
                account.AccountOwnerId = (int)dr[1];
                account.Suffix = (int)dr[2];
                account.FECId = (int)dr[3];
                account.BranchId = (int)dr[4];
                account.Balance = (decimal)dr[5];
                account.OpenDate = (DateTime)dr[6];
                if (dr[7] != DBNull.Value) { account.CloseDate = (DateTime)dr[7]; }
                account.ReasonForClosing = dr[8].ToString();
                account.IBAN = dr[9].ToString();
                account.AccountName = dr[10].ToString();
                account.AccountDescription = dr[11].ToString();
                account.Username = (int)dr[12];
                account.SystemDate = (DateTime)dr[13];

            }

            return account;
        }





        public List<AccountContract> GetAccounts(AccountContract accountContract)
        {
            SqlDataReader dr;
            int index = 0;
            SqlParameter[] sqlParameters = new SqlParameter[4];
            SqlParameter sqlParameter;
            if (accountContract.AccountOwnerId!=0)
            {
                sqlParameter = new SqlParameter();
                sqlParameter.ParameterName = "@AccountOwnerId";
                sqlParameter.Value = accountContract.AccountOwnerId;
                sqlParameters[index] = sqlParameter;
                index++;
            }
            else if (accountContract.AccountOwnerId == 0)
            {
                sqlParameter = new SqlParameter();
                sqlParameter.ParameterName = "@AccountOwnerId";
                sqlParameter.Value = DBNull.Value;
                sqlParameters[index] = sqlParameter;
                index++;
            }
            if (accountContract.Suffix != 0)
            {
                sqlParameter = new SqlParameter();
                sqlParameter.ParameterName = "@Suffix";
                sqlParameter.Value = accountContract.Suffix;
                sqlParameters[index] = sqlParameter;
                index++;

            }
            else if (accountContract.Suffix == 0)
            {
                sqlParameter = new SqlParameter();
                sqlParameter.ParameterName = "@Suffix";
                sqlParameter.Value = DBNull.Value;
                sqlParameters[index] = sqlParameter;
                index++;
            }
            if (accountContract.BranchId != 0)
            {
                sqlParameter = new SqlParameter();
                sqlParameter.ParameterName = "@BranchId";
                sqlParameter.Value = accountContract.BranchId;
                sqlParameters[index] = sqlParameter;
                index++;

            }
            else if (accountContract.BranchId == 0)
            {
                sqlParameter = new SqlParameter();
                sqlParameter.ParameterName = "@BranchId";
                sqlParameter.Value = DBNull.Value;
                sqlParameters[index] = sqlParameter;
                index++;
            }
            if (accountContract.FECId != 0)
            {
                sqlParameter = new SqlParameter();
                sqlParameter.ParameterName = "@FECId";
                sqlParameter.Value = accountContract.FECId;
                sqlParameters[index] = sqlParameter;
                index++;

            }
            else if (accountContract.FECId == 0)
            {
                sqlParameter = new SqlParameter();
                sqlParameter.ParameterName = "@FECId";
                sqlParameter.Value = DBNull.Value;
                sqlParameters[index] = sqlParameter;
                index++;
            }

            dr = dbOperation.SpGetData("acc.sel_accounts",sqlParameters);

            List<AccountContract> accountContracts = new List<AccountContract>();
            AccountContract account;
            while (dr.Read())
            {

                account = new AccountContract();
                account.Id = (int)dr[0];
                account.AccountOwnerId = (int)dr[1];
                account.Suffix = (int)dr[2];
                account.FECId = (int)dr[3];
                account.BranchId = (int)dr[4];
                account.Balance = (decimal)dr[5];
                account.OpenDate = (DateTime)dr[6];
                if (dr[7] != DBNull.Value) { account.CloseDate = (DateTime)dr[7]; }
                account.ReasonForClosing = dr[8].ToString();
                account.IBAN = dr[9].ToString();
                account.AccountName = dr[10].ToString();
                account.AccountDescription = dr[11].ToString();
                account.Username = (int)dr[12];
                account.SystemDate = (DateTime)dr[13];

                accountContracts.Add(account);
            }

            return accountContracts;
        }
        public int GetAccountLastSuffixNumber(AccountContract accountContract)
        {
            int suffix = 0;
            SqlDataReader dr;

            dr = dbOperation.SpGetData("acc.sel_accountsuffix", new SqlParameter[]{

                            new SqlParameter("@AccountOwnerId", accountContract.AccountOwnerId),
                            new SqlParameter("@FECId", accountContract.FECId)
            });

            while (dr.Read())
            {
                if (DBNull.Value.Equals(dr[0])) { suffix = 0; }
                else { suffix = (int)dr[0]; }

            }

            return suffix;
        }

    }
}
