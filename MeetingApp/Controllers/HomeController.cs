using MeetingApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace MeetingApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {

            //int saat=DateTime.Now.Hour;
            int saat=13;

            ViewData["selamlama"]= saat > 12 ? "İyi günler " : "Günaydın";
            //ViewData["username"] = "Samet Çil";

            int UserCount= Repository.Users.Where(i=>i.WillAttend==true).Count();

            var meetinginfo = new MeetingInfo()

            {
                Id = 1,
                Location = "İstanbul, Abc Kongre Merkezi",
                Date = new DateTime(2024, 01, 20, 20, 0, 0),
                NumberOfPeople=UserCount,
            };
            return View(meetinginfo);
        }
    }
}
