using Microsoft.AspNetCore.Mvc;
using Pool_system.Models;
using System.Net;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using Pool_system.Models.Classes;
using static Mysqlx.Expect.Open.Types.Condition.Types;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Pool_system.Controllers
{
    public class AuthorizationController : Controller
    {

        private readonly JWTSettings _options;

        public AuthorizationController(IOptions<JWTSettings> optAccess)
        {
            _options = optAccess.Value;
        }
        
        private string GetToken(string login, string password)
        {
            List<Claim> claims = new List<Claim>() { 
            new Claim(ClaimTypes.Name, login),
            new Claim("Password", password),
            };

            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.SecretKey));

            var jwt = new JwtSecurityToken(
                issuer: _options.Issuer,
                audience: _options.Audience,
                claims: claims,
                expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(60)),
                notBefore: DateTime.UtcNow,
                signingCredentials: new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256)
                );


            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }

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
                    //TODO: создать токен и дать user-у в БД
                    /* пока не робит токен null идёт
                    string token = GetToken(data.Login, data.Password);
                    context.PutTokenInDb(token, data);
                    */

                    return View("PoolList");//авторизован успешно
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
                    //TODO: создать токен и дать user-у в БД


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
