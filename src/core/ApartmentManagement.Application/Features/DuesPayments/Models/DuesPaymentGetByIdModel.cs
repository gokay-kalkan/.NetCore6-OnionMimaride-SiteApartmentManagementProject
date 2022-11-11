

namespace ApartmentManagement.Application.Features.DuesPayments.Models
{
    public class DuesPaymentGetByIdModel
    {
        public int DuesPaymentId { get; set; }

        public int UserId { get; set; }

        public double PaymentAmount { get; set; }

        public DateTime PaymentDate { get; set; }
    }
}
