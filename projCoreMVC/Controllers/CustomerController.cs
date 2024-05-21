using Microsoft.AspNetCore.Mvc;
using projCoreMVC.Models;
using projCoreMVC.ViewModels;

namespace projCoreMVC.Controllers
{
    public class CustomerController : SuperController
    {
        DbRoomContext roomContext = new DbRoomContext();
        public IActionResult List(CKeywordViewModel vm)
        {
            IEnumerable<TCustomer>? list = null;
            if (!string.IsNullOrEmpty(vm.Keyword))
            {
                var customers = roomContext.TCustomers.Where(x => x.Fphone.Contains(vm.Keyword) ||
                x.Faddress.Contains(vm.Keyword) ||
                x.Fname.Contains(vm.Keyword) ||
                x.Femail.Contains(vm.Keyword));
                list = customers;
            }
            else
            {
                var customers = from customer in roomContext.TCustomers
                                select customer;
                list = customers;
            }
            return View(list);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(TCustomer customer)
        {
            roomContext.TCustomers.Add(customer);
            roomContext.SaveChanges();
            return RedirectToAction("List");
        }
        public IActionResult Edit(int? id)
        {
            if(id == null) return RedirectToAction("List");
            TCustomer? customer = roomContext.TCustomers.FirstOrDefault(x=>x.Fid == id);
            if(customer == null) return RedirectToAction("List");
            return View(customer);
        }
        [HttpPost]
        public IActionResult Edit(TCustomer customer)
        {
            TCustomer? customerInDB = roomContext.TCustomers.FirstOrDefault(x=>x.Fid==customer.Fid);
            if(customerInDB != null)
            {
                customerInDB.Fphone = customer.Fphone;
                customerInDB.Femail = customer.Femail;
                customerInDB.Faddress = customer.Faddress;
                customerInDB.Fpassword = customer.Fpassword;
                customerInDB.Fname = customer.Fname;
                roomContext.SaveChanges();
            }
            return RedirectToAction("List");
        }
        public IActionResult Delete(int? id)
        {
            TCustomer? customerInDB = roomContext.TCustomers.FirstOrDefault(x => x.Fid == id);
            if (customerInDB != null)
            {
                roomContext.Remove(customerInDB);
                roomContext.SaveChanges();
            }
            return RedirectToAction("List");
        }
    }
}
