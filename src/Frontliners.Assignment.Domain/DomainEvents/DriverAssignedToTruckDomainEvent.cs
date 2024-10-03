
using Frontliners.Assignment.Domain.Interfaces;

namespace Frontliners.Assignment.Domain.DomainEvents
{
    public class DriverAssignedToTruckDomainEvent : IDomainEvent
    {
        public string TruckPlanningId { get; set; }
        public string TruckId { get; set; }
        public string TruckLicensePlate { get; set; }
        public string DriverId { get; set; }
        public string DriverName { get; set; }
    }
}
