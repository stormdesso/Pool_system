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
        [Route("authorization")] //добавляет к пути authorization         
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
                    return View("Index");//пользователь не найден.
            }
            catch (Exception ex)
            {
                return Problem("Internal error");//не смогли подключитсья к базе и т.п
            }
        }

        [HttpPost]
        [Route("registration")] //добавляет к пути registration  
        public IActionResult Registration() //Контроллер обработки данных из формы берет поля из метода AuthorizationModel
        {
            try
            {
                AuthorizationModel data = new AuthorizationModel();
                data.Login = "ADMIN";
                data.Password = "ADMIN";
                UserContext context = (UserContext)HttpContext.RequestServices.GetService(typeof(UserContext));//получаем подключение к базе
                if (context.TryRegistrationUser(data.Login, data.Password))
                {
                    return View("зарегался");//зарегистрирован успешно
                }
                else
                    return View("не зарегался");//не зарегистрирован

            }
            catch (Exception ex)
            {
                return Problem("Internal error");//не смогли подключитсья к базе и т.п
            }
        }



    }
}
