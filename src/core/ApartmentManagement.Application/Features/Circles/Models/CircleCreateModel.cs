

namespace ApartmentManagement.Application.Features.Circles.Models
{
    public class CircleCreateModel
    {
        public int CircleId { get; set; }

        public string CircleNo { get; set; }

        public int UserId { get; set; }

        public string TenantOwner { get; set; }

        public int LivingPeopleCount { get; set; }

    }
}
