using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Pool_system.Models
{
    public class RegistrationModel
    {
        //Логин
        public string Login { get; set; }

        //Пароль
        public string Password { get; set; }

        //Подтверждение пароля
        public string ConfirmPassword { get; set; }

        //ФИО
        public string Name { get; set; }

        //Электронная почта
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
