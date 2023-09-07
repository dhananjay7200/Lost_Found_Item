using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVC_Lost_Found.Interfaces;
using MVC_Lost_Found.Models;
using System.Data;

namespace MVC_Lost_Found.Controllers
{
    public class ItemsController : Controller
    {
        private readonly ItemInterface _context;
        public IEnumerable<Item> item_list { get; set; }
        public ItemsController(ItemInterface context)
        {
            _context = context;
        }



        public ActionResult AddLostIteam()
        {

            return View();
        }
      
        [HttpPost]
        public ActionResult AddLostIteam(Item iteam)
        {
            iteam.IsLost = 1;
            iteam.IsDeleted= 0;
            _context.AddLostItem(iteam);
            return RedirectToAction("Index", "Userdetails");
        }

        public ActionResult AddFoundIteam()
        {
            return View();
        }
      
        [HttpPost]
        public ActionResult AddFoundIteam(Item iteam)
        {
            
            iteam.IsFound= 1;
            iteam.IsDeleted = 0;
            _context.AddFoundItem(iteam);
            return RedirectToAction("Index", "Userdetails");
            
        }

        public ActionResult SearchItemsByFloor()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SearchItemsByFloorr(Item item) {

            // Console.WriteLine(item.FloorDetails);

            item_list = _context.SearchItemByFloor(item);
           

                foreach (var a in item_list)
                {
                    Console.WriteLine(a.Uname);
                }
            ViewData["mydata"] = item_list;

            return View();
           
            
           
        }




       
    }
}
