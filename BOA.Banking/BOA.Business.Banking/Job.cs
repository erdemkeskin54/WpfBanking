using BOA.Types.Banking;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOA.Business.Banking
{
    public class Job
    {
        DbOperation dbOperation;

        public Job()
        {
            if (dbOperation == null)
                dbOperation = new DbOperation();
        }

        public List<JobContract> GetJobs()
        {
            SqlDataReader dr;
            dr = dbOperation.SpGetData("cus.sel_jobs", new SqlParameter[]{

            });
            List<JobContract> jobs = new List<JobContract>();
            JobContract job;
            while (dr.Read())
            {
                job = new JobContract();
                job.Id = (int)dr[0];
                job.Name = dr[1].ToString();

                jobs.Add(job);
            }
            return jobs;
        }
    }
}
