

namespace ApartmentManagement.Application.Features.Users.Models
{
    public class UserCreateModel
    {
        public int UserId { get; set; }

        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public string Password { get; set; }

        public string TcNo { get; set; }

        public bool DeleteStatus { get; set; }
    }
}
