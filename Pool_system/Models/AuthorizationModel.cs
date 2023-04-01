using System.ComponentModel.DataAnnotations;

namespace Pool_system.Models
{
    public class AuthorizationModel
    {
        [Display(Name = "Логин")]
        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public string Login { get; set; } //Данные в поле будут поступать из html при заполнении

        [Display(Name = "Пароль")]
        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public string Password { get; set; } //Данные в поле будут поступать из html при заполнении       
    }
}
