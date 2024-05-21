using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using projCoreMVC.Models;
using projCoreMVC.ViewModels;

namespace projCoreMVC.Controllers
{
    public class RoomController : SuperController
    {
        private IWebHostEnvironment _envi = null;
        public RoomController(IWebHostEnvironment envi)
        {
            _envi = envi;
        }

        DbRoomContext roomContext = new DbRoomContext();
        // GET: Room
        public ActionResult List(CKeywordViewModel vm)
        {
            IEnumerable<TRoom>? rooms = null;
            if (string.IsNullOrEmpty(vm.Keyword))
            {
                rooms = from room in roomContext.TRooms
                        select room;
            }
            else
            {
                rooms = roomContext.TRooms.Where(room => room.FName.Contains(vm.Keyword));
            }
            return View(rooms);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(TRoom room)
        {
            roomContext.TRooms.Add(room);
            roomContext.SaveChanges();
            return RedirectToAction("List");
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return RedirectToAction("List");
            TRoom? findRoom = roomContext.TRooms.FirstOrDefault(room => room.Fid == id);
            if (findRoom == null)
                return RedirectToAction("List");
            roomContext.TRooms.Remove(findRoom);
            roomContext.SaveChanges();
            return RedirectToAction("List");
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return RedirectToAction("List");
            TRoom? findRoom = roomContext.TRooms.FirstOrDefault(room => room.Fid == id);
            if (findRoom == null)
                return RedirectToAction("List");
            return View(findRoom);
        }
        [HttpPost]
        public ActionResult Edit(CRoomWrap editedRoom)
        {
            if (editedRoom == null)
                return RedirectToAction("List");
            TRoom? findRoom = roomContext.TRooms.FirstOrDefault(room => room.Fid == editedRoom.Fid);
            if (findRoom == null)
                return RedirectToAction("List");
            findRoom.FName = editedRoom.FName;
            findRoom.FPrice = editedRoom.FPrice;
            findRoom.FAmount = editedRoom.FAmount;
            findRoom.FDescription = editedRoom.FDescription;
            findRoom.FImagePath = $"{Guid.NewGuid()}.jpg";
            editedRoom.photo.CopyTo(new FileStream($"{_envi.WebRootPath}/Images/{findRoom.FImagePath}",FileMode.Create));
            roomContext.SaveChanges();
            return RedirectToAction("List");
        }

    }
}