using Microsoft.AspNetCore.Mvc;
using Pool_system.Models;
using System.Net;
using MySql.Data.MySqlClient;

namespace Pool_system.Controllers
{
    public class AuthorizationController : Controller
    {

        public IActionResult Index() //При запуске этого контроллера, выводит html с именем index из папки Authorization (Из-за схожести названия контроллера и папки)
        {
            return View();
        }

        

        [HttpPost]
        public IActionResult CheckData(AuthorizationModel data) //Контроллер обработки данных из формы берет поля из метода AuthorizationModel
        {
            try
            {
                UserContext context = (UserContext)HttpContext.RequestServices.GetService(typeof(UserContext));
                if (context.TryLogInUser(data.Login, data.Password))
                {
                    return View("dataCheck");//авторизован успешно
                }
                else
                    return View("Index");//пользователь не найден
            }
            catch (Exception ex)
            {
                return Problem("Internal error");//не смогли подключитсья к базе и т.п
            }
        }
    }
}
