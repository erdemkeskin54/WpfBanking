using BOA.Types.Banking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOA.Process.Banking
{
    public class Login
    {
        public Login()
        {

        }

        //Login işlemleri
        public LoginResponse GetLogin(LoginRequest request)
        {
            Business.Banking.Login customerBusiness = new Business.Banking.Login();
            var isSuccess = customerBusiness.GetLogin(request.LoginContract);


            if (isSuccess)
            {
                return new LoginResponse()
                {
                    IsSuccess = true
                };
            }
            return new LoginResponse()
            {
                IsSuccess = false
            };
        }
        //----------------------------------------------------------------------------------


    }
}
