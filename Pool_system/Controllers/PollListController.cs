using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pool_system.Models;

namespace Pool_system.Controllers
{
 
    public class PollsListController : Controller//контроллер страницы с опросами
    {
        public PollsListController()
        {
            PollsList = new List<Poll>();
            PollsList.Add(new Poll("Свет есть?", new List<string>() { "Да", "Нет"}));
            PollsList.Add(new Poll("Вода есть?", new List<string>() { "Да", "Нет"}));
            PollsList.Add(new Poll("Газ есть?", new List<string>() { "Да", "Нет"}));
        }
        private List<Poll> PollsList { get; }

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

    class Poll
    {
        public string Question { get; }
        public List<string> Answers { get; }

        public Poll(string question, List<string> answers)
        {
            Question = question;
            Answers = answers;
        }
    }

}
