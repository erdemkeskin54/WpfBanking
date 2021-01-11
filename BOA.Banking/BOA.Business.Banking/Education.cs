using BOA.Types.Banking.Base;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOA.Business.Banking
{
    public class Education
    {
        DbOperation dbOperation;
        public Education()
        {
            if (dbOperation == null)dbOperation = new DbOperation();
        }

        public List<EducationContract> GetEducations()
        {
            SqlDataReader dr;
            dr = dbOperation.SpGetData("cus.sel_educations", new SqlParameter[]{

            });

            List<EducationContract> educations = new List<EducationContract>();
            EducationContract education;
            while (dr.Read())
            {
                education = new EducationContract();
                education.Id = (int)dr[0];
                education.Name = dr[1].ToString();

                educations.Add(education);
            }

            return educations;
        }




    }
}
