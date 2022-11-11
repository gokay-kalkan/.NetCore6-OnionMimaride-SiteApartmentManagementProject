

using System.ComponentModel.DataAnnotations;

namespace ApartmentManagement.Domain.Entities
{
    public class Dues
    {
        [Key]
        public int DuesId { get; set; }

        public string? DuesType { get; set; }

        public int? CircleId { get; set; }

        public int? UserId { get; set; }

        public double? DuesPrice { get; set; }

        public DateTime? PaymentDate { get; set; }

        public bool PaidStatus { get; set; }

        public bool DeleteStatus { get; set; }

        public DateTime PaymentDeadline { get; set; }


        public virtual Circle Circle { get; set; }
        public virtual User User { get; set; }
    

      


    }
}
