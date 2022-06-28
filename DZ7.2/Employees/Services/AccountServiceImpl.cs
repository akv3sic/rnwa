using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Employees.Models;

namespace Employees.Services
{
    public class AccountServiceImpl : AccountService
    {
        
        private List<Account> accounts;

        public AccountServiceImpl()
        {
            accounts = new List<Account> {
                new Account
                {
                    UserName = "ante",
                    Password = "sifra123",
                    FullName = "Ante Kvesić"
                },
                new Account
                {
                    UserName = "vjeko",
                    Password = "sifra123",
                    FullName = "Vjeko Rezić"
                },
                new Account
                {
                    UserName = "test",
                    Password = "sifra123",
                    FullName = "Test Testić"
                },
            };
        }

        public Account Login(string username, string password)
        {
            return accounts.SingleOrDefault(a => a.UserName == username && a.Password == password);
        }
    }
}