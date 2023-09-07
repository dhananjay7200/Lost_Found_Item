using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC_Lost_Found.Interfaces;
using MVC_Lost_Found.Models;
using System.Data;

namespace MVC_Lost_Found.Controllers
{
    public class UserdetailsController : Controller
    {
        private readonly IUserdetails _context;

        public UserdetailsController(IUserdetails context)
        {
            _context = context;
        }

        public string user_name = "_name";
        IEnumerable<Item> Userdata=new List<Item>();



        public ActionResult Index()
        {
            return View();
        }
      

        public ActionResult UserLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Userlogin(Userdetail user)
        {
         Userdetail u = _context.UserLogin(user);
            if (u==null)
            {
               ModelState.AddModelError(string.Empty, "Please enter valid data");
            }
           HttpContext.Session.SetString(user_name, u.UserName);
           TempData["UserN"] = u.UserName;
            UserProfile();

            return RedirectToAction("Index");
        }

     

        public ActionResult Pratice()
        {

            return View();
        }

        public ActionResult UserProfiler()
        {
            ViewData["username"] = TempData["UserN"];
            ViewData["userdata"] = Userdata;
            return View();
        }

        public void UserProfile()
        {
            IEnumerable<Item> u=_context.UserProfile(HttpContext.Session.GetString(user_name));
            foreach (Item item in u)
            {
                Console.WriteLine(item.Uname);

            }
            Userdata = u;

            
        }

    }
}
