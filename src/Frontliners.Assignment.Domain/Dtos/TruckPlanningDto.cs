
using Frontliners.Assignment.Domain.Entities;

namespace Frontliners.Assignment.Domain.Dtos
{
    public class TruckPlanningDto
    {
        public string Id { get; set; }
        public Truck Truck { get; set; }
        public Driver Driver { get; set; }
    }
}
