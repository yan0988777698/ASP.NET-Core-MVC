using Microsoft.AspNetCore.Mvc;
using projCoreMVC.Models;
using System.Text.Json;

namespace projCoreMVC.Controllers
{
    public class AController : SuperController
    {
        public string objectToJSON()
        {
            TCustomer customer = new TCustomer();
            customer.Fid = 1;
            customer.Fname = "Andy";
            customer.Fphone = "1234567890";
            customer.Femail = "andy@gmail.com";
            customer.Faddress = "Taiwan";
            customer.Fpassword = "andy123";
            string json = JsonSerializer.Serialize(customer);
            return json;
        }
        public string jsonToObject()
        {
            string json = objectToJSON();
            TCustomer customer = JsonSerializer.Deserialize<TCustomer>(json);
            return customer.Fname;
        }


        public IActionResult countBySession()
        {
            int count = 0;
            if (HttpContext.Session.Keys.Contains("COUNT"))
                count = (int)HttpContext.Session.GetInt32("COUNT");
            count++;
            HttpContext.Session.SetInt32("COUNT", count);
            ViewBag.COUNT = count;
            return View();
        }
        
    }
}
