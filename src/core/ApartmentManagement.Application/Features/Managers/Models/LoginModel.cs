
using System.ComponentModel.DataAnnotations;

namespace ApartmentManagement.Application.Features.Managers.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Boş Geçilemez")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Boş Geçilemez")]

        public string Password { get; set; }
    }
}
