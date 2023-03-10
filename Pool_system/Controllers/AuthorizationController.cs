using Microsoft.AspNetCore.Mvc;
using Pool_system.Models;
using System.Net;
using MySql.Data.MySqlClient;

namespace Pool_system.Controllers
{
    public class AuthorizationController : Controller
    {
        [HttpGet]
        public IActionResult Index() //При запуске этого контроллера, выводит html с именем index из папки Authorization (Из-за схожести названия контроллера и папки)
        {
            return View();
        }

        [HttpGet]
        public IActionResult RegistrationForm() // Окно регистрации
        {
            return View();
        }

        [HttpGet]
        public IActionResult RestorePasswordForm()
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
                    @ViewData["Message"] = "Пользователь не найден";
                    return View("Index");//пользователь не найден.
            }
            catch (Exception ex)
            {
                return Problem("Internal error");//не смогли подключитсья к базе и т.п
            }
        }

        [HttpPost]
        [Route("registration")] //добавляет к пути registration  
        public IActionResult Registration(RegistrationModel data) //Контроллер обработки данных из формы берет поля из метода AuthorizationModel
        {
            try
            {
                UserContext context = (UserContext)HttpContext.RequestServices.GetService(typeof(UserContext));//получаем подключение к базе
                if (context.TryRegistrationUser(data.Login, data.Password))
                {
                    return View("PoolList");//зарегистрирован успешно
                }
                else
                    @ViewData["Message"] = "Пользователь с таким ФИО уже зарегистрирован"; //Поле для вывода ошибок
                    return View("RegistrationForm");//не зарегистрирован

            }
            catch (Exception ex)
            {
                return Problem("Internal error");//не смогли подключитсья к базе и т.п
            }
        }

        [HttpPost]
        [Route("restorePassword")] //добавляет к пути registration
        public IActionResult RestorePassword(RestorePasswordModel data) //Контроллер обработки запроса на восстановление пароля
        {
            if (true)
            {
                return View("Index");
            }
            else 
            {
                @ViewData["Message"] = "Пользователь не найден";
                return View("RestorePasswordForm");
            }
            
        }


    }
}
