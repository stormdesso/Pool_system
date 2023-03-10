using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Pool_system.Models
{
    public class RestorePasswordModel
    {
        [Display(Name = "Логин")]
        public string Login { get; set; }
        [Display(Name = "ФИО")]
        public string Name { get; set; }

    }
}
