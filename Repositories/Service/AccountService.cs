using BusinessObjects.DAO;
using DataAccessObjects.Entity;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Service
{
    public interface IAccountService
    {
        IEnumerable<Account> GetListAccount();
        Account GetAccountByID(int id);
        Account CheckAccount(string email, string password);
        void InsertAccount(Account account);
        void DeleteAccount(int accId);
        void UpdateAccount(int accId, Account account);
    }
    public class AccountService : IAccountService
    {
        public Account CheckAccount(string email, string password)
        {
            try
            {
                var accountCheck = AccountDAO.Instance.GetAccountByEmail(email);
                if(accountCheck == null || accountCheck.Password != password)
                {
                    return null;
                }
                return accountCheck;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public void DeleteAccount(int accId)
        {
            try
            {
                var check = AccountDAO.Instance.GetAccountByID(accId);

                if (check == null)
                {
                    throw new Exception("Account not found!!!");
                }

                AccountDAO.Instance.Remove(accId);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Account GetAccountByID(int id)
        {
            try
            {
                var result = AccountDAO.Instance.GetAccountByID(id);
                return result;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IEnumerable<Account> GetListAccount()
        {
            try
            {
                var result = AccountDAO.Instance.GetAccounts();
                return result;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void InsertAccount(Account account)
        {
            try
            {
                var check = AccountDAO.Instance.GetAccountByEmail(account.Email);
                if(check != null)
                {
                    throw new Exception("Account already exist!!!!");
                }
                AccountDAO.Instance.AddNew(account);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void UpdateAccount(int accId, Account account)
        {
            try
            {
                var check = AccountDAO.Instance.GetAccountByID(accId);
                if (check == null)
                {
                    throw new Exception("Account not found!!!");
                }
                AccountDAO.Instance.Update(account);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
