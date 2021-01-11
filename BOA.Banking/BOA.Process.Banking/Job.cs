using BOA.Types.Banking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOA.Process.Banking
{
    public class Job
    {
        public Job()
        {

        }

        public JobResponse GetJobs(JobRequest request)
        {
            Business.Banking.Job customerBusiness = new Business.Banking.Job();
            List<JobContract> jobs = customerBusiness.GetJobs();

            if (jobs != null)
            {
                return new JobResponse()
                {
                    jobs = jobs,
                    IsSuccess = true
                };
            }
            return new JobResponse()
            {
                IsSuccess = false
            };
        }

    }
}
