

namespace ApartmentManagement.Application.Features.Dues.Models
{
    public class DuesUpdateModel
    {
        public int DuesId { get; set; }

        public string? DuesType { get; set; }

        public int? CircleId { get; set; }

        public int? UserId { get; set; }
        public bool PaidStatus { get; set; }
        public double? DuesPrice { get; set; }

        public DateTime? PaymentDate { get; set; }

    }
}
