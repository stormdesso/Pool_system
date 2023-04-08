using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Pool_system.Models
{
    public class RegistrationModel
    {
        //Логин
        public string Login { get; set; }

        //Пароль
        //[RegularExpression("((?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&*]).{0,40})", ErrorMessage = "Пароль должен содержать буквы большого и малого регистров, цифры и один из специальных символов !@#$%^&*")] //Ограничение на допустимые символы
        public string Password { get; set; }

        //Подтверждение пароля
        public string ConfirmPassword { get; set; }

        //ФИО
        public string Name { get; set; }

        //Электронная почта
        //[RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "email должен содержать в себе @ и .")]
        public string Email { get; set; }

        //Населенный пункт
        public string Locality { get; set; }

        //Название улицы
        public string StreetName { get; set; }

        //Номер дома
        public string HouseNumber { get; set; }

        //Номер квартиры
        public string ApartmentNumber { get; set; }
    }
}
