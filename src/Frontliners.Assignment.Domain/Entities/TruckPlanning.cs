using Frontliners.Assignment.Domain.Entities.Base;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Frontliners.Assignment.Domain.Entities
{
    public class TruckPlanning : IEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = ObjectId.GenerateNewId().ToString();
        public string TruckId { get; set; }
        public string TruckLicensePlate { get; set; }
        public string DriverId { get; set; }
        public string DriverName { get; set; }
        public bool IsActive { get; private set; } = true;

        public void UnassignDriver()
        {
            IsActive = false;
        }
    }
}
