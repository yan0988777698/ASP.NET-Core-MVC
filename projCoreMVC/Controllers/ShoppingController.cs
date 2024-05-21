using Microsoft.AspNetCore.Mvc;
using projCoreMVC.Models;
using projCoreMVC.ViewModels;
using System.Text.Json;

namespace projCoreMVC.Controllers
{
    public class ShoppingController : SuperController
    {
        DbRoomContext _dbRoomContext = new DbRoomContext();
        public IActionResult List()
        {
            var rooms = from room in _dbRoomContext.TRooms
                        select room;
            return View(rooms);
        }
        public ActionResult AddToCart(int? id)
        {
            if (id == null) { return RedirectToAction("List"); }
            ViewBag.roomID = id;
            return View();
        }
        [HttpPost]
        public IActionResult AddToCart(CShoppingCartViewModel shoppingCart)
        {
            TRoom? foundroom = _dbRoomContext.TRooms.FirstOrDefault(room => room.Fid == shoppingCart.txtRoomID);
            if (foundroom == null) { return RedirectToAction("List"); }

            List<CShoppingCartItem>? cart = null;
            string? json = "";
            if (!HttpContext.Session.Keys.Contains(CDictionary.SessionKey_Unpaied_RoomList))
            {
                cart = new List<CShoppingCartItem>();
            }
            else
            {
                json = HttpContext.Session.GetString(CDictionary.SessionKey_Unpaied_RoomList);
                cart = JsonSerializer.Deserialize<List<CShoppingCartItem>>(json);
            }
            CShoppingCartItem item = new CShoppingCartItem();
            item.roomID = shoppingCart.txtRoomID;
            item.count = shoppingCart.txtCount;
            item.price = (decimal)foundroom.FPrice;
            item.room = foundroom;
            cart.Add(item);
            json = JsonSerializer.Serialize(cart);
            HttpContext.Session.SetString(CDictionary.SessionKey_Unpaied_RoomList, json);

            return RedirectToAction("List");
        }
        public IActionResult CartView()
        {
            List<CShoppingCartItem>? cart = null;
            string? json = "";
            if (!HttpContext.Session.Keys.Contains(CDictionary.SessionKey_Unpaied_RoomList))
                return RedirectToAction("List");
            json = HttpContext.Session.GetString(CDictionary.SessionKey_Unpaied_RoomList);
            cart = JsonSerializer.Deserialize<List<CShoppingCartItem>>(json);
            return View(cart);
        }
    }
}
