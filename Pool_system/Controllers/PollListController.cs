using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pool_system.Models;

namespace Pool_system.Controllers
{
 
    public class PollsListController : Controller//контроллер страницы с опросами
    {
        public IActionResult Index()
        {
            //TODO: при загрузке страницы необходимо подгружать опросы
            //вызывая метод GetListOfPolls и возвращая его во View

            //TODO:добавить проверку времени жизни токена + авторизацию,если expire in < datetimeNow 

            return View();
        }

        [HttpGet]        
        public IActionResult GetListOfPolls() //Контроллер обработки данных из формы берет поля из метода AuthorizationModel
        {
            var token = HttpContext.Request.Cookies.FirstOrDefault(x => x.Key == "Token");//получаем из куки user-а токен                    
                       

            return View("Index");
        }

    }
}
