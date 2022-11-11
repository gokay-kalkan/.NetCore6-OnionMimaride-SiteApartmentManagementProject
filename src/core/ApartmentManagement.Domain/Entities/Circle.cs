
using System.ComponentModel.DataAnnotations;

namespace ApartmentManagement.Domain.Entities
{
    public class Circle
    {
        [Key]
        public int CircleId { get; set; }

        public string CircleNo { get; set; }

        public int UserId { get; set; }

        public string TenantOwner { get; set; }

        public int LivingPeopleCount { get; set; }

        public bool DeleteStatus { get; set; }

        public virtual ICollection<Dues> Dues{ get; set; }
        public virtual User User { get; set; }



    }
}
