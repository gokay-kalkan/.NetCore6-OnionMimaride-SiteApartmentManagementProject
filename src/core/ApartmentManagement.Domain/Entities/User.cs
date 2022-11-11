

using System.ComponentModel.DataAnnotations;

namespace ApartmentManagement.Domain.Entities
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public string? Password { get; set; }
       

        public string TcNo { get; set; }

        public bool DeleteStatus { get; set; }
     
        public virtual ICollection<Circle> Circles { get; set; }

        public virtual ICollection<Dues> Dues { get; set; }
       
        public virtual ICollection<Recommendations> Recommendations { get; set; }
       
        public virtual ICollection<DuesPayment> DuesPayments { get; set; }


    }
}
