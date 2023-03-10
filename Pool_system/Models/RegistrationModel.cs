using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Pool_system.Models
{
    public class RegistrationModel
    {
        [Display(Name = "Логин")]
        public string Login { get; set; } //Логин
        [Display(Name = "Пароль")]
        public string Password { get; set; } //Пароль
        [Display(Name = "ФИО")]
        public string Name { get; set; } //ФИО
        [Display(Name = "Электронная почта")]
        public string Email { get; set; } //Электронная почта
        [Display(Name = "Населенный пункт")]
        public string Locality { get; set; } //Населенный пункт
        [Display(Name = "Название улицы")]
        public string StreetName { get; set; } //Название улицы
        [Display(Name = "Номер дома")]
        public string HouseNumber { get; set; } //Номер дома
        [Display(Name = "Номер квартиры")]
        public string ApartmentNumber { get; set; } //Номер квартиры

    }
}
