using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Employees.Models;

namespace Employees.Services
{
    public interface AccountService
    {
        public Account Login(string username, string password);
        
    }
}