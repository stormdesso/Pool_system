using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Pool_system.Models
{
    public class RegistrationModel
    {
        [Display(Name = "Логин")]
        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public string Login { get; set; } //Логин

        [Display(Name = "Пароль")]
        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public string Password { get; set; } //Пароль

        [Display(Name = "ФИО")]
        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public string Name { get; set; } //ФИО

        [Display(Name = "Электронная почта")]
        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public string Email { get; set; } //Электронная почта

        [Display(Name = "Населенный пункт")]
        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public string Locality { get; set; } //Населенный пункт

        [Display(Name = "Название улицы")]
        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public string StreetName { get; set; } //Название улицы

        [Display(Name = "Номер дома")]
        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public string HouseNumber { get; set; } //Номер дома

        [Display(Name = "Номер квартиры")]
        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public string ApartmentNumber { get; set; } //Номер квартиры
    }
}
