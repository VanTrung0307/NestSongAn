using DataAccessObjects.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.DAO
{
    public class AccountDAO
    {
        private static AccountDAO instance = null;
        public static readonly object instanceLock = new object();
        private AccountDAO() { }
        public static AccountDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new AccountDAO();
                    }
                    return instance;
                }
            }
        }
        public IEnumerable<Account> GetAccounts()
        {
            List<Account> accounts;
            try
            {
                var context = new PRN221_DBContext();
                accounts = context.Accounts.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return accounts;
        }

        public Account GetAccountByID(int Id)
        {
            Account account = null;
            try
            {
                var context = new PRN221_DBContext();
                account = context.Accounts.SingleOrDefault(x => x.Id == Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return account;
        }

        public Account GetAccountByEmail(string Email)
        {
            Account account = null;
            try
            {
                var context = new PRN221_DBContext();
                account = context.Accounts.SingleOrDefault(x => x.Email == Email);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return account;
        }

        public void AddNew(Account account)
        {
            try
            {
                Account _acc = GetAccountByID(account.Id);
                if (_acc == null)
                {
                    account.StartDate = DateTime.Now;
                    var context = new PRN221_DBContext();
                    context.Accounts.Add(account);
                    context.SaveChanges();

                    var acc = context.Accounts.FirstOrDefault(x => x.Email == account.Email);
                    Customer newCustomer = new Customer();
                    newCustomer.AccountId = acc.Id;
                    newCustomer.Name = acc.Name;
                    newCustomer.Email = acc.Email;
                    newCustomer.Phone = acc.Phone;
                    newCustomer.AccountActive = true;
                    context.Customers.Add(newCustomer);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Account is already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(Account account)
        {
            try
            {
                Account acc = GetAccountByID(account.Id);
                if (acc != null)
                {
                    var context = new PRN221_DBContext();
                    context.Entry<Account>(account).State = EntityState.Modified;
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Account does not exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Remove(int accId)
        {
            try
            {
                Account acc = GetAccountByID(accId);
                if (acc != null)
                {
                    var context = new PRN221_DBContext();
                    context.Accounts.Remove(acc);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Account does not exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
