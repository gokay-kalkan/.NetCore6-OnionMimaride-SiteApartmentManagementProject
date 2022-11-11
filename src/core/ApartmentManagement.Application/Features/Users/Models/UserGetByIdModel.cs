
namespace ApartmentManagement.Application.Features.Users.Models
{
    public class UserGetByIdModel
    {
        public int UserId { get; set; }

        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string TcNo { get; set; }

        public string? Password { get; set; }


    }
}
