

using System.ComponentModel.DataAnnotations;

namespace ApartmentManagement.Domain.Entities
{
    public class Recommendations
    {
        [Key]
        public int RecommendationsId { get; set; }

        public string Description { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }

    }
}
