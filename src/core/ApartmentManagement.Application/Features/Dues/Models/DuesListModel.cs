

using ApartmentManagement.Domain.Entities;

namespace ApartmentManagement.Application.Features.Dues.Models
{
    public class DuesListModel
    {
        public int DuesId { get; set; }

        public string DuesType { get; set; }

        public int CircleId { get; set; }
        public virtual Circle Circle { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public double DuesPrice { get; set; }
        public bool PaidStatus { get; set; }
        public DateTime PaymentDate { get; set; }

        public DateTime PaymentDeadline { get; set; }

    }
}
