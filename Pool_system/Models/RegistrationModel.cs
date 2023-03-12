using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Pool_system.Models
{
    public class RegistrationModel
    {
        //Логин
        [Display(Name = "Логин")]
        [Required(ErrorMessage = "Поле обязательно для заполнения")] //Делает поле обязательным для заполнения с выводом сообщения
        public string Login { get; set; }

        //Пароль
        [Display(Name = "Пароль")]
        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        [MinLength(8, ErrorMessage = "Длинна пароля должна быть не меньше 8 символов")]//Ограничение по длине, на 8 символов, с выводом сообщения
        [RegularExpression("((?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&*]).{0,40})", ErrorMessage = "Пароль должен содержать буквы большого и малого регистров, цифры и один из специальных символов !@#$%^&*")] //Ограничение на допустимые символы
        public string Password { get; set; }

        //Подтверждение пароля
        [Display(Name = "Подтвердите пароль")]
        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")] //Проверяет пароли на совпадение
        public string ConfirmPassword { get; set; }

        //ФИО
        [Display(Name = "ФИО")]
        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public string Name { get; set; }

        //Электронная почта
        [Display(Name = "Электронная почта")]
        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "email должен содержать в себе @ и .")]
        public string Email { get; set; }

        //Населенный пункт
        [Display(Name = "Населенный пункт")]
        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public string Locality { get; set; }

        //Название улицы
        [Display(Name = "Название улицы")]
        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public string StreetName { get; set; }

        //Номер дома
        [Display(Name = "Номер дома")]
        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public string HouseNumber { get; set; }

        //Номер квартиры
        [Display(Name = "Номер квартиры")]
        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public string ApartmentNumber { get; set; }
    }
}
