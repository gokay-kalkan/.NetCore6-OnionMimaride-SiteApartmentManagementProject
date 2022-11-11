

using ApartmentManagement.Domain.Entities;

namespace ApartmentManagement.Application.Features.DuesPayments.Models
{
    public class DuesListPaymentModel
    {
        public int DuesPaymentId { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }
     
    
        public double PaymentAmount { get; set; }

        public DateTime PaymentDate { get; set; }
    }


}
