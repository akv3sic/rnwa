using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Employees.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Employees.Controllers
{
    [Route("login")]
    public class AccountController : Controller
    {        
        private AccountService accountService;
        
        public AccountController(AccountService _accountService)
        {
            accountService = _accountService;
        }

        [Route("index")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var account = accountService.Login(username, password);
            if (account != null)
            {
                HttpContext.Session.SetString("username", username);
                return RedirectToAction("welcome");
            }
            else
            {
                ViewBag.msg = "Pogrešno korisničko ime ili lozinka!";
                return View("Index");
            }
        }

        [Route("welcome")]
        public IActionResult Welcome()
        {
            ViewBag.username = HttpContext.Session.GetString("username");
            Console.WriteLine("korisnicko ime: " + ViewBag.username);
            return View();
        }

        
        [Route("logout")]
        public IActionResult LogOut()
        {
            HttpContext.Session.Remove("username");
            return RedirectToAction("index");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Index");
        }
    }
}