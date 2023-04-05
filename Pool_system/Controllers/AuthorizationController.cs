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
using System.Linq;
using Org.BouncyCastle.Asn1.X509;

namespace Pool_system.Controllers
{
    public class AuthorizationController : Controller
    {       
        public JWTSettings _options { get;}

        public AuthorizationController(IOptions<JWTSettings> optAccess)//получаем параметры из appsettings
        {
            _options = optAccess.Value;
        }

        ///<summary> 
        ///Метод используется при первичном входе пользователя в систему(получает токен)
        ///</summary>
        public string GetToken(string login, string password)
        {
            List<Claim> claims = new List<Claim>() { //содержимое токена
            new Claim("Login", login),
            new Claim("Password", password),
            };

            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.SecretKey));

            var jwt = new JwtSecurityToken(
                issuer: _options.Issuer,
                audience: _options.Audience,
                claims: claims,
                expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(60)),//время жизни токена
                notBefore: DateTime.UtcNow,
                signingCredentials: new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256)
                );
                       //JWT.VALIDTO() ВРЕМЯ жизни токена

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
        public IActionResult CheckData(AuthorizationModel userData) //Контроллер обработки данных из формы берет поля из метода AuthorizationModel
        {
            try
            {                              
                UsersContext context = (UsersContext)HttpContext.RequestServices.GetService(typeof(UsersContext));
                if (context.TryLogInUser(userData.Login, userData.Password))
                {                   
                    string token = GetToken(userData.Login, userData.Password);//получаем токен
                    if(context.TryPutTokenInDb(token, userData))
                    {
                        HttpContext.Response.Cookies.Append("Token", token);//добавляем в куки user-у токен                    
                        return Redirect("/PollsList");
                    }
                    else
                    {
                        return Redirect("/");
                    }
                    
                    //return View("PoolList");//авторизован успешно - так делать неправильно, т.к не вызывается контроллер при переходе на страницу и по факту к его методам нельзя обратиться
                }
                else
                    @ViewData["Message"] = "Пользователь не найден";                    
                    return View("Index");
            }
            catch (Exception ex)
            {
                return Problem("Internal error");//не смогли подключитсья к базе и т.п
            }
        }

        [HttpPost]
        [Route("registration")] //добавляет к пути registration  
        public IActionResult Registration(RegistrationModel userData) //Контроллер обработки данных из формы берет поля из метода AuthorizationModel
        {
            try
            {   
                UsersContext context = (UsersContext)HttpContext.RequestServices.GetService(typeof(UsersContext));//получаем подключение к базе
                if (context.TryRegistrationUser(userData.Login, userData.Password, GetToken(userData.Login, userData.Password)))
                {
                    string token = GetToken(userData.Login, userData.Password);//получаем токен
                    if(context.TryPutTokenInDb(token, userData))
                    {
                        HttpContext.Response.Cookies.Append("Token", token);//добавляем в куки user-у токен                                                                           
                        return Redirect("/PollsList");
                    }
                    else
                    {
                        return Redirect("/");
                    }
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
        [Route("restorePassword")] //добавляет к пути restorePassword
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
