using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Pool_system.Controllers
{
    [Authorize]
    public class PollListController : Controller//контроллер страницы с опросами
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
