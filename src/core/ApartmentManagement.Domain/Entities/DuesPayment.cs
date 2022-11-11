

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApartmentManagement.Domain.Entities
{
    public class DuesPayment
    {
        [Key]
        public int DuesPaymentId { get; set; }

  
        public int UserId { get; set; }

        public virtual User User { get; set; }

      

        public double PaymentAmount { get; set; }

        public DateTime PaymentDate { get; set; }

        public string CardNumber { get; set; }

        public string CardName { get; set; }

        public string ExpirationMonth { get; set; }

        public string ExpirationYear { get; set; }

        public string Cvc { get; set; }

        public bool DeleteStatus { get; set; }


      
    }
}
