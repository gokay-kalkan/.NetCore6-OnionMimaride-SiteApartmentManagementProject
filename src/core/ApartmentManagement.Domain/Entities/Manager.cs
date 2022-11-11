

using System.ComponentModel.DataAnnotations;

namespace ApartmentManagement.Domain.Entities
{
    public class Manager
    {
        [Key]
        public int ManagerId { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Password { get; set; }
    }
}
