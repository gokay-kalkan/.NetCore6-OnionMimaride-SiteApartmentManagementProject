using System.ComponentModel.DataAnnotations;

namespace ApartmentManagement.UI.Areas.Manager.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Boş Geçilemez")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Boş Geçilemez")]

        public string Password { get; set; }
    }
}
