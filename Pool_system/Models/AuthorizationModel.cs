using System.ComponentModel.DataAnnotations;

namespace Pool_system.Models
{
    public class AuthorizationModel
    {
        //Логин
        public string Login { get; set; } //Данные в поле будут поступать из html при заполнении
        
        //Пароль
        public string Password { get; set; } //Данные в поле будут поступать из html при заполнении       
    }
}
