using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using BOA.Types.Banking;
using System.Data;
using System.Security.Cryptography;
using BOA.Types.Banking.Base;

namespace BOA.Business.Banking
{
    public class CustomerDetail
    {
        DbOperation dbOperation;

        public CustomerDetail()
        {
            if (dbOperation == null)
                dbOperation = new DbOperation();
        }

        public CustomerDetailContract GetCustomerDetail(int Id)
        {
            SqlDataReader dr;

            dr = dbOperation.SpGetData("cus.sel_customerdetail", new SqlParameter[]{
                new SqlParameter("@Id", Id)
            });
            CustomerDetailContract customerDetail = new CustomerDetailContract(); ;

            while (dr.Read())
            {
                customerDetail.Id = (int)dr[0];
                customerDetail.Name = dr[1].ToString();
                customerDetail.SurName = dr[2].ToString();
                customerDetail.TaxNumber = dr[3].ToString();
                customerDetail.BirthPlace = dr[4].ToString();
                customerDetail.BirthDate = (DateTime)dr[5];
                customerDetail.MomName = dr[6].ToString();
                customerDetail.FatherName = dr[7].ToString();
                customerDetail.EducationId = (int)dr[8];
                customerDetail.JobId = (int)dr[9];
            }

            return customerDetail;

        }
        public CustomerDetailContract UpdateCustomerDetail(CustomerDetailContract customerDetailContract)
        {
            SqlDataReader dr;

            dr = dbOperation.SpGetData("cus.upd_customerdetail", new SqlParameter[]{
                new SqlParameter("@Id", customerDetailContract.Id),
                new SqlParameter("@Name", customerDetailContract.Name),
                new SqlParameter("@Surname", customerDetailContract.SurName),
                new SqlParameter("@TaxNumber", customerDetailContract.TaxNumber),
                new SqlParameter("@BirthPlace", customerDetailContract.BirthPlace),
                new SqlParameter("@BirthDate", customerDetailContract.BirthDate.Date),
                new SqlParameter("@MomName", customerDetailContract.MomName),
                new SqlParameter("@FatherName", customerDetailContract.FatherName),
                new SqlParameter("@EducationId", customerDetailContract.EducationId),
                new SqlParameter("@JobId", customerDetailContract.JobId)
            });


            CustomerDetailContract customerDetailResponse = new CustomerDetailContract(); ;

            while (dr.Read())
            {
                customerDetailResponse.Id = (int)dr[0];
                customerDetailResponse.Name = dr[1].ToString();
                customerDetailResponse.SurName = dr[2].ToString();
                customerDetailResponse.TaxNumber = dr[3].ToString();
                customerDetailResponse.BirthPlace = dr[4].ToString();
                customerDetailResponse.BirthDate = (DateTime)dr[5];
                customerDetailResponse.MomName = dr[6].ToString();
                customerDetailResponse.FatherName = dr[7].ToString();
                customerDetailResponse.EducationId = (int)dr[8];
                customerDetailResponse.JobId = (int)dr[9];
            }

            return customerDetailResponse;
        }
        public CustomerDetailContract DeleteCustomerDetail(CustomerDetailContract customerDetail)
        {
            SqlDataReader dr;

            dr = dbOperation.SpGetData("cus.del_customerdetail", new SqlParameter[]{
                new SqlParameter("@Id", customerDetail.Id)
            });

            CustomerDetailContract customerDetailResponse = new CustomerDetailContract();

            while (dr.Read())
            {
                customerDetailResponse.Id = (int)dr[0];
            }

            return customerDetailResponse;
        }
        public CustomerDetailContract AddCustomerDetail(CustomerDetailContract customerDetail)
        {
            SqlDataReader dr;

            dr = dbOperation.SpGetData("cus.ins_customerdetail", new SqlParameter[]{

                new SqlParameter("@Name", customerDetail.Name),
                new SqlParameter("@Surname", customerDetail.SurName),
                new SqlParameter("@TaxNumber", customerDetail.TaxNumber),
                new SqlParameter("@BirthPlace", customerDetail.BirthPlace),
                new SqlParameter("@BirthDate", customerDetail.BirthDate.Date),
                new SqlParameter("@MomName", customerDetail.MomName),
                new SqlParameter("@FatherName", customerDetail.FatherName),
                new SqlParameter("@EducationId", customerDetail.EducationId),
                new SqlParameter("@JobId", customerDetail.JobId)
            });


            CustomerDetailContract customerDetailResponse = new CustomerDetailContract(); ;

            while (dr.Read())
            {
                customerDetailResponse.Id = (int)dr[0];
                customerDetailResponse.Name = dr[1].ToString();
                customerDetailResponse.SurName = dr[2].ToString();
                customerDetailResponse.TaxNumber = dr[3].ToString();
                customerDetailResponse.BirthPlace = dr[4].ToString();
                customerDetailResponse.BirthDate = (DateTime)dr[5];
                customerDetailResponse.MomName = dr[6].ToString();
                customerDetailResponse.FatherName = dr[7].ToString();
                customerDetailResponse.EducationId = (int)dr[8];
                customerDetailResponse.JobId = (int)dr[9];
            }

            return customerDetailResponse;
        }
    }
}
