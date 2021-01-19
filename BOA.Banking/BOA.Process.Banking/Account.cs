using BOA.Types.Banking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOA.Process.Banking
{
    public class Account
    {

        public AccountResponse AddAccount(AccountRequest request)
        {
            Business.Banking.Account accountBusiness = new Business.Banking.Account();
            List<AccountContract> accountContracts = accountBusiness.AddAccount(request.accountContract);

            if (accountContracts != null)
            {
                return new AccountResponse()
                {
                    accountContracts = accountContracts,
                    IsSuccess = true
                };
            }
            return new AccountResponse()
            {
                IsSuccess = false
            };
        }


        public AccountResponse GetAccountLastSuffixNumber(AccountRequest request)
        {
            Business.Banking.Account accountBusiness = new Business.Banking.Account();
            int lastsuffix = accountBusiness.GetAccountLastSuffixNumber(request.accountContract);

            return new AccountResponse()
            {
                suffix=lastsuffix,
                IsSuccess = true
            };
        }

        public AccountResponse AccountAll(AccountRequest request)
        {
            Business.Banking.Account accountBusiness = new Business.Banking.Account();
            List<AccountContract> accountContracts = accountBusiness.AccountAll();

            if (accountContracts != null)
            {
                return new AccountResponse()
                {
                    accountContracts = accountContracts,
                    IsSuccess = true
                };
            }
            return new AccountResponse()
            {
                IsSuccess = false
            };
        }

        public AccountResponse GetAccounts(AccountRequest request)
        {
            Business.Banking.Account accountBusiness = new Business.Banking.Account();
            List<AccountContract> accountContracts = accountBusiness.GetAccounts(request.accountContract);

            if (accountContracts.Count>0)
            {
                return new AccountResponse()
                {
                    accountContracts = accountContracts,
                    IsSuccess = true
                };
            }
            return new AccountResponse()
            {
                IsSuccess = false
            };
        }

        public AccountResponse GetAccount(AccountRequest request)
        {
            Business.Banking.Account accountBusiness = new Business.Banking.Account();
            AccountContract accountContract = accountBusiness.GetAccount(request.accountContract);

            if (accountContract == null)
            {
                return new AccountResponse()
                {
                    accountContract = accountContract,
                    IsSuccess = true
                };
            }
            return new AccountResponse()
            {
                IsSuccess = false
            };
        }

        public AccountResponse UpdateAccount(AccountRequest request)
        {
            Business.Banking.Account accountBusiness = new Business.Banking.Account();
            AccountContract accountContract = accountBusiness.UpdateAccount(request.accountContract);

            if (accountContract != null)
            {
                return new AccountResponse()
                {
                    accountContract = accountContract,
                    IsSuccess = true
                };
            }
            return new AccountResponse()
            {
                IsSuccess = false
            };
        }

        public AccountResponse DeleteAccount(AccountRequest request)
        {
            Business.Banking.Account accountBusiness = new Business.Banking.Account();
            bool accountContract = accountBusiness.DeleteAccount(request.accountContract);

            if (accountContract)
            {
                return new AccountResponse()
                {
                    IsSuccess = true
                };
            }
            return new AccountResponse()
            {
                IsSuccess = false
            };
        }

    }
}
