using BOA.Types.Banking;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BOA.Business.Banking
{
    public class Login
    {
        DbOperation dbOperation;

        public Login()
        {
            if (dbOperation == null)
                dbOperation = new DbOperation();
        }

       
        public bool GetLogin(LoginContract loginContract)
        {
            int dr = dbOperation.SpLogin("cus.sel_login", new SqlParameter[]{
                new SqlParameter("@UserName", loginContract.UserName),
                new SqlParameter("@Password", ComputeSha256Hash(loginContract.Password))
            });
            if (dr == 1)
            {
                return true;
            }
            return false;
        }
        static string ComputeSha256Hash(string rawData)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
