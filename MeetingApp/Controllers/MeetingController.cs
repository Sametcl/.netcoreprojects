using MeetingApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace MeetingApp.Controllers
{
    public class MeetingController : Controller
    {
      
        [HttpGet]
        public IActionResult Apply()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Apply(UserInfo model)
        {
            //database kaydı yapılabilir 
            //biz Model ksımında list ile tutalım 

            if (ModelState.IsValid)
            {
            ViewBag.UserCount=Repository.Users.Where(i=>i.WillAttend == true).Count();  
            Repository.CreateUser(model);
            return View ("Thanks" , model);
            }
            else
            {
                return View(model);
            }

        }

        [HttpGet]
        public IActionResult List()
        {
            var users=Repository.Users;
            return View(users);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
           var userdetails=Repository.GetById(id);
            return View(userdetails);
        }
    }
}
