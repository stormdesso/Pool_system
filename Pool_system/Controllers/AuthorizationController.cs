using Microsoft.AspNetCore.Mvc;
using Pool_system.Models;
using System.Net;

namespace Pool_system.Controllers
{
    public class AuthorizationController : Controller
    {

        public IActionResult Index() //При запуске этого контроллера, выводит html с именем index из папки Authorization (Из-за схожести названия контроллера и папки)
        {
            return View();
        }

        public IActionResult dataCheck() //При запуске этого контроллера, выводит html с именем index из папки Authorization (Из-за схожести названия контроллера и папки)
        {
            return View();
        }

        [HttpPost]
        public IActionResult CheckData(AuthorizationModel data) //Контроллер обработки данных из формы берет поля из метода AuthorizationModel
        {
            if (data.Login == "admin" && data.Password == "admin")
            {
                return View("dataCheck");
            }
            else
            {
                return View("Index");
            }
        }
    }
}
