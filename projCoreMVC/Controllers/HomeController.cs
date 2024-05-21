using Microsoft.AspNetCore.Mvc;
using projCoreMVC.Models;
using projCoreMVC.ViewModels;
using System.Diagnostics;
using System.Text.Json;

namespace projCoreMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            if (HttpContext.Session.Keys.Contains(CDictionary.SessionKey_Login_Member))
            {
                return View();
            }
            return RedirectToAction("Login");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(CLoginViewModel login)
        {
            TCustomer user = (new DbRoomContext()).TCustomers.FirstOrDefault(x=>x.Femail.Equals(login.txtUsername));
            if (user != null && user.Fpassword.Equals(login.txtPassword))
            {
                string json = JsonSerializer.Serialize(user);
                HttpContext.Session.SetString(CDictionary.SessionKey_Login_Member, json);
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}