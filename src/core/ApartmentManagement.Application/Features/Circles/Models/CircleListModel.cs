
using ApartmentManagement.Domain.Entities;

namespace ApartmentManagement.Application.Features.Circles.Models
{
    public class CircleListModel
    {
        public int CircleId { get; set; }

        public string CircleNo { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }

        public string TenantOwner { get; set; }

        public int LivingPeopleCount { get; set; }
    }
}
