using BOA.Types.Banking;
using BOA.Types.Banking.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOA.Process.Banking
{
    public class Education
    {

        public EducationResponse GetEducations(EducationRequest request)
        {
            Business.Banking.Education customerBusiness = new Business.Banking.Education();
            List<EducationContract> educations = customerBusiness.GetEducations();

            if (educations != null)
            {
                return new EducationResponse()
                {
                    educations = educations,
                    IsSuccess = true
                };
            }
            return new EducationResponse()
            {
                IsSuccess = false
            };
        }

    }
}
